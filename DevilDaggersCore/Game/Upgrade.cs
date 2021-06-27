﻿namespace DevilDaggersCore.Game
{
	public class Upgrade : DevilDaggersEntity
	{
		public Upgrade(GameVersion gameVersion, string name, string colorCode, float defaultSpray, int defaultShot, float? homingSpray, int? homingShot, string unlocksAt)
			: base(gameVersion, name, colorCode)
		{
			DefaultSprayPerSecond = defaultSpray;
			DefaultShot = defaultShot;
			HomingSprayPerSecond = homingSpray;
			HomingShot = homingShot;
			UnlocksAt = unlocksAt;
		}

		public float DefaultSprayPerSecond { get; set; }
		public int DefaultShot { get; set; }
		public float? HomingSprayPerSecond { get; set; }
		public int? HomingShot { get; set; }
		public string UnlocksAt { get; set; }

		public int Level => int.Parse(Name[^1].ToString());
	}
}
