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

namespace IgiCore.Characters.Server
{
	[PublicAPI]
	public class CharactersController : ConfigurableController<Configuration>
	{
		public CharactersController(ILogger logger, IEventManager events, IRpcHandler rpc, Configuration configuration) : base(logger, events, rpc, configuration)
		{
			this.Rpc.Event(CharacterEvents.Create).On<Character>(async (e, character) =>
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

				using (var context = new StorageContext())
				{
					// Save character
					context.Characters.Add(character);

					await context.SaveChangesAsync();
				}

				this.Logger.Debug($"Saved new character: {character.FullName}");

				// Send back updated user
				e.Reply(character);
			});
		}
	}
}
