using System;
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

		public static List<TEntity> GetEntities<TEntity>(params GameVersion[] gameVersions)
			where TEntity : DevilDaggersEntity
		{
			// If no game versions are specified, use all.
			if (gameVersions.Length == 0)
				gameVersions = GameVersions.Values.ToArray();

			List<TEntity> entities = new List<TEntity>();
			foreach (GameVersion gameVersion in gameVersions)
			{
				foreach (FieldInfo field in gameVersion.Type.GetFields())
				{
					if (field.FieldType == typeof(TEntity) || field.FieldType.IsSubclassOf(typeof(TEntity)))
					{
						bool add = true;
						TEntity entity = field.GetValue(field) as TEntity;
						foreach (TEntity e in entities)
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
	}
}