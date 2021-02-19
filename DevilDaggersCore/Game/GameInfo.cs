using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DevilDaggersCore.Game
{
	public static class GameInfo
	{
		#region V1

		public static readonly Dagger V1Default = new(GameVersion.V1, "Default", "444444", null);
		public static readonly Dagger V1Bronze = new(GameVersion.V1, "Bronze", "CD7F32", 60);
		public static readonly Dagger V1Silver = new(GameVersion.V1, "Silver", "DDDDDD", 120);
		public static readonly Dagger V1Golden = new(GameVersion.V1, "Golden", "FFDF00", 250);
		public static readonly Dagger V1Devil = new(GameVersion.V1, "Devil", "FF0000", 500);

		public static readonly Upgrade V1Level1 = new(GameVersion.V1, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V1Level2 = new(GameVersion.V1, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V1Level3 = new(GameVersion.V1, "Level 3", "00FFFF", 80, 40, 40, 40, "70 gems"); // TODO: Figure out Level 3 homing spray.

		public static readonly Death V1Fallen = new(GameVersion.V1, "FALLEN", "DDDDDD", 0);
		public static readonly Death V1Swarmed = new(GameVersion.V1, "SWARMED", "352710", 1);
		public static readonly Death V1Impaled = new(GameVersion.V1, "IMPALED", "433114", 2);
		public static readonly Death V1Infested = new(GameVersion.V1, "INFESTED", "99A100", 4);
		public static readonly Death V1Purged = new(GameVersion.V1, "PURGED", "4E3000", 6);
		public static readonly Death V1Sacrificed = new(GameVersion.V1, "SACRIFICED", "804E00", 8);
		public static readonly Death V1Eviscerated = new(GameVersion.V1, "EVISCERATED", "837E75", 9);
		public static readonly Death V1Annihilated = new(GameVersion.V1, "ANNIHILATED", "BE2C20", 10);
		public static readonly Death V1Stricken = new(GameVersion.V1, "STRICKEN", "DCCB00", 16);
		public static readonly Death V1Devastated = new(GameVersion.V1, "DEVASTATED", "FF0000", 17);
		public static readonly Death V1Dismembered = new(GameVersion.V1, "DISMEMBERED", "804E00", 18);

		public static readonly Enemy V1Squid1 = new(GameVersion.V1, "Squid I", "4E3000", 10, 1, 2, 0x0, V1Purged, 1, null, true);
		public static readonly Enemy V1Squid2 = new(GameVersion.V1, "Squid II", "804E00", 20, 2, 3, 0x1, V1Sacrificed, 2, null, true);
		public static readonly Enemy V1Centipede = new(GameVersion.V1, "Centipede", "837E75", 75, 25, 25, 0x2, V1Eviscerated, 25, null, true);
		public static readonly Enemy V1Gigapede = new(GameVersion.V1, "Gigapede", "7B5157", 250, 50, 50, 0x5, V1Eviscerated, 50, null, true);
		public static readonly Enemy V1Leviathan = new(GameVersion.V1, "Leviathan", "FF0000", 600, 6, 6, 0x4, V1Devastated, 600, null, true);
		public static readonly Enemy V1Spider1 = new(GameVersion.V1, "Spider I", "097A00", 25, 1, 1, 0x3, V1Infested, 3, null, true);

		public static readonly Enemy V1Skull1 = new(GameVersion.V1, "Skull I", "352710", 1, 0, 0, null, V1Swarmed, 0.25f, null, true, V1Squid1, V1Squid2);
		public static readonly Enemy V1Skull2 = new(GameVersion.V1, "Skull II", "433114", 5, 1, 1, null, V1Impaled, 1, null, true, V1Squid1);
		public static readonly Enemy V1Skull3 = new(GameVersion.V1, "Skull III", "6E5021", 10, 1, 1, null, V1Dismembered, 1, null, true, V1Squid2);

		public static readonly Enemy V1TransmutedSkull2 = new(GameVersion.V1, "Transmuted Skull II", "721A13", 10, 1, 1, null, V1Impaled, 1, null, true, V1Leviathan);
		public static readonly Enemy V1TransmutedSkull3 = new(GameVersion.V1, "Transmuted Skull III", "982319", 20, 1, 1, null, V1Dismembered, 2, null, true, V1Leviathan);
		public static readonly Enemy V1TransmutedSkull4 = new(GameVersion.V1, "Transmuted Skull IV", "BE2C20", 100, 0, 0, null, V1Annihilated, 10, null, true, V1Leviathan);

		public static readonly Enemy V1SpiderEgg1 = new(GameVersion.V1, "Spider Egg I", "99A100", 3, 0, 0, null, V1Infested, 3, null, false, V1Spider1);
		public static readonly Enemy V1Spiderling = new(GameVersion.V1, "Spiderling", "DCCB00", 3, 0, 0, null, V1Stricken, 1, null, true, V1SpiderEgg1);

		#endregion V1

		#region V2

		public static readonly Dagger V2Default = new(GameVersion.V2, "Default", "444444", null);
		public static readonly Dagger V2Bronze = new(GameVersion.V2, "Bronze", "CD7F32", 60);
		public static readonly Dagger V2Silver = new(GameVersion.V2, "Silver", "DDDDDD", 120);
		public static readonly Dagger V2Golden = new(GameVersion.V2, "Golden", "FFDF00", 250);
		public static readonly Dagger V2Devil = new(GameVersion.V2, "Devil", "FF0000", 500);

		public static readonly Upgrade V2Level1 = new(GameVersion.V2, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V2Level2 = new(GameVersion.V2, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V2Level3 = new(GameVersion.V2, "Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade V2Level4 = new(GameVersion.V2, "Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death V2Fallen = new(GameVersion.V2, "FALLEN", "DDDDDD", 0);
		public static readonly Death V2Swarmed = new(GameVersion.V2, "SWARMED", "352710", 1);
		public static readonly Death V2Impaled = new(GameVersion.V2, "IMPALED", "433114", 2);
		public static readonly Death V2Gored = new(GameVersion.V2, "GORED", "6E5021", 3);
		public static readonly Death V2Infested = new(GameVersion.V2, "INFESTED", "99A100", 4);
		public static readonly Death V2Opened = new(GameVersion.V2, "OPENED", "976E2E", 5);
		public static readonly Death V2Purged = new(GameVersion.V2, "PURGED", "4E3000", 6);
		public static readonly Death V2Desecrated = new(GameVersion.V2, "DESECRATED", "804E00", 7);
		public static readonly Death V2Sacrificed = new(GameVersion.V2, "SACRIFICED", "AF6B00", 8);
		public static readonly Death V2Eviscerated = new(GameVersion.V2, "EVISCERATED", "837E75", 9);
		public static readonly Death V2Annihilated = new(GameVersion.V2, "ANNIHILATED", "7B5157", 10);
		public static readonly Death V2Envenomated = new(GameVersion.V2, "ENVENOMATED", "657A00", 12);
		public static readonly Death V2Stricken = new(GameVersion.V2, "STRICKEN", "DCCB00", 16);
		public static readonly Death V2Devastated = new(GameVersion.V2, "DEVASTATED", "FF0000", 17);

		public static readonly Enemy V2Squid1 = new(GameVersion.V2, "Squid I", "4E3000", 10, 1, 2, 0x0, V2Purged, 1, 1, true);
		public static readonly Enemy V2Squid2 = new(GameVersion.V2, "Squid II", "804E00", 20, 2, 3, 0x1, V2Desecrated, 2, 1, true);
		public static readonly Enemy V2Squid3 = new(GameVersion.V2, "Squid III", "AF6B00", 90, 3, 3, 0x6, V2Sacrificed, 3, 9, true);
		public static readonly Enemy V2Centipede = new(GameVersion.V2, "Centipede", "837E75", 75, 25, 25, 0x2, V2Eviscerated, 25, 25, true);
		public static readonly Enemy V2Gigapede = new(GameVersion.V2, "Gigapede", "7B5157", 250, 50, 50, 0x5, V2Annihilated, 50, 50, true);
		public static readonly Enemy V2Leviathan = new(GameVersion.V2, "Leviathan", "FF0000", 1500, 6, 6, 0x4, V2Devastated, 1500, 1500, true);
		public static readonly Enemy V2Spider1 = new(GameVersion.V2, "Spider I", "097A00", 25, 1, 1, 0x3, V2Infested, 3, 3, true);
		public static readonly Enemy V2Spider2 = new(GameVersion.V2, "Spider II", "13FF00", 200, 1, 1, 0x8, V2Envenomated, 20, 20, true);

		public static readonly Enemy V2Skull1 = new(GameVersion.V2, "Skull I", "352710", 1, 0, 0, null, V2Swarmed, 0.25f, 0.25f, true, V2Squid1, V2Squid2, V2Squid3);
		public static readonly Enemy V2Skull2 = new(GameVersion.V2, "Skull II", "433114", 5, 1, 1, null, V2Impaled, 1, 1, true, V2Squid1);
		public static readonly Enemy V2Skull3 = new(GameVersion.V2, "Skull III", "6E5021", 10, 1, 1, null, V2Gored, 1, 1, true, V2Squid2);
		public static readonly Enemy V2Skull4 = new(GameVersion.V2, "Skull IV", "976E2E", 100, 0, 0, null, V2Opened, 10, 10, true, V2Squid3);

		public static readonly Enemy V2TransmutedSkull1 = new(GameVersion.V2, "Transmuted Skull I", "4C110C", 10, 0, 0, null, V2Swarmed, 0.25f, 10, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull2 = new(GameVersion.V2, "Transmuted Skull II", "721A13", 20, 1, 1, null, V2Impaled, 2, 2, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull3 = new(GameVersion.V2, "Transmuted Skull III", "982319", 100, 1, 1, null, V2Gored, 10, 10, true, V2Leviathan);
		public static readonly Enemy V2TransmutedSkull4 = new(GameVersion.V2, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, V2Opened, 30, 30, true, V2Leviathan);

		public static readonly Enemy V2SpiderEgg1 = new(GameVersion.V2, "Spider Egg I", "99A100", 3, 0, 0, null, V2Infested, 3, 3, false, V2Spider1);
		public static readonly Enemy V2SpiderEgg2 = new(GameVersion.V2, "Spider Egg II", "657A00", 3, 0, 0, null, V2Envenomated, 3, 3, false, V2Spider2);
		public static readonly Enemy V2Spiderling = new(GameVersion.V2, "Spiderling", "DCCB00", 3, 0, 0, null, V2Stricken, 1, 1, true, V2SpiderEgg1, V2SpiderEgg2);

		public static readonly Enemy V2Andras = new(GameVersion.V2, "Andras", "666666", 25, 1, 1, 0x7, null, null, null, true);

		#endregion V2

		#region V3

		public static readonly Dagger V3Default = new(GameVersion.V3, "Default", "444444", null);
		public static readonly Dagger V3Bronze = new(GameVersion.V3, "Bronze", "CD7F32", 60);
		public static readonly Dagger V3Silver = new(GameVersion.V3, "Silver", "DDDDDD", 120);
		public static readonly Dagger V3Golden = new(GameVersion.V3, "Golden", "FFDF00", 250);
		public static readonly Dagger V3Devil = new(GameVersion.V3, "Devil", "FF0000", 500);

		public static readonly Upgrade V3Level1 = new(GameVersion.V3, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V3Level2 = new(GameVersion.V3, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V3Level3 = new(GameVersion.V3, "Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade V3Level4 = new(GameVersion.V3, "Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death V3Fallen = new(GameVersion.V3, "FALLEN", "DDDDDD", 0);
		public static readonly Death V3Swarmed = new(GameVersion.V3, "SWARMED", "352710", 1);
		public static readonly Death V3Impaled = new(GameVersion.V3, "IMPALED", "433114", 2);
		public static readonly Death V3Gored = new(GameVersion.V3, "GORED", "6E5021", 3);
		public static readonly Death V3Infested = new(GameVersion.V3, "INFESTED", "DCCB00", 4);
		public static readonly Death V3Opened = new(GameVersion.V3, "OPENED", "976E2E", 5);
		public static readonly Death V3Purged = new(GameVersion.V3, "PURGED", "4E3000", 6);
		public static readonly Death V3Desecrated = new(GameVersion.V3, "DESECRATED", "804E00", 7);
		public static readonly Death V3Sacrificed = new(GameVersion.V3, "SACRIFICED", "AF6B00", 8);
		public static readonly Death V3Eviscerated = new(GameVersion.V3, "EVISCERATED", "837E75", 9);
		public static readonly Death V3Annihilated = new(GameVersion.V3, "ANNIHILATED", "478B41", 10);
		public static readonly Death V3Intoxicated = new(GameVersion.V3, "INTOXICATED", "99A100", 11);
		public static readonly Death V3Envenomated = new(GameVersion.V3, "ENVENOMATED", "657A00", 12);
		public static readonly Death V3Incarnated = new(GameVersion.V3, "INCARNATED", "FF0000", 13);
		public static readonly Death V3Discarnated = new(GameVersion.V3, "DISCARNATED", "FF3131", 14);
		public static readonly Death V3Barbed = new(GameVersion.V3, "BARBED", "771D00", 15);

		public static readonly Enemy V3Squid1 = new(GameVersion.V3, "Squid I", "4E3000", 10, 1, 2, 0x0, V3Purged, 1, 1, true);
		public static readonly Enemy V3Squid2 = new(GameVersion.V3, "Squid II", "804E00", 20, 2, 3, 0x1, V3Desecrated, 2, 1, true);
		public static readonly Enemy V3Squid3 = new(GameVersion.V3, "Squid III", "AF6B00", 90, 3, 3, 0x6, V3Sacrificed, 3, 9, true);
		public static readonly Enemy V3Centipede = new(GameVersion.V3, "Centipede", "837E75", 75, 25, 25, 0x2, V3Eviscerated, 25, 25, true);
		public static readonly Enemy V3Gigapede = new(GameVersion.V3, "Gigapede", "478B41", 250, 50, 50, 0x5, V3Annihilated, 50, 50, true);
		public static readonly Enemy V3Ghostpede = new(GameVersion.V3, "Ghostpede", "C8A2C8", 500, 10, 10, 0x9, V3Intoxicated, null, null, true);
		public static readonly Enemy V3Leviathan = new(GameVersion.V3, "Leviathan", "FF0000", 1500, 6, 6, 0x4, V3Incarnated, 1500, 1500, true);
		public static readonly Enemy V3Thorn = new(GameVersion.V3, "Thorn", "771D00", 120, 0, 0, 0x7, V3Barbed, 12, 12, false);
		public static readonly Enemy V3Spider1 = new(GameVersion.V3, "Spider I", "097A00", 25, 1, 1, 0x3, V3Intoxicated, 3, 3, true);
		public static readonly Enemy V3Spider2 = new(GameVersion.V3, "Spider II", "13FF00", 200, 1, 1, 0x8, V3Envenomated, 20, 20, true);

		public static readonly Enemy V3TheOrb = new(GameVersion.V3, "The Orb", "FF3131", 2400, 0, 0, null, V3Discarnated, 2400, 2400, false, V3Leviathan);

		public static readonly Enemy V3Skull1 = new(GameVersion.V3, "Skull I", "352710", 1, 0, 0, null, V3Swarmed, 0.25f, 0.25f, true, V3Squid1, V3Squid2, V3Squid3);
		public static readonly Enemy V3Skull2 = new(GameVersion.V3, "Skull II", "433114", 5, 1, 1, null, V3Impaled, 1, 1, true, V3Squid1);
		public static readonly Enemy V3Skull3 = new(GameVersion.V3, "Skull III", "6E5021", 10, 1, 1, null, V3Gored, 1, 1, true, V3Squid2);
		public static readonly Enemy V3Skull4 = new(GameVersion.V3, "Skull IV", "976E2E", 100, 0, 0, null, V3Opened, 10, 10, true, V3Squid3);

		public static readonly Enemy V3TransmutedSkull1 = new(GameVersion.V3, "Transmuted Skull I", "4C110C", 10, 0, 0, null, V3Swarmed, 0.25f, 10, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull2 = new(GameVersion.V3, "Transmuted Skull II", "721A13", 20, 1, 1, null, V3Impaled, 2, 2, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull3 = new(GameVersion.V3, "Transmuted Skull III", "982319", 100, 1, 1, null, V3Gored, 10, 10, true, V3Leviathan, V3TheOrb);
		public static readonly Enemy V3TransmutedSkull4 = new(GameVersion.V3, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, V3Opened, 30, 30, true, V3Leviathan, V3TheOrb);

		public static readonly Enemy V3SpiderEgg1 = new(GameVersion.V3, "Spider Egg I", "99A100", 3, 0, 0, null, V3Intoxicated, 3, 3, false, V3Spider1);
		public static readonly Enemy V3SpiderEgg2 = new(GameVersion.V3, "Spider Egg II", "657A00", 3, 0, 0, null, V3Envenomated, 3, 3, false, V3Spider2);
		public static readonly Enemy V3Spiderling = new(GameVersion.V3, "Spiderling", "DCCB00", 3, 0, 0, null, V3Infested, 1, 1, true, V3SpiderEgg1, V3SpiderEgg2);

		#endregion V3

		#region V3.1

		public static readonly Dagger V31Default = new(GameVersion.V31, "Default", "444444", null);
		public static readonly Dagger V31Bronze = new(GameVersion.V31, "Bronze", "CD7F32", 60);
		public static readonly Dagger V31Silver = new(GameVersion.V31, "Silver", "DDDDDD", 120);
		public static readonly Dagger V31Golden = new(GameVersion.V31, "Golden", "FFDF00", 250);
		public static readonly Dagger V31Devil = new(GameVersion.V31, "Devil", "FF0000", 500);
		public static readonly Dagger V31LeviathanDagger = new(GameVersion.V31, "Leviathan", "A00000", 1000);

		public static readonly Upgrade V31Level1 = new(GameVersion.V31, "Level 1", "BB5500", 20, 10, null, null, "N/A");
		public static readonly Upgrade V31Level2 = new(GameVersion.V31, "Level 2", "FFAA00", 40, 20, null, null, "10 gems");
		public static readonly Upgrade V31Level3 = new(GameVersion.V31, "Level 3", "00FFFF", 80, 40, 40, 20, "70 gems");
		public static readonly Upgrade V31Level4 = new(GameVersion.V31, "Level 4", "FF0099", 106f + 2f / 3f, 60, 40, 30, "150 stored homing daggers");

		public static readonly Death V31Fallen = new(GameVersion.V31, "FALLEN", "DDDDDD", 0);
		public static readonly Death V31Swarmed = new(GameVersion.V31, "SWARMED", "352710", 1);
		public static readonly Death V31Impaled = new(GameVersion.V31, "IMPALED", "433114", 2);
		public static readonly Death V31Gored = new(GameVersion.V31, "GORED", "6E5021", 3);
		public static readonly Death V31Infested = new(GameVersion.V31, "INFESTED", "DCCB00", 4);
		public static readonly Death V31Opened = new(GameVersion.V31, "OPENED", "976E2E", 5);
		public static readonly Death V31Purged = new(GameVersion.V31, "PURGED", "4E3000", 6);
		public static readonly Death V31Desecrated = new(GameVersion.V31, "DESECRATED", "804E00", 7);
		public static readonly Death V31Sacrificed = new(GameVersion.V31, "SACRIFICED", "AF6B00", 8);
		public static readonly Death V31Eviscerated = new(GameVersion.V31, "EVISCERATED", "837E75", 9);
		public static readonly Death V31Annihilated = new(GameVersion.V31, "ANNIHILATED", "478B41", 10);
		public static readonly Death V31Intoxicated = new(GameVersion.V31, "INTOXICATED", "99A100", 11);
		public static readonly Death V31Envenomated = new(GameVersion.V31, "ENVENOMATED", "657A00", 12);
		public static readonly Death V31Incarnated = new(GameVersion.V31, "INCARNATED", "FF0000", 13);
		public static readonly Death V31Discarnated = new(GameVersion.V31, "DISCARNATED", "FF3131", 14);
		public static readonly Death V31Entangled = new(GameVersion.V31, "ENTANGLED", "771D00", 15);
		public static readonly Death V31Haunted = new(GameVersion.V31, "HAUNTED", "C8A2C8", 16);

		public static readonly Enemy V31Squid1 = new(GameVersion.V31, "Squid I", "4E3000", 10, 1, 2, 0x0, V31Purged, 1, 1, true);
		public static readonly Enemy V31Squid2 = new(GameVersion.V31, "Squid II", "804E00", 20, 2, 3, 0x1, V31Desecrated, 2, 1, true);
		public static readonly Enemy V31Squid3 = new(GameVersion.V31, "Squid III", "AF6B00", 90, 3, 3, 0x6, V31Sacrificed, 3, 9, true);
		public static readonly Enemy V31Centipede = new(GameVersion.V31, "Centipede", "837E75", 75, 25, 25, 0x2, V31Eviscerated, 25, 25, true);
		public static readonly Enemy V31Gigapede = new(GameVersion.V31, "Gigapede", "478B41", 250, 50, 50, 0x5, V31Annihilated, 50, 50, true);
		public static readonly Enemy V31Ghostpede = new(GameVersion.V31, "Ghostpede", "C8A2C8", 500, 10, 10, 0x9, V31Haunted, null, null, true);
		public static readonly Enemy V31Leviathan = new(GameVersion.V31, "Leviathan", "FF0000", 1500, 6, 6, 0x4, V31Incarnated, 1500, 1500, true);
		public static readonly Enemy V31Thorn = new(GameVersion.V31, "Thorn", "771D00", 120, 0, 0, 0x7, V31Entangled, 12, 12, false);
		public static readonly Enemy V31Spider1 = new(GameVersion.V31, "Spider I", "097A00", 25, 1, 1, 0x3, V31Intoxicated, 3, 3, true);
		public static readonly Enemy V31Spider2 = new(GameVersion.V31, "Spider II", "13FF00", 200, 1, 1, 0x8, V31Envenomated, 20, 20, true);

		public static readonly Enemy V31TheOrb = new(GameVersion.V31, "The Orb", "FF3131", 2400, 0, 0, null, V31Discarnated, 2400, 2400, false, V31Leviathan);

		public static readonly Enemy V31Skull1 = new(GameVersion.V31, "Skull I", "352710", 1, 0, 0, null, V31Swarmed, 0.25f, 0.25f, true, V31Squid1, V31Squid2, V31Squid3);
		public static readonly Enemy V31Skull2 = new(GameVersion.V31, "Skull II", "433114", 5, 1, 1, null, V31Impaled, 1, 1, true, V31Squid1);
		public static readonly Enemy V31Skull3 = new(GameVersion.V31, "Skull III", "6E5021", 10, 1, 1, null, V31Gored, 1, 1, true, V31Squid2);
		public static readonly Enemy V31Skull4 = new(GameVersion.V31, "Skull IV", "976E2E", 100, 0, 0, null, V31Opened, 10, 10, true, V31Squid3);

		public static readonly Enemy V31TransmutedSkull1 = new(GameVersion.V31, "Transmuted Skull I", "4C110C", 10, 0, 0, null, V31Swarmed, 0.25f, 10, true, V31Leviathan, V31TheOrb);
		public static readonly Enemy V31TransmutedSkull2 = new(GameVersion.V31, "Transmuted Skull II", "721A13", 20, 1, 1, null, V31Impaled, 2, 2, true, V31Leviathan, V31TheOrb);
		public static readonly Enemy V31TransmutedSkull3 = new(GameVersion.V31, "Transmuted Skull III", "982319", 100, 1, 1, null, V31Gored, 10, 10, true, V31Leviathan, V31TheOrb);
		public static readonly Enemy V31TransmutedSkull4 = new(GameVersion.V31, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, V31Opened, 30, 30, true, V31Leviathan, V31TheOrb);

		public static readonly Enemy V31SpiderEgg1 = new(GameVersion.V31, "Spider Egg I", "99A100", 3, 0, 0, null, V31Intoxicated, 3, 3, false, V31Spider1);
		public static readonly Enemy V31SpiderEgg2 = new(GameVersion.V31, "Spider Egg II", "657A00", 3, 0, 0, null, V31Envenomated, 3, 3, false, V31Spider2);
		public static readonly Enemy V31Spiderling = new(GameVersion.V31, "Spiderling", "DCCB00", 3, 0, 0, null, V31Infested, 1, 1, true, V31SpiderEgg1, V31SpiderEgg2);

		#endregion V3.1

		public static readonly IEnumerable<DevilDaggersEntity> Entities = typeof(GameInfo).GetFields().Where(f => f.FieldType.IsSubclassOf(typeof(DevilDaggersEntity))).Select(f => (DevilDaggersEntity)f.GetValue(null)!);

		private static readonly Dictionary<Enemy, string[]> _enemyInfo = new()
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
			{ V31Squid1, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull II every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V31Squid2, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 10 Skull Is and 1 Skull III every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V31Squid3, new[] { "Spawns at the edge of the arena", "Moves slowly and rotates clockwise", "Spawns 15 Skull Is and 1 Skull IV every 20 seconds (starting 3 seconds after its initial appearance)" } },
			{ V31Centipede, new[] { "Emerges approximately 3 seconds after its spawn, starts flying idly for a while, then starts chasing the player", "Regularly dives down and moves underground for a while" } },
			{ V31Gigapede, new[] { "Emerges approximately 3 seconds after its spawn, then starts chasing the player immediately" } },
			{ V31Ghostpede, new[] { "Emerges approximately 3 seconds after its spawn, then starts flying in circles high above the arena", "Attracts and consumes all homing daggers, making them useless" } },
			{ V31Leviathan, new[] { "Activates 8.5333 seconds after its initial appearance", "Attracts and transmutes all skulls by beckoning every 20 seconds, starting 13.5333 seconds after its spawn (5 seconds after becoming active)", "Rotates counter-clockwise", "Drops The Orb 3.3167 seconds after dying" } },
			{ V31Thorn, new[] { "Emerges approximately 3 seconds after its spawn", "Takes up space" } },
			{ V31Spider1, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 3 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg I one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head" } },
			{ V31Spider2, new[] { "Spawns at the edge of the arena and starts lifting its head, faces the player after 9 seconds", "Attracts and consumes gems when facing the player, ejecting them as Spider Egg II one at a time", "Hides its head when shot and left unharmed for 1 second", "Begins moving randomly in an unpredictable jittery fashion after initially raising its head (though barely noticeable due to its size)" } },
			{ V31Skull1, new[] { "Slowly chases the player" } },
			{ V31Skull2, new[] { "Moves randomly" } },
			{ V31Skull3, new[] { "Chases the player fast" } },
			{ V31Skull4, new[] { "Chases the player fast" } },
			{ V31TransmutedSkull1, new[] { "Slowly chases the player" } },
			{ V31TransmutedSkull2, new[] { "Moves randomly" } },
			{ V31TransmutedSkull3, new[] { "Chases the player fast" } },
			{ V31TransmutedSkull4, new[] { "Chases the player fast" } },
			{ V31SpiderEgg1, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V31SpiderEgg2, new[] { "Hatches into 5 Spiderlings after 10 seconds" } },
			{ V31Spiderling, new[] { "Darts towards the player in bursts with random offsets" } },
			{ V31TheOrb, new[] { "Activates 10 seconds after Leviathan's death", "Behaves like an eyeball, will look at the player, then attract and transmute all skulls by beckoning every 2.5333 seconds", "Becomes stunned under constant fire, cannot look or attract skulls while stunned" } },
		};

		public static GameVersion? GetGameVersionFromDate(DateTime dateTime)
		{
			GameVersion[] gameVersions = (GameVersion[])Enum.GetValues(typeof(GameVersion));
			for (int i = 0; i < gameVersions.Length; i++)
			{
				if (dateTime >= GetReleaseDate(gameVersions[i]) && (i == gameVersions.Length - 1 || dateTime < GetReleaseDate(gameVersions[i + 1])))
					return gameVersions[i];
			}

			return null;
		}

		public static string[] GetEnemyInfo(Enemy enemy)
		{
			foreach (KeyValuePair<Enemy, string[]> kvp in _enemyInfo)
			{
				if (kvp.Key == enemy)
					return kvp.Value;
			}

			throw new($"Could not find enemy info for {nameof(Enemy)} with name '{enemy.Name}'.");
		}

		public static List<TEntity> GetEntities<TEntity>(GameVersion? gameVersion = null)
			where TEntity : DevilDaggersEntity
		{
			IEnumerable<TEntity> entities = Entities.OfType<TEntity>();
			if (gameVersion != null)
				entities = entities.Where(e => e.GameVersion == gameVersion);

			return entities.ToList();
		}

		public static Enemy? GetEnemyBySpawnsetType(int spawnsetType, GameVersion? gameVersion = null)
			=> GetEntities<Enemy>(gameVersion).Find(e => e.SpawnsetType == spawnsetType);

		public static Death? GetDeathByType(int deathType, GameVersion? gameVersion = null)
			=> GetEntities<Death>(gameVersion).Find(e => e.DeathType == deathType);

		public static Death? GetDeathByName(string deathName)
			=> GetEntities<Death>().Find(e => e.Name.ToLower(CultureInfo.InvariantCulture) == deathName.ToLower(CultureInfo.InvariantCulture));

		public static DateTime? GetReleaseDate(GameVersion gameVersion) => gameVersion switch
		{
			GameVersion.V1 => new(2016, 2, 18),
			GameVersion.V2 => new(2016, 7, 5),
			GameVersion.V3 => new(2016, 9, 19),
			GameVersion.V31 => new(2021, 2, 19),
			_ => null,
		};

		public static Dagger GetDaggerFromTime(int timeInTenthsOfMilliseconds)
		{
			List<Dagger> daggers = GetEntities<Dagger>(GameVersion.V31);
			for (int i = daggers.Count - 1; i >= 0; i--)
			{
				if (timeInTenthsOfMilliseconds >= (daggers[i].UnlockSecond ?? 0) * 10000)
					return daggers[i];
			}

			throw new($"Could not determine dagger based on time '{timeInTenthsOfMilliseconds}'.");
		}

		public static IEnumerable<GameVersion> GetAppearances(string entityName)
			=> Entities.Where(e => e.Name == entityName && e.GameVersion != GameVersion.V31).Select(e => e.GameVersion);
	}
}
