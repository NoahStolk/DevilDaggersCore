using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Game
{
	public class Enemy : DevilDaggersEntity
	{
		public Enemy(GameVersion gameVersion, string name, string colorCode, int hp, int gems, int noFarmGems, byte? spawnsetType, Death? death, float? homing3, float? homing4, params Enemy[] spawnedBy)
			: base(gameVersion, name, colorCode)
		{
			Hp = hp;
			Gems = gems;
			NoFarmGems = noFarmGems;
			SpawnsetType = spawnsetType;
			Death = death;
			Homing3 = homing3;
			Homing4 = homing4;
			SpawnedBy = spawnedBy;
		}

		public int Hp { get; set; }

		public int Gems { get; set; }

		public int NoFarmGems { get; set; }

		public byte? SpawnsetType { get; set; }

		public Death? Death { get; set; }

		public float? Homing3 { get; set; }

		public float? Homing4 { get; set; }

		public IReadOnlyList<Enemy> SpawnedBy { get; set; }

		[JsonIgnore]
		public int GemHp => Hp / Gems;

		public string GetGemHpString()
			=> $"({GemHp} x {Gems})";

		public Enemy Copy()
			=> new(GameVersion, Name, ColorCode, Hp, Gems, NoFarmGems, SpawnsetType, Death, Homing3, Homing4, SpawnedBy.ToArray());
	}
}
