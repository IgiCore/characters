namespace IgiCore.Characters.Shared
{
	public static class CharacterEvents
	{
		public const string Configuration = "igicore:character:configuration";
		public const string Disconnecting = "igicore:character:disconnecting";
		public const string Create = "igicore:character:create";
		public const string Load = "igicore:character:load";
		public const string Delete = "igicore:character:delete";
		public const string Select = "igicore:character:select";
		public const string DeselectAll = "igicore:character:deselectall";

		public const string SaveCharacter = "igicore:character:save:character";
		public const string SavePosition = "igicore:character:save:position";

		public const string SaveHeritage = "igicore:characters:save:heritage";
		public const string SaveFacialTrait = "igicore:characters:save:facialtrait";
		public const string SaveStyle = "igicore:characters:save:style";
		public const string SaveTrait = "igicore:characters:save:trait";

		public const string Selecting = "igicore:character:selecting";
		public const string Selected = "igicore:character:selected";
		public const string Deselecting = "igicore:character:deselecting";
		public const string Deselected = "igicore:character:deselected";

		public const string GetActive = "igicore:character:getactive";
	}
}
