namespace DevilDaggersCore.Game
{
	public record Dagger(GameVersion GameVersion, string Name, string ColorCode, int? UnlockSecond)
		: DevilDaggersEntity(GameVersion, Name, ColorCode);
}
