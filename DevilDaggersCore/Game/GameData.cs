using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Game
{
	public static class GameData
	{
		public static readonly Dagger V1Default = new Dagger(GameVersion.V1, "Default", "444444", null);
		public static readonly Dagger V1Bronze = new Dagger(GameVersion.V1, "Bronze", "CD7F32", 60);
		public static readonly Dagger V1Silver = new Dagger(GameVersion.V1, "Silver", "DDDDDD", 120);
		public static readonly Dagger V1Golden = new Dagger(GameVersion.V1, "Golden", "FFDF00", 250);
		public static readonly Dagger V1Devil = new Dagger(GameVersion.V1, "Devil", "FF0000", 500);

		public static readonly Upgrade V1Level1 = new Upgrade(GameVersion.V1, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V1Level2 = new Upgrade(GameVersion.V1, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V1Level3 = new Upgrade(GameVersion.V1, "Level 3", "00FFFF", 80, 40, 40, 40, "70 gems"); // TODO: Figure out Level 3 homing spray.

		public static readonly Death V1Unknown = new Death(GameVersion.V1, "N/A", "444444", -1);
		public static readonly Death V1Fallen = new Death(GameVersion.V1, "FALLEN", "DDDDDD", 0);
		public static readonly Death V1Swarmed = new Death(GameVersion.V1, "SWARMED", "352710", 1);
		public static readonly Death V1Impaled = new Death(GameVersion.V1, "IMPALED", "433114", 2);
		public static readonly Death V1Infested = new Death(GameVersion.V1, "INFESTED", "99A100", 4);
		public static readonly Death V1Purged = new Death(GameVersion.V1, "PURGED", "4E3000", 6);
		public static readonly Death V1Sacrificed = new Death(GameVersion.V1, "SACRIFICED", "804E00", 8);
		public static readonly Death V1Eviscerated = new Death(GameVersion.V1, "EVISCERATED", "837E75", 9);
		public static readonly Death V1Annihilated = new Death(GameVersion.V1, "ANNIHILATED", "BE2C20", 10);
		public static readonly Death V1Stricken = new Death(GameVersion.V1, "STRICKEN", "DCCB00", 16);
		public static readonly Death V1Devastated = new Death(GameVersion.V1, "DEVASTATED", "FF0000", 17);
		public static readonly Death V1Dismembered = new Death(GameVersion.V1, "DISMEMBERED", "804E00", 18);

		public static readonly Enemy V1Squid1 = new Enemy(GameVersion.V1, "Squid I", "4E3000", 10, 1, 2, V1Purged, 1, null, true);
		public static readonly Enemy V1Squid2 = new Enemy(GameVersion.V1, "Squid II", "804E00", 20, 2, 3, V1Sacrificed, 2, null, true);
		public static readonly Enemy V1Centipede = new Enemy(GameVersion.V1, "Centipede", "837E75", 75, 25, 25, V1Eviscerated, 25, null, true);
		public static readonly Enemy V1Gigapede = new Enemy(GameVersion.V1, "Gigapede", "7B5157", 250, 50, 50, V1Eviscerated, 50, null, true);
		public static readonly Enemy V1Leviathan = new Enemy(GameVersion.V1, "Leviathan", "FF0000", 600, 6, 6, V1Devastated, 600, null, true);
		public static readonly Enemy V1Spider1 = new Enemy(GameVersion.V1, "Spider I", "097A00", 25, 1, 1, V1Infested, 3, null, true);

		public static readonly Enemy V1Skull1 = new Enemy(GameVersion.V1, "Skull I", "352710", 1, 0, 0, V1Swarmed, 0.25f, null, true, V1Squid1, V1Squid2);
		public static readonly Enemy V1Skull2 = new Enemy(GameVersion.V1, "Skull II", "433114", 5, 1, 1, V1Impaled, 1, null, true, V1Squid1);
		public static readonly Enemy V1Skull3 = new Enemy(GameVersion.V1, "Skull III", "6E5021", 10, 1, 1, V1Dismembered, 1, null, true, V1Squid2);

		public static readonly Enemy V1TransmutedSkull2 = new Enemy(GameVersion.V1, "Transmuted Skull II", "721A13", 10, 1, 1, V1Impaled, 1, null, true, V1Leviathan);
		public static readonly Enemy V1TransmutedSkull3 = new Enemy(GameVersion.V1, "Transmuted Skull III", "982319", 20, 1, 1, V1Dismembered, 2, null, true, V1Leviathan);
		public static readonly Enemy V1TransmutedSkull4 = new Enemy(GameVersion.V1, "Transmuted Skull IV", "BE2C20", 100, 0, 0, V1Annihilated, 10, null, true, V1Leviathan);

		public static readonly Enemy V1SpiderEgg1 = new Enemy(GameVersion.V1, "Spider Egg I", "99A100", 3, 0, 0, V1Infested, 3, null, false, V1Spider1);
		public static readonly Enemy V1Spiderling = new Enemy(GameVersion.V1, "Spiderling", "DCCB00", 3, 0, 0, V1Stricken, 1, null, true, V1SpiderEgg1);

		public static readonly Dagger V2Default = new Dagger(GameVersion.V2, "Default", "444444", null);
		public static readonly Dagger V2Bronze = new Dagger(GameVersion.V2, "Bronze", "CD7F32", 60);
		public static readonly Dagger V2Silver = new Dagger(GameVersion.V2, "Silver", "DDDDDD", 120);
		public static readonly Dagger V2Golden = new Dagger(GameVersion.V2, "Golden", "FFDF00", 250);
		public static readonly Dagger V2Devil = new Dagger(GameVersion.V2, "Devil", "FF0000", 500);

		public static readonly Upgrade V2Level1 = new Upgrade(GameVersion.V2, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V2Level2 = new Upgrade(GameVersion.V2, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V2Level3 = new Upgrade(GameVersion.V2, "Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade V2Level4 = new Upgrade(GameVersion.V2, "Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death V2Unknown = new Death(GameVersion.V2, "N/A", "444444", -1);
		public static readonly Death V2Fallen = new Death(GameVersion.V2, "FALLEN", "DDDDDD", 0);
		public static readonly Death V2Swarmed = new Death(GameVersion.V2, "SWARMED", "352710", 1);
		public static readonly Death V2Impaled = new Death(GameVersion.V2, "IMPALED", "433114", 2);
		public static readonly Death V2Gored = new Death(GameVersion.V2, "GORED", "6E5021", 3);
		public static readonly Death V2Infested = new Death(GameVersion.V2, "INFESTED", "99A100", 4);
		public static readonly Death V2Opened = new Death(GameVersion.V2, "OPENED", "976E2E", 5);
		public static readonly Death V2Purged = new Death(GameVersion.V2, "PURGED", "4E3000", 6);
		public static readonly Death V2Desecrated = new Death(GameVersion.V2, "DESECRATED", "804E00", 7);
		public static readonly Death V2Sacrificed = new Death(GameVersion.V2, "SACRIFICED", "AF6B00", 8);
		public static readonly Death V2Eviscerated = new Death(GameVersion.V2, "EVISCERATED", "837E75", 9);
		public static readonly Death V2Annihilated = new Death(GameVersion.V2, "ANNIHILATED", "7B5157", 10);
		public static readonly Death V2Envenomated = new Death(GameVersion.V2, "ENVENOMATED", "657A00", 12);
		public static readonly Death V2Stricken = new Death(GameVersion.V2, "STRICKEN", "DCCB00", 16);
		public static readonly Death V2Devastated = new Death(GameVersion.V2, "DEVASTATED", "FF0000", 17);

		public static readonly Enemy V2Squid1 = new Enemy(GameVersion.V2, "Squid I", "4E3000", 10, 1, 2, V2Purged, 1, 1, true);
		public static readonly Enemy V2Squid2 = new Enemy(GameVersion.V2, "Squid II", "804E00", 20, 2, 3, V2Desecrated, 2, 1, true);
		public static readonly Enemy V2Squid3 = new Enemy(GameVersion.V2, "Squid III", "AF6B00", 90, 3, 3, V2Sacrificed, 3, 9, true);
		public static readonly Enemy V2Centipede = new Enemy(GameVersion.V2, "Centipede", "837E75", 75, 25, 25, V2Eviscerated, 25, 25, true);
		public static readonly Enemy V2Gigapede = new Enemy(GameVersion.V2, "Gigapede", "7B5157", 250, 50, 50, V2Annihilated, 50, 50, true);
		public static readonly Enemy V2Leviathan = new Enemy(GameVersion.V2, "Leviathan", "FF0000", 1500, 6, 6, V2Devastated, 1500, 1500, true);
		public static readonly Enemy V2Spider1 = new Enemy(GameVersion.V2, "Spider I", "097A00", 25, 1, 1, V2Infested, 3, 3, true);
		public static readonly Enemy V2Spider2 = new Enemy(GameVersion.V2, "Spider II", "13FF00", 200, 1, 1, V2Envenomated, 20, 20, true);

		public static readonly Enemy V2Skull1 = new Enemy(GameVersion.V2, "Skull I", "352710", 1, 0, 0, V2Swarmed, 0.25f, 0.25f, true, V2Squid1, V2Squid2, V2Squid3);
		public static readonly Enemy V2Skull2 = new Enemy(GameVersion.V2, "Skull II", "433114", 5, 1, 1, V2Impaled, 1, 1, true, V2Squid1);
		public static readonly Enemy V2Skull3 = new Enemy(GameVersion.V2, "Skull III", "6E5021", 10, 1, 1, V2Gored, 1, 1, true, V2Squid2);
		public static readonly Enemy V2Skull4 = new Enemy(GameVersion.V2, "Skull IV", "976E2E", 100, 0, 0, V2Opened, 10, 10, true, V2Squid3);

		public static readonly Enemy V2TransmutedSkull1 = new Enemy(GameVersion.V2, "Transmuted Skull I", "4C110C", 10, 0, 0, V2Swarmed, 0.25f, 10, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull2 = new Enemy(GameVersion.V2, "Transmuted Skull II", "721A13", 20, 1, 1, V2Impaled, 2, 2, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull3 = new Enemy(GameVersion.V2, "Transmuted Skull III", "982319", 100, 1, 1, V2Gored, 10, 10, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull4 = new Enemy(GameVersion.V2, "Transmuted Skull IV", "BE2C20", 300, 0, 0, V2Opened, 30, 30, true, V2Leviathan);

		public static readonly Enemy V2SpiderEgg1 = new Enemy(GameVersion.V2, "Spider Egg I", "99A100", 3, 0, 0, V2Infested, 3, 3, false, V2Spider1);
		public static readonly Enemy V2SpiderEgg2 = new Enemy(GameVersion.V2, "Spider Egg II", "657A00", 3, 0, 0, V2Envenomated, 3, 3, false, V2Spider2);
		public static readonly Enemy V2Spiderling = new Enemy(GameVersion.V2, "Spiderling", "DCCB00", 3, 0, 0, V2Stricken, 1, 1, true, V2SpiderEgg1, V2SpiderEgg2);

		public static readonly Enemy V2Andras = new Enemy(GameVersion.V2, "Andras", "666666", 25, 1, 1, V2Unknown, null, null, true);

		public static readonly Dagger V3Default = new Dagger(GameVersion.V3, "Default", "444444", null);
		public static readonly Dagger V3Bronze = new Dagger(GameVersion.V3, "Bronze", "CD7F32", 60);
		public static readonly Dagger V3Silver = new Dagger(GameVersion.V3, "Silver", "DDDDDD", 120);
		public static readonly Dagger V3Golden = new Dagger(GameVersion.V3, "Golden", "FFDF00", 250);
		public static readonly Dagger V3Devil = new Dagger(GameVersion.V3, "Devil", "FF0000", 500);

		public static readonly Upgrade V3Level1 = new Upgrade(GameVersion.V3, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V3Level2 = new Upgrade(GameVersion.V3, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V3Level3 = new Upgrade(GameVersion.V3, "Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade V3Level4 = new Upgrade(GameVersion.V3, "Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death V3Unknown = new Death(GameVersion.V3, "N/A", "444444", -1);
		public static readonly Death V3Fallen = new Death(GameVersion.V3, "FALLEN", "DDDDDD", 0);
		public static readonly Death V3Swarmed = new Death(GameVersion.V3, "SWARMED", "352710", 1);
		public static readonly Death V3Impaled = new Death(GameVersion.V3, "IMPALED", "433114", 2);
		public static readonly Death V3Gored = new Death(GameVersion.V3, "GORED", "6E5021", 3);
		public static readonly Death V3Infested = new Death(GameVersion.V3, "INFESTED", "DCCB00", 4);
		public static readonly Death V3Opened = new Death(GameVersion.V3, "OPENED", "976E2E", 5);
		public static readonly Death V3Purged = new Death(GameVersion.V3, "PURGED", "4E3000", 6);
		public static readonly Death V3Desecrated = new Death(GameVersion.V3, "DESECRATED", "804E00", 7);
		public static readonly Death V3Sacrificed = new Death(GameVersion.V3, "SACRIFICED", "AF6B00", 8);
		public static readonly Death V3Eviscerated = new Death(GameVersion.V3, "EVISCERATED", "837E75", 9);
		public static readonly Death V3Annihilated = new Death(GameVersion.V3, "ANNIHILATED", "478B41", 10);
		public static readonly Death V3Intoxicated = new Death(GameVersion.V3, "INTOXICATED", "99A100", 11);
		public static readonly Death V3Envenomated = new Death(GameVersion.V3, "ENVENOMATED", "657A00", 12);
		public static readonly Death V3Incarnated = new Death(GameVersion.V3, "INCARNATED", "FF0000", 13);
		public static readonly Death V3Discarnated = new Death(GameVersion.V3, "DISCARNATED", "FF3131", 14);
		public static readonly Death V3Barbed = new Death(GameVersion.V3, "BARBED", "771D00", 15);

		public static readonly Enemy V3Squid1 = new Enemy(GameVersion.V3, "Squid I", "4E3000", 10, 1, 2, V3Purged, 1, 1, true);
		public static readonly Enemy V3Squid2 = new Enemy(GameVersion.V3, "Squid II", "804E00", 20, 2, 3, V3Desecrated, 2, 1, true);
		public static readonly Enemy V3Squid3 = new Enemy(GameVersion.V3, "Squid III", "AF6B00", 90, 3, 3, V3Sacrificed, 3, 9, true);
		public static readonly Enemy V3Centipede = new Enemy(GameVersion.V3, "Centipede", "837E75", 75, 25, 25, V3Eviscerated, 25, 25, true);
		public static readonly Enemy V3Gigapede = new Enemy(GameVersion.V3, "Gigapede", "478B41", 250, 50, 50, V3Annihilated, 50, 50, true);
		public static readonly Enemy V3Ghostpede = new Enemy(GameVersion.V3, "Ghostpede", "C8A2C8", 500, 10, 10, V3Intoxicated, null, null, true);
		public static readonly Enemy V3Leviathan = new Enemy(GameVersion.V3, "Leviathan", "FF0000", 1500, 6, 6, V3Incarnated, 1500, 1500, true);
		public static readonly Enemy V3Thorn = new Enemy(GameVersion.V3, "Thorn", "771D00", 120, 0, 0, V3Barbed, 12, 12, false);
		public static readonly Enemy V3Spider1 = new Enemy(GameVersion.V3, "Spider I", "097A00", 25, 1, 1, V3Intoxicated, 3, 3, true);
		public static readonly Enemy V3Spider2 = new Enemy(GameVersion.V3, "Spider II", "13FF00", 200, 1, 1, V3Envenomated, 20, 20, true);

		public static readonly Enemy V3TheOrb = new Enemy(GameVersion.V3, "The Orb", "FF3131", 2400, 0, 0, V3Discarnated, 2400, 2400, false, V3Leviathan);

		public static readonly Enemy V3Skull1 = new Enemy(GameVersion.V3, "Skull I", "352710", 1, 0, 0, V3Swarmed, 0.25f, 0.25f, true, V3Squid1, V3Squid2, V3Squid3);
		public static readonly Enemy V3Skull2 = new Enemy(GameVersion.V3, "Skull II", "433114", 5, 1, 1, V3Impaled, 1, 1, true, V3Squid1);
		public static readonly Enemy V3Skull3 = new Enemy(GameVersion.V3, "Skull III", "6E5021", 10, 1, 1, V3Gored, 1, 1, true, V3Squid2);
		public static readonly Enemy V3Skull4 = new Enemy(GameVersion.V3, "Skull IV", "976E2E", 100, 0, 0, V3Opened, 10, 10, true, V3Squid3);

		public static readonly Enemy V3TransmutedSkull1 = new Enemy(GameVersion.V3, "Transmuted Skull I", "4C110C", 10, 0, 0, V3Swarmed, 0.25f, 10, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull2 = new Enemy(GameVersion.V3, "Transmuted Skull II", "721A13", 20, 1, 1, V3Impaled, 2, 2, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull3 = new Enemy(GameVersion.V3, "Transmuted Skull III", "982319", 100, 1, 1, V3Gored, 10, 10, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull4 = new Enemy(GameVersion.V3, "Transmuted Skull IV", "BE2C20", 300, 0, 0, V3Opened, 30, 30, true, V3Leviathan, V3TheOrb);

		public static readonly Enemy V3SpiderEgg1 = new Enemy(GameVersion.V3, "Spider Egg I", "99A100", 3, 0, 0, V3Intoxicated, 3, 3, false, V3Spider1);
		public static readonly Enemy V3SpiderEgg2 = new Enemy(GameVersion.V3, "Spider Egg II", "657A00", 3, 0, 0, V3Envenomated, 3, 3, false, V3Spider2);
		public static readonly Enemy V3Spiderling = new Enemy(GameVersion.V3, "Spiderling", "DCCB00", 3, 0, 0, V3Infested, 1, 1, true, V3SpiderEgg1, V3SpiderEgg2);

		public static readonly IEnumerable<DevilDaggersEntity> Entities = typeof(GameData).GetFields().Where(f => f.FieldType.IsSubclassOf(typeof(DevilDaggersEntity))).Select(f => (DevilDaggersEntity)f.GetValue(null));

		public static Dictionary<Enemy, string[]> EnemyInfo { get; } = new Dictionary<Enemy, string[]>
		{
			{ V1Squid1, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V1Squid2, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V1Centipede, new[] { "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player", "Regularly dives down and moves underground for a while" } },
			{ V1Gigapede, new[] { "Emerges approximately 3 seconds after its spawn, then starts flying around the arena", "Regularly dives down and moves underground for a while" } },
			{ V1Leviathan, new[] { "Activates 8.5333 seconds after its initial appearance", "Attracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)", "Rotates counter-clockwise" } },
			{ V1Spider1, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head" } },
			{ V1Skull1, new[] { "Slowly chases the player" } },
			{ V1Skull2, new[] { "Moves randomly" } },
			{ V1Skull3, new[] { "Chases the player fast" } },
			{ V1TransmutedSkull2, new[] { "Moves randomly" } },
			{ V1TransmutedSkull3, new[] { "Chases the player fast" } },
			{ V1TransmutedSkull4, new[] { "Chases the player fast" } },
			{ V1SpiderEgg1, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V1Spiderling, new[] { "Darts towards the player in bursts with random offsets" } },
			{ V2Squid1, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V2Squid2, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V2Squid3, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V2Centipede, new[] { "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player", "Regularly dives down and moves underground for a while" } },
			{ V2Gigapede, new[] { "Emerges approximately 3 seconds after its spawn, then starts chasing the player immediately" } },
			{ V2Leviathan, new[] { "Activates 8.5333 seconds after its initial appearance", "Attracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)", "Rotates counter-clockwise" } },
			{ V2Spider1, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head" } },
			{ V2Spider2, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 9 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" } },
			{ V2Skull1, new[] { "Slowly chases the player" } },
			{ V2Skull2, new[] { "Moves randomly" } },
			{ V2Skull3, new[] { "Chases the player fast" } },
			{ V2Skull4, new[] { "Chases the player fast" } },
			{ V2TransmutedSkull1, new[] { "Slowly chases the player" } },
			{ V2TransmutedSkull2, new[] { "Moves randomly" } },
			{ V2TransmutedSkull3, new[] { "Chases the player fast" } },
			{ V2TransmutedSkull4, new[] { "Chases the player fast" } },
			{ V2SpiderEgg1, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V2SpiderEgg2, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V2Spiderling, new[] { "Darts towards the player in bursts with random offsets" } },
			{ V2Andras, new[] { "Unfinished enemy that was never added to the real game", "Only appears in V2, can only be spawned using an edited spawnset", "Has its own sounds", "Uses the model for Skull III, but is smaller in size", "Does nothing but attract and consume all homing daggers like Ghostpede ", "Only takes damage when shot from above, so the player will need to daggerjump", "The player doesn't die when touching it" } },
			{ V3Squid1, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V3Squid2, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V3Squid3, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V3Centipede, new[] { "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player", "Regularly dives down and moves underground for a while" } },
			{ V3Gigapede, new[] { "Emerges approximately 3 seconds after its spawn, then starts chasing the player immediately" } },
			{ V3Ghostpede, new[] { "Emerges approximately 3 seconds after its spawn, then starts flying in circles high above the arena", "Attracts and consumes all homing daggers, making them useless" } },
			{ V3Leviathan, new[] { "Activates 8.5333 seconds after its initial appearance", "Attracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)", "Rotates counter-clockwise", "Drops The Orb 3.3167 seconds after dying" } },
			{ V3Thorn, new[] { "Emerges approximately 3 seconds after its spawn", "Takes up space" } },
			{ V3Spider1, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head" } },
			{ V3Spider2, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 9 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" } },
			{ V3Skull1, new[] { "Slowly chases the player" } },
			{ V3Skull2, new[] { "Moves randomly" } },
			{ V3Skull3, new[] { "Chases the player fast" } },
			{ V3Skull4, new[] { "Chases the player fast" } },
			{ V3TransmutedSkull1, new[] { "Slowly chases the player" } },
			{ V3TransmutedSkull2, new[] { "Moves randomly" } },
			{ V3TransmutedSkull3, new[] { "Chases the player fast" } },
			{ V3TransmutedSkull4, new[] { "Chases the player fast" } },
			{ V3SpiderEgg1, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V3SpiderEgg2, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V3Spiderling, new[] { "Darts towards the player in bursts with random offsets" } },
			{ V3TheOrb, new[] { "Activates 10 seconds after Leviathan's death", "Behaves like an eyeball, will look at the player, then attract and transmute all skulls by beckoning every 2.5333 seconds", "Becomes stunned under constant fire, cannot look or attract skulls while stunned" } },
		};
	}
}