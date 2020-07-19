namespace DevilDaggersCore.Game
{
	public class Upgrade : DevilDaggersEntity
	{
		public Upgrade(string name, string colorCode, float defaultSpray, int defaultShot, float? homingSpray, int? homingShot, string unlocksAt)
			: base(name, colorCode)
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

		public int Level => int.Parse(Name[Name.Length - 1].ToString());
	}
}