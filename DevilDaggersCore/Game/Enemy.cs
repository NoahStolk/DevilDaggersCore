using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	public record Enemy(GameVersion GameVersion, string Name, string ColorCode, int Hp, int Gems, int NoFarmGems, byte? SpawnsetType, Death? Death, float? Homing3, float? Homing4, params Enemy[] SpawnedBy)
		: DevilDaggersEntity(GameVersion, Name, ColorCode)
	{
		[JsonIgnore]
		public int GemHp => Hp / Gems;

		public string GetGemHpString()
			=> $"({GemHp} x {Gems})";

		public Enemy Copy()
			=> new(GameVersion, Name, ColorCode, Hp, Gems, NoFarmGems, SpawnsetType, Death, Homing3, Homing4, SpawnedBy);
	}
}
