﻿namespace DevilDaggersCore.Game
{
	public class Enemy : DevilDaggersEntity
	{
		public int HP { get; set; }
		public int Gems { get; set; }
		public Death Death { get; set; }
		public float? Homing3 { get; set; }
		public float? Homing4 { get; set; }
		public Enemy[] SpawnedBy { get; set; }

		public Enemy(string name, string colorCode, int hp, int gems, Death death, float? homing3, float? homing4, params Enemy[] spawnedBy)
			: base(name, colorCode)
		{
			HP = hp;
			Gems = gems;
			Death = death;
			Homing3 = homing3;
			Homing4 = homing4;
			SpawnedBy = spawnedBy;
		}

		public int GetGemHP()
		{
			return HP / Gems;
		}
	}
}