using IgiCore.Characters.Server.Models;
using IgiCore.Characters.Server.Storage;
using IgiCore.Characters.Shared;
using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rpc;
using System;
using System.Data.Entity;
using System.Linq;

namespace IgiCore.Characters.Server
{
	[PublicAPI]
	public class CharactersController : ConfigurableController<Configuration>
	{
		public CharactersController(ILogger logger, IEventManager events, IRpcHandler rpc, Configuration configuration) : base(logger, events, rpc, configuration)
		{
			this.Rpc.Event(CharacterEvents.Load).On(Load);

			this.Rpc.Event(CharacterEvents.Create).On<Character>(Create);
		}

		public void Load(IRpcEvent e)
		{
			using (var context = new StorageContext())
			{
				var characters = context.Characters.Where(c => c.UserId == e.User.Id).ToList();
				
				e.Reply(characters);
			}
		}

		public async void Create(IRpcEvent e, Character character)
		{
			// TODO: Validate client sent values

			// Don't trust important values from clients
			character.Id = GuidGenerator.GenerateTimeBasedGuid();
			character.UserId = e.User.Id;
			character.Alive = true;
			character.Health = 10000;
			character.Armor = 0;
			character.Ssn = 10000000;
			character.LastPlayed = DateTime.UtcNow;
			character.Position = new Position(0f, 0f, 71f);

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
		}
	}
}
