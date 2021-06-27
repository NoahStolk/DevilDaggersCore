namespace DevilDaggersCore.Game
{
	public record Death(GameVersion GameVersion, string Name, string ColorCode, byte DeathType)
		: DevilDaggersEntity(GameVersion, Name, ColorCode);
}
