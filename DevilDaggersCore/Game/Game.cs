using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevilDaggersCore.Game
{
	public static class Game
	{
		//public static Death Disintegrated = new Death("DISINTEGRATED", "FF3131", 19); // V3 beta???

		public static class V1
		{
			public static Dagger Default = new Dagger("Default", "444444", null);
			public static Dagger Bronze = new Dagger("Bronze", "CD7F32", 60);
			public static Dagger Silver = new Dagger("Silver", "DDDDDD", 120);
			public static Dagger Golden = new Dagger("Golden", "FFDF00", 250);
			public static Dagger Devil = new Dagger("Devil", "FF0000", 500);

			public static Upgrade Level1 = new Upgrade("Level 1", "BB5500", 20, 10, null, null, "N/A");
			public static Upgrade Level2 = new Upgrade("Level 2", "FFAA00", 40, 20, null, null, "10 gems");
			public static Upgrade Level3 = new Upgrade("Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");

			public static Death Unknown = new Death("N/A", "444444", -1);
			public static Death Fallen = new Death("FALLEN", "DDDDDD", 0);
			public static Death Swarmed = new Death("SWARMED", "352710", 1);
			public static Death Impaled = new Death("IMPALED", "433114", 2);
			public static Death Infested = new Death("INFESTED", "99A100", 4);
			public static Death Purged = new Death("PURGED", "4E3000", 6);
			public static Death Sacrificed = new Death("SACRIFICED", "804E00", 8);
			public static Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
			public static Death Annihilated = new Death("ANNIHILATED", "F00000", 10);
			public static Death Stricken = new Death("STRICKEN", "DCCB00", 16);
			public static Death Devastated = new Death("DEVASTATED", "FF0000", 17);
			public static Death Dismembered = new Death("DISMEMBERED", "804E00", 18);

			public static Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, 1);
			public static Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Sacrificed, 2, 1);
			public static Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, 25);
			public static Enemy Gigapede = new Enemy("Gigapede", "478B41", 250, 50, Eviscerated, 50, 50); //TODO: Different color?
			public static Enemy Leviathan = new Enemy("Leviathan", "FF0000", 1500 /*TODO: A lot less...*/, 6, Devastated, 1500, 1500);
			public static Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Infested, 3, 3);

			public static Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, 0.25f, Squid1, Squid2);
			public static Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, 1, Squid1);
			public static Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Dismembered, 1, 1, Squid2);

			/*In V1, Leviathan turns Skull I into Transmuted Skull II, Skull II into Transmuted Skull III, Skull III into Transmuted Skull IV*/
			public static Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "9B0000", 20, 1/*TODO: ?*/, Impaled, 2, 2, Leviathan);
			public static Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "B80000", 100, 1/*TODO: ?*/, Dismembered, 10, 10, Leviathan);
			public static Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "F00000", 300, 0/*TODO: ?*/, Annihilated, 30, 30, Leviathan);

			public static Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Infested, 3, 3, Spider1);
			public static Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Stricken, 1, 1, SpiderEgg1);
		}

		public static class V2
		{
			public static Dagger Default = new Dagger("Default", "444444", null);
			public static Dagger Bronze = new Dagger("Bronze", "CD7F32", 60);
			public static Dagger Silver = new Dagger("Silver", "DDDDDD", 120);
			public static Dagger Golden = new Dagger("Golden", "FFDF00", 250);
			public static Dagger Devil = new Dagger("Devil", "FF0000", 500);

			public static Upgrade Level1 = new Upgrade("Level 1", "BB5500", 20, 10, null, null, "N/A");
			public static Upgrade Level2 = new Upgrade("Level 2", "FFAA00", 40, 20, null, null, "10 gems");
			public static Upgrade Level3 = new Upgrade("Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
			public static Upgrade Level4 = new Upgrade("Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

			public static Death Unknown = new Death("N/A", "444444", -1);
			public static Death Fallen = new Death("FALLEN", "DDDDDD", 0);
			public static Death Swarmed = new Death("SWARMED", "352710", 1);
			public static Death Impaled = new Death("IMPALED", "433114", 2);
			public static Death Gored = new Death("GORED", "6E5021", 3);
			public static Death Infested = new Death("INFESTED", "99A100", 4);
			public static Death Opened = new Death("OPENED", "976E2E", 5);
			public static Death Purged = new Death("PURGED", "4E3000", 6);
			public static Death Desecrated = new Death("DESECRATED", "804E00", 7);
			public static Death Sacrificed = new Death("SACRIFICED", "AF6B00", 8);
			public static Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
			public static Death Annihilated = new Death("ANNIHILATED", "478B41", 10);
			public static Death Envenmonated = new Death("ENVENMONATED", "657A00", 12);
			public static Death Stricken = new Death("STRICKEN", "DCCB00", 16);
			public static Death Devastated = new Death("DEVASTATED", "FF0000", 17);

			public static Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, 1);
			public static Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Desecrated, 2, 1);
			public static Enemy Squid3 = new Enemy("Squid III", "AF6B00", 90, 3, Sacrificed, 3, 9);
			public static Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, 25);
			public static Enemy Gigapede = new Enemy("Gigapede", "478B41", 250, 50, Annihilated, 50, 50); //TODO: Different color?
			public static Enemy Leviathan = new Enemy("Leviathan", "FF0000", 1500, 6, Devastated, 1500, 1500);
			public static Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Infested, 3, 3);
			public static Enemy Spider2 = new Enemy("Spider II", "13FF00", 200, 1, Envenmonated, 20, 20);

			public static Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, 0.25f, Squid1, Squid2, Squid3);
			public static Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, 1, Squid1);
			public static Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Gored, 1, 1, Squid2);
			public static Enemy Skull4 = new Enemy("Skull IV", "976E2E", 100, 0, Opened, 10, 10, Squid3);

			public static Enemy TransmutedSkull1 = new Enemy("Transmuted Skull I", "7F0000", 10, 0, Swarmed, 0.25f, 10, Leviathan);
			public static Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "9B0000", 20, 1, Impaled, 2, 2, Leviathan);
			public static Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "B80000", 100, 1, Gored, 10, 10, Leviathan);
			public static Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "F00000", 300, 0, Opened, 30, 30, Leviathan);

			public static Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Infested, 3, 3, Spider1);
			public static Enemy SpiderEgg2 = new Enemy("Spider Egg II", "657A00", 3, 0, Envenmonated, 3, 3, Spider2);
			public static Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Stricken, 1, 1, SpiderEgg1, SpiderEgg2);

			public static Enemy Andras = new Enemy("Andras", "666666", 25, 1, Unknown, null, null);
		}

		public static class V3
		{
			public static Dagger Default = new Dagger("Default", "444444", null);
			public static Dagger Bronze = new Dagger("Bronze", "CD7F32", 60);
			public static Dagger Silver = new Dagger("Silver", "DDDDDD", 120);
			public static Dagger Golden = new Dagger("Golden", "FFDF00", 250);
			public static Dagger Devil = new Dagger("Devil", "FF0000", 500);

			public static Upgrade Level1 = new Upgrade("Level 1", "BB5500", 20, 10, null, null, "N/A");
			public static Upgrade Level2 = new Upgrade("Level 2", "FFAA00", 40, 20, null, null, "10 gems");
			public static Upgrade Level3 = new Upgrade("Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
			public static Upgrade Level4 = new Upgrade("Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

			public static Death Unknown = new Death("N/A", "444444", -1);
			public static Death Fallen = new Death("FALLEN", "DDDDDD", 0);
			public static Death Swarmed = new Death("SWARMED", "352710", 1);
			public static Death Impaled = new Death("IMPALED", "433114", 2);
			public static Death Gored = new Death("GORED", "6E5021", 3);
			public static Death Infested = new Death("INFESTED", "DCCB00", 4);
			public static Death Opened = new Death("OPENED", "976E2E", 5);
			public static Death Purged = new Death("PURGED", "4E3000", 6);
			public static Death Desecrated = new Death("DESECRATED", "804E00", 7);
			public static Death Sacrificed = new Death("SACRIFICED", "AF6B00", 8);
			public static Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
			public static Death Annihilated = new Death("ANNIHILATED", "478B41", 10);
			public static Death Intoxicated = new Death("INTOXICATED", "99A100", 11);
			public static Death Envenmonated = new Death("ENVENMONATED", "657A00", 12);
			public static Death Incarnated = new Death("INCARNATED", "FF0000", 13);
			public static Death Discarnated = new Death("DISCARNATED", "FF3131", 14);
			public static Death Barbed = new Death("BARBED", "771D00", 15);

			public static Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, 1);
			public static Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Desecrated, 2, 1);
			public static Enemy Squid3 = new Enemy("Squid III", "AF6B00", 90, 3, Sacrificed, 3, 9);
			public static Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, 25);
			public static Enemy Gigapede = new Enemy("Gigapede", "478B41", 250, 50, Annihilated, 50, 50);
			public static Enemy Ghostpede = new Enemy("Ghostpede", "C8A2C8", 500, 10, Intoxicated, null, null);
			public static Enemy Leviathan = new Enemy("Leviathan", "FF0000", 1500, 6, Incarnated, 1500, 1500);
			public static Enemy Thorn = new Enemy("Thorn", "771D00", 120, 0, Barbed, 12, 12);
			public static Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Intoxicated, 3, 3);
			public static Enemy Spider2 = new Enemy("Spider II", "13FF00", 200, 1, Envenmonated, 20, 20);

			public static Enemy TheOrb = new Enemy("The Orb", "FF3131", 2400, 0, Discarnated /*Disintegrated in V3 Beta?*/, 2400, 2400, Leviathan);

			public static Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, 0.25f, Squid1, Squid2, Squid3);
			public static Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, 1, Squid1);
			public static Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Gored, 1, 1, Squid2);
			public static Enemy Skull4 = new Enemy("Skull IV", "976E2E", 100, 0, Opened, 10, 10, Squid3);

			public static Enemy TransmutedSkull1 = new Enemy("Transmuted Skull I", "7F0000", 10, 0, Swarmed, 0.25f, 10, Leviathan, TheOrb);
			public static Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "9B0000", 20, 1, Impaled, 2, 2, Leviathan, TheOrb);
			public static Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "B80000", 100, 1, Gored, 10, 10, Leviathan, TheOrb);
			public static Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "F00000", 300, 0, Opened, 30, 30, Leviathan, TheOrb);

			public static Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Intoxicated, 3, 3, Spider1);
			public static Enemy SpiderEgg2 = new Enemy("Spider Egg II", "657A00", 3, 0, Envenmonated, 3, 3, Spider2);
			public static Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Infested, 1, 1, SpiderEgg1, SpiderEgg2);
		}

		private static Dictionary<Enemy, string> EnemyInfo { get; set; } = new Dictionary<Enemy, string>
		{
			{ V3.Squid1, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Squid2, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Squid3, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Centipede, "Emerges and flies idly for a while, then starts chasing the player\nRegularly dives down and moves underground for a while" },
			{ V3.Gigapede, "Emerges and starts chasing the player immediately" }, /*TODO: Add V1 behavior and V1 and V2 image*/
			{ V3.Ghostpede, "Emerges and starts flying in circles high above the arena\nAttracts and consumes all homing daggers, making them useless" },
			{ V3.Leviathan, "Attracts and transmutes all skulls every 20 seconds\nRotates counter-clockwise\nDrops The Orb after dying" },
			{ V3.Thorn, "Takes up space" },
			{ V3.Spider1, "Spawns at the edge of the arena and starts lifting its head, then faces the player\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time\nHides its head when shot and left nharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head" },
			{ V3.Spider2, "Spawns at the edge of the arena and starts lifting its head (though much slower than Spider I), then faces the player\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a timenHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" },
			{ V3.Skull1, "Slowly chases the player" },
			{ V3.Skull2, "Moves randomly" },
			{ V3.Skull3, "Chases the player fast" },
			{ V3.Skull4, "Chases the player fast" },
			{ V3.TransmutedSkull1, "Slowly chases the player" },
			{ V3.TransmutedSkull2, "Moves randomly" },
			{ V3.TransmutedSkull3, "Chases the player fast" },
			{ V3.TransmutedSkull4, "Chases the player fast" },
			{ V3.SpiderEgg1, "Hatches into 5 Spiderlings after 10 seconds" },
			{ V3.SpiderEgg2, "Hatches into 5 Spiderlings after 10 seconds" },
			{ V3.Spiderling, "Darts towards the player in bursts with random offsets" },
			{ V3.TheOrb, "Behaves like an eyeball, will look at the player, then attract and transmute all skulls every 2.5 seconds\nBecomes stunned under constant fire, cannot look or attract skulls while stunned" }
		};

		public const string DEFAULT_GAME_VERSION = "V3";

		public static Dictionary<string, GameVersion> GameVersions = new Dictionary<string, GameVersion>
		{
			{ "V1", new GameVersion(typeof(V1), new DateTime(2016, 2, 18)) },
			{ "V2", new GameVersion(typeof(V2), new DateTime(2016, 7, 5)) },
			{ "V3", new GameVersion(typeof(V3), new DateTime(2016, 9, 19)) }
		};

		public static GameVersion GetGameVersionFromDate(DateTime dateTime)
		{
			GameVersion gameVersion = GameVersions["V1"];
			for (int i = 0; i < GameVersions.Count; i++)
			{
				string key = $"V{i + 1}";
				if (GameVersions[key].ReleaseDate < dateTime)
					gameVersion = GameVersions[key];
			}
			return gameVersion;
		}

		public static bool TryGetGameVersionFromString(string gameVersionString, out GameVersion gameVersion)
		{
			if (!string.IsNullOrEmpty(gameVersionString))
				if (GameVersions.TryGetValue(gameVersionString, out gameVersion))
					return true;

			gameVersion = GameVersions[DEFAULT_GAME_VERSION];
			return false;
		}

		public static string GetEnemyInfo(Enemy enemy)
		{
			foreach (KeyValuePair<Enemy, string> kvp in EnemyInfo)
				if (kvp.Key == enemy)
					return kvp.Value;
			throw new Exception($"Could not find enemy info for Enemy with name \"{enemy.Name}\".");
		}

		public static List<T> GetEntities<T>(params GameVersion[] gameVersions)
			where T : DevilDaggersEntity
		{
			// If no game versions are specified, use all
			if (gameVersions.Length == 0)
				gameVersions = GameVersions.Values.ToArray();

			List<T> entities = new List<T>();

			foreach (GameVersion gameVersion in gameVersions)
			{
				foreach (FieldInfo field in gameVersion.Type.GetFields())
				{
					if (field.FieldType == typeof(T))
					{
						bool add = true;
						T entity = field.GetValue(field) as T;
						foreach (T e in entities)
						{
							if (e.Name == entity.Name)
							{
								add = false;
								break;
							}
						}

						if (add)
							entities.Add(entity);
					}
				}
			}

			return entities;
		}

		public static Death GetDeathFromDeathName(string deathName, params GameVersion[] gameVersions)
		{
			try
			{
				return GetEntities<Death>(gameVersions).Where(d => d.Name == deathName).First();
			}
			catch
			{
				//throw new Exception($"Could not parse string \"{deathName}\" to a valid Death object.");
				return V3.Unknown;
			}
		}

		public static Death GetDeathFromDeathType(int deathType, params GameVersion[] gameVersions)
		{
			try
			{
				return GetEntities<Death>(gameVersions).Where(d => d.DeathType == deathType).First();
			}
			catch
			{
				//throw new Exception($"Could not find Death object with death type: {deathType}.");
				return V3.Unknown;
			}
		}

		public static Dagger GetDaggerFromTime(int time)
		{
			List<Dagger> daggers = GetEntities<Dagger>();
			for (int i = daggers.Count - 1; i >= 0; i--)
				if (time >= daggers[i].UnlockSecond * 10000)
					return daggers[i];
			return V3.Default;
		}
	}
}