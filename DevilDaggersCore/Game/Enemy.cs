using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Enemy : DevilDaggersEntity
	{
		public Enemy(GameVersion gameVersion, string name, string colorCode, int hp, int gems, int noFarmGems, byte? spawnsetType, Death? death, float? homing3, float? homing4, bool registerKill, params Enemy[] spawnedBy)
			: base(gameVersion, name, colorCode)
		{
			Hp = hp;
			Gems = gems;
			NoFarmGems = noFarmGems;
			SpawnsetType = spawnsetType;
			Death = death;
			Homing3 = homing3;
			Homing4 = homing4;
			RegisterKill = registerKill;
			SpawnedBy = spawnedBy;
		}

		[JsonProperty]
		public int Hp { get; set; }

		[JsonProperty]
		public int Gems { get; set; }

		[JsonProperty]
		public int NoFarmGems { get; set; }

		[JsonProperty]
		public byte? SpawnsetType { get; set; }

		[JsonProperty]
		public Death? Death { get; set; }

		[JsonProperty]
		public float? Homing3 { get; set; }

		[JsonProperty]
		public float? Homing4 { get; set; }

		[JsonProperty]
		public bool RegisterKill { get; set; }

		[JsonProperty]
		public IReadOnlyList<Enemy> SpawnedBy { get; set; }

		public int GemHp => Hp / Gems;

		public string GetGemHpString()
			=> $"({GemHp} x {Gems})";

		public Enemy Copy()
			=> new Enemy(GameVersion, Name, ColorCode, Hp, Gems, NoFarmGems, SpawnsetType, Death, Homing3, Homing4, RegisterKill, SpawnedBy.ToArray());
	}
}