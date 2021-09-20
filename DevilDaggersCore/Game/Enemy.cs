using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	public record Enemy(GameVersion GameVersion, string Name, string ColorCode, int Hp, int Gems, int NoFarmGems, byte? SpawnsetType, Death? Death, float? Homing3, float? Homing4, int? FirstSpawnSecond, params Enemy[] SpawnedBy)
		: DevilDaggersEntity(GameVersion, Name, ColorCode)
	{
		[JsonIgnore]
		public int GemHp => Hp / Gems;

		public string GetGemHpString()
			=> $"({GemHp} x {Gems})";
	}
}
