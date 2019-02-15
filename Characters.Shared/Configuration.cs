using System;
using NFive.SDK.Core.Controllers;

namespace IgiCore.Characters.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public TimeSpan CharacterSaveInterval { get; set; } = TimeSpan.FromMinutes(5);

		public TimeSpan PositionSaveInterval { get; set; } = TimeSpan.FromMinutes(1);
	}
}
