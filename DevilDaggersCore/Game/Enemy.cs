using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Enemy : DevilDaggersEntity
	{
		[JsonProperty]
		public int Hp { get; set; }
		[JsonProperty]
		public int Gems { get; set; }
		[JsonProperty]
		public Death Death { get; set; }
		[JsonProperty]
		public float? Homing3 { get; set; }
		[JsonProperty]
		public float? Homing4 { get; set; }
		[JsonProperty]
		public bool RegisterKill { get; set; }
		[JsonProperty]
		public Enemy[] SpawnedBy { get; set; }

		public int GemHp => Hp / Gems;

		public Enemy(string name, string colorCode, int hp, int gems, Death death, float? homing3, float? homing4, bool registerKill, params Enemy[] spawnedBy)
			: base(name, colorCode)
		{
			Hp = hp;
			Gems = gems;
			Death = death;
			Homing3 = homing3;
			Homing4 = homing4;
			RegisterKill = registerKill;
			SpawnedBy = spawnedBy;
		}

		public string GetGemHPString()
		{
			return $"({GemHP} x {Gems})";
		}

		public Enemy Copy()
		{
			return new Enemy(Name, ColorCode, HP, Gems, Death, Homing3, Homing4, RegisterKill, SpawnedBy);
		}
	}
}