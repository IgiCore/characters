using System;
using NFive.SDK.Core.Controllers;

namespace IgiCore.Characters.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public SelectionScreenConfiguration SelectionScreen { get; set; } = new SelectionScreenConfiguration();

		public int MaximumCharacters { get; set; } = -1;

		public AutosaveConfiguration Autosave { get; set; } = new AutosaveConfiguration();

		public class AutosaveConfiguration
		{
			public TimeSpan CharacterInterval { get; set; } = TimeSpan.FromMinutes(5);

			public TimeSpan PositionInterval { get; set; } = TimeSpan.FromSeconds(2);
		}

		public class SelectionScreenConfiguration
		{
			public string Hotkey { get; set; } = "ReplayStartStopRecording"; // Default to F1
		}
	}
}
