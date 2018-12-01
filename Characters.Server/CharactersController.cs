using JetBrains.Annotations;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rpc;

namespace IgiCore.Characters.Server
{
	[PublicAPI]
	public class CharactersController : ConfigurableController<Configuration>
	{
		public CharactersController(ILogger logger, IEventManager events, IRpcHandler rpc, Configuration configuration) : base(logger, events, rpc, configuration)
		{
			this.Logger.Debug("Hello World!");
		}
	}
}
