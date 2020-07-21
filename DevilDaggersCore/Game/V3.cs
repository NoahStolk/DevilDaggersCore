namespace DevilDaggersCore.Game
{
	public static class V3
	{
		public static readonly Dagger Default = new Dagger("Default", "444444", null);
		public static readonly Dagger Bronze = new Dagger("Bronze", "CD7F32", 60);
		public static readonly Dagger Silver = new Dagger("Silver", "DDDDDD", 120);
		public static readonly Dagger Golden = new Dagger("Golden", "FFDF00", 250);
		public static readonly Dagger Devil = new Dagger("Devil", "FF0000", 500);

		public static readonly Upgrade Level1 = new Upgrade("Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade Level2 = new Upgrade("Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade Level3 = new Upgrade("Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade Level4 = new Upgrade("Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death Unknown = new Death("N/A", "444444", -1);
		public static readonly Death Fallen = new Death("FALLEN", "DDDDDD", 0);
		public static readonly Death Swarmed = new Death("SWARMED", "352710", 1);
		public static readonly Death Impaled = new Death("IMPALED", "433114", 2);
		public static readonly Death Gored = new Death("GORED", "6E5021", 3);
		public static readonly Death Infested = new Death("INFESTED", "DCCB00", 4);
		public static readonly Death Opened = new Death("OPENED", "976E2E", 5);
		public static readonly Death Purged = new Death("PURGED", "4E3000", 6);
		public static readonly Death Desecrated = new Death("DESECRATED", "804E00", 7);
		public static readonly Death Sacrificed = new Death("SACRIFICED", "AF6B00", 8);
		public static readonly Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
		public static readonly Death Annihilated = new Death("ANNIHILATED", "478B41", 10);
		public static readonly Death Intoxicated = new Death("INTOXICATED", "99A100", 11);
		public static readonly Death Envenomated = new Death("ENVENOMATED", "657A00", 12);
		public static readonly Death Incarnated = new Death("INCARNATED", "FF0000", 13);
		public static readonly Death Discarnated = new Death("DISCARNATED", "FF3131", 14);
		public static readonly Death Barbed = new Death("BARBED", "771D00", 15);
		/* public static readonly Death Disintegrated = new Death("DISINTEGRATED", "FF3131", 19); // The Orb in V3 beta??? */

		public static readonly Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, 1, true);
		public static readonly Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Desecrated, 2, 1, true);
		public static readonly Enemy Squid3 = new Enemy("Squid III", "AF6B00", 90, 3, Sacrificed, 3, 9, true);
		public static readonly Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, 25, true);
		public static readonly Enemy Gigapede = new Enemy("Gigapede", "478B41", 250, 50, Annihilated, 50, 50, true);
		public static readonly Enemy Ghostpede = new Enemy("Ghostpede", "C8A2C8", 500, 10, Intoxicated, null, null, true);
		public static readonly Enemy Leviathan = new Enemy("Leviathan", "FF0000", 1500, 6, Incarnated, 1500, 1500, true);
		public static readonly Enemy Thorn = new Enemy("Thorn", "771D00", 120, 0, Barbed, 12, 12, false);
		public static readonly Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Intoxicated, 3, 3, true);
		public static readonly Enemy Spider2 = new Enemy("Spider II", "13FF00", 200, 1, Envenomated, 20, 20, true);

		public static readonly Enemy TheOrb = new Enemy("The Orb", "FF3131", 2400, 0, Discarnated, 2400, 2400, false, Leviathan);

		public static readonly Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, 0.25f, true, Squid1, Squid2, Squid3);
		public static readonly Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, 1, true, Squid1);
		public static readonly Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Gored, 1, 1, true, Squid2);
		public static readonly Enemy Skull4 = new Enemy("Skull IV", "976E2E", 100, 0, Opened, 10, 10, true, Squid3);

		public static readonly Enemy TransmutedSkull1 = new Enemy("Transmuted Skull I", "4C110C", 10, 0, Swarmed, 0.25f, 10, true, Leviathan, TheOrb);
		public static readonly Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "721A13", 20, 1, Impaled, 2, 2, true, Leviathan, TheOrb);
		public static readonly Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "982319", 100, 1, Gored, 10, 10, true, Leviathan, TheOrb);
		public static readonly Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "BE2C20", 300, 0, Opened, 30, 30, true, Leviathan, TheOrb);

		public static readonly Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Intoxicated, 3, 3, false, Spider1);
		public static readonly Enemy SpiderEgg2 = new Enemy("Spider Egg II", "657A00", 3, 0, Envenomated, 3, 3, false, Spider2);
		public static readonly Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Infested, 1, 1, true, SpiderEgg1, SpiderEgg2);
	}
}