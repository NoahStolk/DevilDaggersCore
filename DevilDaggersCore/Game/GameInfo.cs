﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevilDaggersCore.Game
{
	public static class GameInfo
	{
		public const string DefaultGameVersion = "V3";

		// TODO: Change value to string[] to remove hardcoded line breaks.
		private static Dictionary<Enemy, string> EnemyInfo { get; } = new Dictionary<Enemy, string>
		{
			{ V1.Squid1, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V1.Squid2, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V1.Centipede, "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player\nRegularly dives down and moves underground for a while" },
			{ V1.Gigapede, "Emerges approximately 3 seconds after its spawn, then starts flying around the arena\nRegularly dives down and moves underground for a while" },
			{ V1.Leviathan, "Activates 8.5333 seconds after its initial appearance\nAttracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)\nRotates counter-clockwise" },
			{ V1.Spider1, "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time\nHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head" },
			{ V1.Skull1, "Slowly chases the player" },
			{ V1.Skull2, "Moves randomly" },
			{ V1.Skull3, "Chases the player fast" },
			{ V1.TransmutedSkull2, "Moves randomly" },
			{ V1.TransmutedSkull3, "Chases the player fast" },
			{ V1.TransmutedSkull4, "Chases the player fast" },
			{ V1.SpiderEgg1, "Hatches into 5 Spiderlings after 10 seconds" },
			{ V1.Spiderling, "Darts towards the player in bursts with random offsets" },
			{ V2.Squid1, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V2.Squid2, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V2.Squid3, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V2.Centipede, "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player\nRegularly dives down and moves underground for a while" },
			{ V2.Gigapede, "Emerges approximately 3 seconds after its spawn, then starts chasing the player immediately" },
			{ V2.Leviathan, "Activates 8.5333 seconds after its initial appearance\nAttracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)\nRotates counter-clockwise" },
			{ V2.Spider1, "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time\nHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head" },
			{ V2.Spider2, "Spawns at the edge of the arena and starts lifting its head, faces the player after 9 seconds\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a time\nHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" },
			{ V2.Skull1, "Slowly chases the player" },
			{ V2.Skull2, "Moves randomly" },
			{ V2.Skull3, "Chases the player fast" },
			{ V2.Skull4, "Chases the player fast" },
			{ V2.TransmutedSkull1, "Slowly chases the player" },
			{ V2.TransmutedSkull2, "Moves randomly" },
			{ V2.TransmutedSkull3, "Chases the player fast" },
			{ V2.TransmutedSkull4, "Chases the player fast" },
			{ V2.SpiderEgg1, "Hatches into 5 Spiderlings after 10 seconds" },
			{ V2.SpiderEgg2, "Hatches into 5 Spiderlings after 10 seconds" },
			{ V2.Spiderling, "Darts towards the player in bursts with random offsets" },
			{ V2.Andras, "Unfinished enemy that was never added to the real game\nOnly appears in V2, can only be spawned using an edited spawnset\nHas its own sounds\nUses the model for Skull III, but is smaller in size\nDoes nothing but attract and consume all homing daggers like Ghostpede \nOnly takes damage when shot from above, so the player will need to daggerjump\nThe player doesn't die when touching it" },
			{ V3.Squid1, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Squid2, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Squid3, "Spawns at the edge of the arena\nMoves slowly and rotates clockwise\nSpawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" },
			{ V3.Centipede, "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player\nRegularly dives down and moves underground for a while" },
			{ V3.Gigapede, "Emerges approximately 3 seconds after its spawn, then starts chasing the player immediately" },
			{ V3.Ghostpede, "Emerges approximately 3 seconds after its spawn, then starts flying in circles high above the arena\nAttracts and consumes all homing daggers, making them useless" },
			{ V3.Leviathan, "Activates 8.5333 seconds after its initial appearance\nAttracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)\nRotates counter-clockwise\nDrops The Orb 3.3167 seconds after dying" },
			{ V3.Thorn, "Emerges approximately 3 seconds after its spawn\nTakes up space" },
			{ V3.Spider1, "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time\nHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head" },
			{ V3.Spider2, "Spawns at the edge of the arena and starts lifting its head, faces the player after 9 seconds\nAttracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a time\nHides its head when shot and left unharmed for 1 second\nBegins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" },
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
			{ V3.TheOrb, "Activates 10 seconds after Leviathan's death\nBehaves like an eyeball, will look at the player, then attract and transmute all skulls by beckoning every 2.5333 seconds\nBecomes stunned under constant fire, cannot look or attract skulls while stunned" },
		};

		public static Dictionary<string, GameVersion> GameVersions { get; } = new Dictionary<string, GameVersion>
		{
			{ "V1", new GameVersion(typeof(V1), new DateTime(2016, 2, 18)) },
			{ "V2", new GameVersion(typeof(V2), new DateTime(2016, 7, 5)) },
			{ "V3", new GameVersion(typeof(V3), new DateTime(2016, 9, 19)) },
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
			{
				if (GameVersions.TryGetValue(gameVersionString, out gameVersion))
					return true;
			}

			gameVersion = GameVersions[DefaultGameVersion];
			return false;
		}

		public static string GetEnemyInfo(Enemy enemy)
		{
			foreach (KeyValuePair<Enemy, string> kvp in EnemyInfo)
			{
				if (kvp.Key == enemy)
					return kvp.Value;
			}

			throw new Exception($"Could not find enemy info for {nameof(Enemy)} with name '{enemy.Name}'.");
		}

		public static List<T> GetEntities<T>(params GameVersion[] gameVersions)
			where T : DevilDaggersEntity
		{
			// If no game versions are specified, use all.
			if (gameVersions.Length == 0)
				gameVersions = GameVersions.Values.ToArray();

			List<T> entities = new List<T>();

			foreach (GameVersion gameVersion in gameVersions)
			{
				foreach (FieldInfo field in gameVersion.Type.GetFields())
				{
					if (field.FieldType == typeof(T) || field.FieldType.IsSubclassOf(typeof(T)))
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

		public static IEnumerable<(string gameVersion, TEntity entity)> GetEntitiesWithGameVersion<TEntity>()
			where TEntity : DevilDaggersEntity
		{
			foreach (KeyValuePair<string, GameVersion> gameVersion in GameVersions)
			{
				foreach (FieldInfo field in gameVersion.Value.Type.GetFields())
				{
					if (field.FieldType == typeof(TEntity) || field.FieldType.IsSubclassOf(typeof(TEntity)))
						yield return (gameVersion.Key, field.GetValue(field) as TEntity);
				}
			}
		}

		public static Death GetDeathFromDeathName(string deathName, params GameVersion[] gameVersions)
		{
			Death death = GetEntities<Death>(gameVersions).FirstOrDefault(d => d.Name == deathName);
			if (death != null)
				return death;
			return V3.Unknown;
		}

		public static Death GetDeathFromDeathType(int deathType, params GameVersion[] gameVersions)
		{
			Death death = GetEntities<Death>(gameVersions).FirstOrDefault(d => d.DeathType == deathType);
			if (death != null)
				return death;
			return V3.Unknown;
		}

		public static Dagger GetDaggerFromTime(int time)
		{
			List<Dagger> daggers = GetEntities<Dagger>();
			for (int i = daggers.Count - 1; i >= 0; i--)
			{
				if (time >= daggers[i].UnlockSecond * 10000)
					return daggers[i];
			}

			return V3.Default;
		}

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

		public static class V2
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
			public static readonly Death Infested = new Death("INFESTED", "99A100", 4);
			public static readonly Death Opened = new Death("OPENED", "976E2E", 5);
			public static readonly Death Purged = new Death("PURGED", "4E3000", 6);
			public static readonly Death Desecrated = new Death("DESECRATED", "804E00", 7);
			public static readonly Death Sacrificed = new Death("SACRIFICED", "AF6B00", 8);
			public static readonly Death Eviscerated = new Death("EVISCERATED", "837E75", 9);
			public static readonly Death Annihilated = new Death("ANNIHILATED", "7B5157", 10);
			public static readonly Death Envenomated = new Death("ENVENOMATED", "657A00", 12);
			public static readonly Death Stricken = new Death("STRICKEN", "DCCB00", 16);
			public static readonly Death Devastated = new Death("DEVASTATED", "FF0000", 17);

			public static readonly Enemy Squid1 = new Enemy("Squid I", "4E3000", 10, 1, Purged, 1, 1, true);
			public static readonly Enemy Squid2 = new Enemy("Squid II", "804E00", 20, 2, Desecrated, 2, 1, true);
			public static readonly Enemy Squid3 = new Enemy("Squid III", "AF6B00", 90, 3, Sacrificed, 3, 9, true);
			public static readonly Enemy Centipede = new Enemy("Centipede", "837E75", 75, 25, Eviscerated, 25, 25, true);
			public static readonly Enemy Gigapede = new Enemy("Gigapede", "7B5157", 250, 50, Annihilated, 50, 50, true);
			public static readonly Enemy Leviathan = new Enemy("Leviathan", "FF0000", 1500, 6, Devastated, 1500, 1500, true);
			public static readonly Enemy Spider1 = new Enemy("Spider I", "097A00", 25, 1, Infested, 3, 3, true);
			public static readonly Enemy Spider2 = new Enemy("Spider II", "13FF00", 200, 1, Envenomated, 20, 20, true);

			public static readonly Enemy Skull1 = new Enemy("Skull I", "352710", 1, 0, Swarmed, 0.25f, 0.25f, true, Squid1, Squid2, Squid3);
			public static readonly Enemy Skull2 = new Enemy("Skull II", "433114", 5, 1, Impaled, 1, 1, true, Squid1);
			public static readonly Enemy Skull3 = new Enemy("Skull III", "6E5021", 10, 1, Gored, 1, 1, true, Squid2);
			public static readonly Enemy Skull4 = new Enemy("Skull IV", "976E2E", 100, 0, Opened, 10, 10, true, Squid3);

			public static readonly Enemy TransmutedSkull1 = new Enemy("Transmuted Skull I", "4C110C", 10, 0, Swarmed, 0.25f, 10, true, Leviathan);
			public static readonly Enemy TransmutedSkull2 = new Enemy("Transmuted Skull II", "721A13", 20, 1, Impaled, 2, 2, true, Leviathan);
			public static readonly Enemy TransmutedSkull3 = new Enemy("Transmuted Skull III", "982319", 100, 1, Gored, 10, 10, true, Leviathan);
			public static readonly Enemy TransmutedSkull4 = new Enemy("Transmuted Skull IV", "BE2C20", 300, 0, Opened, 30, 30, true, Leviathan);

			public static readonly Enemy SpiderEgg1 = new Enemy("Spider Egg I", "99A100", 3, 0, Infested, 3, 3, false, Spider1);
			public static readonly Enemy SpiderEgg2 = new Enemy("Spider Egg II", "657A00", 3, 0, Envenomated, 3, 3, false, Spider2);
			public static readonly Enemy Spiderling = new Enemy("Spiderling", "DCCB00", 3, 0, Stricken, 1, 1, true, SpiderEgg1, SpiderEgg2);

			public static readonly Enemy Andras = new Enemy("Andras", "666666", 25, 1, Unknown, null, null, true);
		}

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
}