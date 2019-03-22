namespace IgiCore.Characters.Shared.Models.Appearance
{
	/// <summary>
	/// Used for freemode(online) characters.
	///	ColorType is 1 for eyebrows, beards, and chest hair; 2 for blush and lipstick; and 0 otherwise, though not called in those cases.
	///	Called after SET_PED_HEAD_OVERLAY(). 
	/// </summary>
	public enum FeatureColorTypes
	{
		Beards = 1,
		Chest = 1,
		EyeBrows = 1,
		Blush = 2,
		Lipstick = 2,
		Misc = 0
	}

	
}
