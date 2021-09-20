namespace DevilDaggersCore.Game
{
	public record Upgrade(GameVersion GameVersion, string Name, string ColorCode, float DefaultSpray, int DefaultShot, float? HomingSpray, int? HomingShot, string UnlocksAt)
		: DevilDaggersEntity(GameVersion, Name, ColorCode)
	{
		public int Level => int.Parse(Name[^1].ToString());
	}
}
