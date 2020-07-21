namespace DevilDaggersCore.Game
{
	public static class V1
	{
		public static readonly Dagger Default = new Dagger("Default", "444444", null);
		public static readonly Dagger Bronze = new Dagger("Bronze", "CD7F32", 60);
		public static readonly Dagger Silver = new Dagger("Silver", "DDDDDD", 120);
		public static readonly Dagger Golden = new Dagger("Golden", "FFDF00", 250);
		public static readonly Dagger Devil = new Dagger("Devil", "FF0000", 500);

		public static readonly Upgrade Level1 = new Upgrade("Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade Level2 = new Upgrade("Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade Level3 = new Upgrade("Level 3", "00FFFF", 80, 40, 40, 40, "70 gems"); // TODO: Figure out Level 3 homing spray.

		public static readonly Death Unknown = new Death("N/A", "444444", -1);
		public static readonly Death Fallen = new Death("FALLEN", "DDDDDD", 0);
		public static readonly Death Swarmed = new Death("SWARMED", "352710", 1);
		public static readonly Death Impaled = new Death("IMPALED", "433114", 2);
		public static readonly Death Infested = new Death("INFESTED", "99A100", 4);
		public static readonly Death Purged = new Death("PURGED", "4E3000", 6);
		public static readonly Death Sacrificed = new Death("SACRIFICED", "804E00", 8);
		public static readonly Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
		public static readonly Death Annihilated = new Death("ANNIHILATED", "BE2C20", 10);
		public static readonly Death Stricken = new Death("STRICKEN", "DCCB00", 16);
		public static readonly Death Devastated = new Death("DEVASTATED", "FF0000", 17);
		public static readonly Death Dismembered = new Death("DISMEMBERED", "804E00", 18);

		public static readonly Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, null, true);
		public static readonly Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Sacrificed, 2, null, true);
		public static readonly Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, null, true);
		public static readonly Enemy Gigapede = new Enemy("Gigapede", "7B5157", 250, 50, Eviscerated, 50, null, true);
		public static readonly Enemy Leviathan = new Enemy("Leviathan", "FF0000", 600, 6, Devastated, 600, null, true);
		public static readonly Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Infested, 3, null, true);

		public static readonly Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, null, true, Squid1, Squid2);
		public static readonly Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, null, true, Squid1);
		public static readonly Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Dismembered, 1, null, true, Squid2);

		public static readonly Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "721A13", 10, 1, Impaled, 1, null, true, Leviathan);
		public static readonly Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "982319", 20, 1, Dismembered, 2, null, true, Leviathan);
		public static readonly Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "BE2C20", 100, 0, Annihilated, 10, null, true, Leviathan);

		public static readonly Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Infested, 3, null, false, Spider1);
		public static readonly Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Stricken, 1, null, true, SpiderEgg1);
	}
}