using IgiCore.Characters.Server.Models;
using IgiCore.Characters.Server.Storage;
using IgiCore.Characters.Shared;
using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using IgiCore.Inventory.Server;
using IgiCore.Inventory.Server.Models;
using NFive.SDK.Core.Models.Player;
using NFive.SDK.Server.Communications;
using Configuration = IgiCore.Characters.Shared.Configuration;
using NFive.SDK.Core.Utilities;

namespace IgiCore.Characters.Server
{
	[PublicAPI]
	public class CharactersController : ConfigurableController<Configuration>
	{
		private readonly List<CharacterSession> characterSessions = new List<CharacterSession>();

		private readonly ICommunicationManager comms;
		private IInventoryManager inventoryManager { get; set; }

		public CharactersController(ILogger logger, Configuration configuration, ICommunicationManager comms, IInventoryManager inventoryManager) : base(logger, configuration)
		{
			this.comms = comms;
			this.inventoryManager = inventoryManager;

			// Send configuration when requested
			this.comms.Event(CharacterEvents.Configuration).FromClients().OnRequest(e => e.Reply(this.Configuration));
			this.comms.Event(CharacterEvents.GetCharactersForUser).FromClients().OnRequest(GetCharactersForUser);
			this.comms.Event(CharacterEvents.Create).FromClients().OnRequest<Character>(Create);
			this.comms.Event(CharacterEvents.Delete).FromClients().OnRequest<Guid>(Delete);
			this.comms.Event(CharacterEvents.Select).FromClients().OnRequest<Guid>(Select);
			this.comms.Event(CharacterEvents.SaveCharacter).FromClients().On<Character>(SaveCharacter);
			this.comms.Event(CharacterEvents.SavePosition).FromClients().On<Guid, Position>(SavePosition);

			this.comms.Event(CharacterEvents.GetActive).FromServer().OnRequest(e => e.Reply(this.characterSessions));

			// Listen for NFive SessionManager plugin events
			this.comms.Event(SessionEvents.ClientDisconnected).FromServer().On<IClient, Session>(OnClientDisconnected);
		}

		public override Task Started()
		{
			Cleanup();

			return base.Started();
		}

		private async void Cleanup()
		{
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				var activeSessions = context.CharacterSessions.Where(s => s.Disconnected == null).ToList();
				var lastServerActiveTime = await this.comms.Event(BootEvents.GetLastActiveTime).ToServer().Request<DateTime?>() ?? DateTime.UtcNow;
				foreach (var characterSession in activeSessions)
				{
					characterSession.Connected = null;
					characterSession.Disconnected = lastServerActiveTime;
					context.CharacterSessions.AddOrUpdate(characterSession);
				}

				context.SaveChanges();
				transaction.Commit();
			}
		}

		private async void OnClientDisconnected(ICommunicationMessage e, IClient client, Session session)
		{
			await DeselectAll(session.UserId);
		}

		public async Task DeselectAll(Guid id)
		{
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				var activeSessions = context.CharacterSessions.Where(s =>
					s.Character.UserId == id
					&& s.Disconnected == null
				).ToList();

				foreach (var characterSession in activeSessions)
				{
					this.comms.Event(CharacterEvents.Deselecting).ToServer().Emit(characterSession);
					characterSession.Connected = null;
					characterSession.Disconnected = DateTime.UtcNow;
					context.CharacterSessions.AddOrUpdate(characterSession);
				}

				await context.SaveChangesAsync();
				transaction.Commit();

				foreach (var characterSession in activeSessions)
				{
					this.characterSessions.RemoveAll(c => c.Id == characterSession.Id);
					this.comms.Event(CharacterEvents.Deselected).ToServer().Emit(characterSession);
				}
			}
		}

		private async void Delete(ICommunicationMessage e, Guid id)
		{
			using (var context = new StorageContext())
			{
				var character = context.Characters.First(c => c.Id == id);

				character.Deleted = DateTime.UtcNow;

				await context.SaveChangesAsync();

				GetCharactersForUser(e, e.User.Id);
			}
		}

		private async void Select(ICommunicationMessage e, Guid id)
		{
			await DeselectAll(e.User.Id);

			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				var character = context.Characters.Include(c => c.User).FirstOrDefault(c => c.Id == id);

				if (character == null)
				{
					e.Reply(null);
					throw new Exception($"No character found for Id \"{id}\""); // TODO: CharacterException
				}
				this.comms.Event(CharacterEvents.Selecting).ToServer().Emit(character);

				var newSession = new CharacterSession
				{
					Id = GuidGenerator.GenerateTimeBasedGuid(),
					CharacterId = character.Id,
					Character = character,
					Created = DateTime.UtcNow,
					Connected = DateTime.UtcNow,
					SessionId = e.Session.Id
				};

				context.CharacterSessions.Add(newSession);

				await context.SaveChangesAsync();
				transaction.Commit();

				this.Logger.Debug("Created character session");
				this.Logger.Debug($"Session: {new Serializer().Serialize(e.Session)}");

				newSession.Session = e.Session;

				e.Reply(newSession);

				this.characterSessions.Add(newSession);

				this.comms.Event(CharacterEvents.Selected).ToServer().Emit(newSession);
			}
		}

		private void GetCharactersForUser(ICommunicationMessage e)
		{
			this.Logger.Info($"GetCharactersForUser(ICommunicationMessage e, Guid userId)");
			GetCharactersForUser(e, e.User.Id);
		}

		private void GetCharactersForUser(ICommunicationMessage e, Guid userId)
		{
			this.Logger.Info($"GetCharactersForUser(ICommunicationMessage e, Guid userId) - userId: {userId}");
			using (var context = new StorageContext())
			{
				var characters = context.Characters.Where(c => c.Deleted == null && c.UserId == userId).ToList();

				e.Reply(characters);
			}
		}

		private async void Create(ICommunicationMessage e, Character character)
		{
			// TODO: Validate client sent values

			// Don't trust important values from clients
			character.Id = GuidGenerator.GenerateTimeBasedGuid();
			character.UserId = e.User.Id;
			character.Alive = true;
			character.Health = 10000;
			character.Armor = 0;
			character.Ssn = Character.GenerateSsn();
			character.LastPlayed = DateTime.UtcNow;
			character.Position = new Position(0f, 0f, 71f);
			character.Apparel = new Apparel();
			character.Appearance = new Appearance();
			character.FaceShape = new FaceShape();
			character.Heritage = new Heritage();

			// Save character
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					context.Characters.Add(character);

					await context.SaveChangesAsync();
					transaction.Commit();

					this.Logger.Debug($"Saved new character: {character.FullName}");

					// Send back updated user
					e.Reply(character);
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);

					transaction.Rollback();

					// TODO: Reply with an error so client doesn't hang
				}
			}

			CreateInventories(character);
		}

		public void CreateInventories(Character character)
		{
			var itemDefinition = this.inventoryManager.GetItemDefinitions().First();

			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					var containerToCreate = new Container()
					{
						Name = "Backpack",
						Height = 10,
						Width = 10,
						Items = new List<Item>()
						{
							new Item()
							{
								Width = itemDefinition.Width,
								Height = itemDefinition.Height,
								ItemDefinitionId = itemDefinition.Id
							}
						}
					};

					var container = this.inventoryManager.CreateContainer(containerToCreate);

					context.CharacterInventories.Add(new CharacterInventory()
					{
						CharacterId = character.Id,
						ContainerId = container.Id,
					});

					context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);

					transaction.Rollback();
				}
			}
		}

		public async void SaveCharacter(ICommunicationMessage e, Character character)
		{
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					context.Characters.AddOrUpdate(character);

					await context.SaveChangesAsync();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);

					transaction.Rollback();
				}

				var activeSession = this.characterSessions.FirstOrDefault(s => s.Character.Id == character.Id);
				if (activeSession == null) return;
				activeSession.Character = character;
			}
		}

		public async void SavePosition(ICommunicationMessage e, Guid characterGuid, Position position)
		{
			using (var context = new StorageContext())
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					var saveCharacter = context.Characters.Single(c => c.Id == characterGuid);
					saveCharacter.Position = position;

					await context.SaveChangesAsync();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);

					transaction.Rollback();
				}

				var activeSession = this.characterSessions.FirstOrDefault(s => s.Character.Id == characterGuid);
				if (activeSession == null) return;
				activeSession.Character.Position = position;
			}
		}
	}
}
