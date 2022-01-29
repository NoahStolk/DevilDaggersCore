using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Game;

public static class GameInfo
{
	#region V1

	public static readonly Enemy V1Squid1 = new(GameVersion.V1, "Squid I", "4E3000", 10, 1, 2, 0x0, 1, null, 3);
	public static readonly Enemy V1Squid2 = new(GameVersion.V1, "Squid II", "804E00", 20, 2, 3, 0x1, 2, null, 39);
	public static readonly Enemy V1Centipede = new(GameVersion.V1, "Centipede", "837E75", 75, 25, 25, 0x2, 25, null, 114);
	public static readonly Enemy V1Gigapede = new(GameVersion.V1, "Gigapede", "7B5157", 250, 50, 50, 0x5, 50, null, 264);
	public static readonly Enemy V1Leviathan = new(GameVersion.V1, "Leviathan", "FF0000", 600, 6, 6, 0x4, 600, null, 397);
	public static readonly Enemy V1Spider1 = new(GameVersion.V1, "Spider I", "097A00", 25, 1, 1, 0x3, 3, null, 39);

	public static readonly Enemy V1Skull1 = new(GameVersion.V1, "Skull I", "352710", 1, 0, 0, null, 0.25f, null, null, V1Squid1, V1Squid2);
	public static readonly Enemy V1Skull2 = new(GameVersion.V1, "Skull II", "433114", 5, 1, 1, null, 1, null, null, V1Squid1);
	public static readonly Enemy V1Skull3 = new(GameVersion.V1, "Skull III", "6E5021", 10, 1, 1, null, 1, null, null, V1Squid2);

	public static readonly Enemy V1TransmutedSkull2 = new(GameVersion.V1, "Transmuted Skull II", "721A13", 10, 1, 1, null, 1, null, null, V1Leviathan);
	public static readonly Enemy V1TransmutedSkull3 = new(GameVersion.V1, "Transmuted Skull III", "982319", 20, 1, 1, null, 2, null, null, V1Leviathan);
	public static readonly Enemy V1TransmutedSkull4 = new(GameVersion.V1, "Transmuted Skull IV", "BE2C20", 100, 0, 0, null, 10, null, null, V1Leviathan);

	public static readonly Enemy V1SpiderEgg1 = new(GameVersion.V1, "Spider Egg I", "99A100", 3, 0, 0, null, 3, null, null, V1Spider1);
	public static readonly Enemy V1Spiderling = new(GameVersion.V1, "Spiderling", "DCCB00", 3, 0, 0, null, 1, null, null, V1SpiderEgg1);

	#endregion V1

	#region V2

	public static readonly Enemy V2Squid1 = new(GameVersion.V2, "Squid I", "4E3000", 10, 1, 2, 0x0, 1, 1, 3);
	public static readonly Enemy V2Squid2 = new(GameVersion.V2, "Squid II", "804E00", 20, 2, 3, 0x1, 2, 1, 39);
	public static readonly Enemy V2Squid3 = new(GameVersion.V2, "Squid III", "AF6B00", 90, 3, 3, 0x6, 3, 9, 244);
	public static readonly Enemy V2Centipede = new(GameVersion.V2, "Centipede", "837E75", 75, 25, 25, 0x2, 25, 25, 114);
	public static readonly Enemy V2Gigapede = new(GameVersion.V2, "Gigapede", "7B5157", 250, 50, 50, 0x5, 50, 50, 259);
	public static readonly Enemy V2Leviathan = new(GameVersion.V2, "Leviathan", "FF0000", 1500, 6, 6, 0x4, 1500, 1500, 350);
	public static readonly Enemy V2Spider1 = new(GameVersion.V2, "Spider I", "097A00", 25, 1, 1, 0x3, 3, 3, 39);
	public static readonly Enemy V2Spider2 = new(GameVersion.V2, "Spider II", "13FF00", 200, 1, 1, 0x8, 20, 20, 274);

	public static readonly Enemy V2Skull1 = new(GameVersion.V2, "Skull I", "352710", 1, 0, 0, null, 0.25f, 0.25f, null, V2Squid1, V2Squid2, V2Squid3);
	public static readonly Enemy V2Skull2 = new(GameVersion.V2, "Skull II", "433114", 5, 1, 1, null, 1, 1, null, V2Squid1);
	public static readonly Enemy V2Skull3 = new(GameVersion.V2, "Skull III", "6E5021", 10, 1, 1, null, 1, 1, null, V2Squid2);
	public static readonly Enemy V2Skull4 = new(GameVersion.V2, "Skull IV", "976E2E", 100, 0, 0, null, 10, 10, null, V2Squid3);

	public static readonly Enemy V2TransmutedSkull1 = new(GameVersion.V2, "Transmuted Skull I", "4C110C", 10, 0, 0, null, 0.25f, 10, null, V2Leviathan);
	public static readonly Enemy V2TransmutedSkull2 = new(GameVersion.V2, "Transmuted Skull II", "721A13", 20, 1, 1, null, 2, 2, null, V2Leviathan);
	public static readonly Enemy V2TransmutedSkull3 = new(GameVersion.V2, "Transmuted Skull III", "982319", 100, 1, 1, null, 10, 10, null, V2Leviathan);
	public static readonly Enemy V2TransmutedSkull4 = new(GameVersion.V2, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, 30, 30, null, V2Leviathan);

	public static readonly Enemy V2SpiderEgg1 = new(GameVersion.V2, "Spider Egg I", "99A100", 3, 0, 0, null, 3, 3, null, V2Spider1);
	public static readonly Enemy V2SpiderEgg2 = new(GameVersion.V2, "Spider Egg II", "657A00", 3, 0, 0, null, 3, 3, null, V2Spider2);
	public static readonly Enemy V2Spiderling = new(GameVersion.V2, "Spiderling", "DCCB00", 3, 0, 0, null, 1, 1, null, V2SpiderEgg1, V2SpiderEgg2);

	public static readonly Enemy V2Andras = new(GameVersion.V2, "Andras", "666666", 25, 1, 1, 0x7, null, null, null);

	#endregion V2

	#region V3

	public static readonly Enemy V3Squid1 = new(GameVersion.V3, "Squid I", "4E3000", 10, 1, 2, 0x0, 1, 1, 3);
	public static readonly Enemy V3Squid2 = new(GameVersion.V3, "Squid II", "804E00", 20, 2, 3, 0x1, 2, 1, 39);
	public static readonly Enemy V3Squid3 = new(GameVersion.V3, "Squid III", "AF6B00", 90, 3, 3, 0x6, 3, 9, 244);
	public static readonly Enemy V3Centipede = new(GameVersion.V3, "Centipede", "837E75", 75, 25, 25, 0x2, 25, 25, 114);
	public static readonly Enemy V3Gigapede = new(GameVersion.V3, "Gigapede", "478B41", 250, 50, 50, 0x5, 50, 50, 259);
	public static readonly Enemy V3Ghostpede = new(GameVersion.V3, "Ghostpede", "C8A2C8", 500, 10, 10, 0x9, null, null, 442);
	public static readonly Enemy V3Leviathan = new(GameVersion.V3, "Leviathan", "FF0000", 1500, 6, 6, 0x4, 1500, 1500, 350);
	public static readonly Enemy V3Thorn = new(GameVersion.V3, "Thorn", "771D00", 120, 0, 0, 0x7, 12, 12, 447);
	public static readonly Enemy V3Spider1 = new(GameVersion.V3, "Spider I", "097A00", 25, 1, 1, 0x3, 3, 3, 39);
	public static readonly Enemy V3Spider2 = new(GameVersion.V3, "Spider II", "13FF00", 200, 1, 1, 0x8, 20, 20, 274);

	public static readonly Enemy V3TheOrb = new(GameVersion.V3, "The Orb", "FF3131", 2400, 0, 0, null, 2400, 2400, null, V3Leviathan);

	public static readonly Enemy V3Skull1 = new(GameVersion.V3, "Skull I", "352710", 1, 0, 0, null, 0.25f, 0.25f, null, V3Squid1, V3Squid2, V3Squid3);
	public static readonly Enemy V3Skull2 = new(GameVersion.V3, "Skull II", "433114", 5, 1, 1, null, 1, 1, null, V3Squid1);
	public static readonly Enemy V3Skull3 = new(GameVersion.V3, "Skull III", "6E5021", 10, 1, 1, null, 1, 1, null, V3Squid2);
	public static readonly Enemy V3Skull4 = new(GameVersion.V3, "Skull IV", "976E2E", 100, 0, 0, null, 10, 10, null, V3Squid3);

	public static readonly Enemy V3TransmutedSkull1 = new(GameVersion.V3, "Transmuted Skull I", "4C110C", 10, 0, 0, null, 0.25f, 10, null, V3Leviathan, V3TheOrb);
	public static readonly Enemy V3TransmutedSkull2 = new(GameVersion.V3, "Transmuted Skull II", "721A13", 20, 1, 1, null, 2, 2, null, V3Leviathan, V3TheOrb);
	public static readonly Enemy V3TransmutedSkull3 = new(GameVersion.V3, "Transmuted Skull III", "982319", 100, 1, 1, null, 10, 10, null, V3Leviathan, V3TheOrb);
	public static readonly Enemy V3TransmutedSkull4 = new(GameVersion.V3, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, 30, 30, null, V3Leviathan, V3TheOrb);

	public static readonly Enemy V3SpiderEgg1 = new(GameVersion.V3, "Spider Egg I", "99A100", 3, 0, 0, null, 3, 3, null, V3Spider1);
	public static readonly Enemy V3SpiderEgg2 = new(GameVersion.V3, "Spider Egg II", "657A00", 3, 0, 0, null, 3, 3, null, V3Spider2);
	public static readonly Enemy V3Spiderling = new(GameVersion.V3, "Spiderling", "DCCB00", 3, 0, 0, null, 1, 1, null, V3SpiderEgg1, V3SpiderEgg2);

	#endregion V3

	#region V3.1

	public static readonly Enemy V31Squid1 = new(GameVersion.V31, "Squid I", "4E3000", 10, 1, 2, 0x0, 1, 1, 3);
	public static readonly Enemy V31Squid2 = new(GameVersion.V31, "Squid II", "804E00", 20, 2, 3, 0x1, 2, 1, 39);
	public static readonly Enemy V31Squid3 = new(GameVersion.V31, "Squid III", "AF6B00", 90, 3, 3, 0x6, 3, 9, 244);
	public static readonly Enemy V31Centipede = new(GameVersion.V31, "Centipede", "837E75", 75, 25, 25, 0x2, 25, 25, 114);
	public static readonly Enemy V31Gigapede = new(GameVersion.V31, "Gigapede", "478B41", 250, 50, 50, 0x5, 50, 50, 259);
	public static readonly Enemy V31Ghostpede = new(GameVersion.V31, "Ghostpede", "C8A2C8", 500, 10, 10, 0x9, null, null, 442);
	public static readonly Enemy V31Leviathan = new(GameVersion.V31, "Leviathan", "FF0000", 1500, 6, 6, 0x4, 1500, 1500, 350);
	public static readonly Enemy V31Thorn = new(GameVersion.V31, "Thorn", "771D00", 120, 0, 0, 0x7, 12, 12, 447);
	public static readonly Enemy V31Spider1 = new(GameVersion.V31, "Spider I", "097A00", 25, 1, 1, 0x3, 3, 3, 39);
	public static readonly Enemy V31Spider2 = new(GameVersion.V31, "Spider II", "13FF00", 200, 1, 1, 0x8, 20, 20, 274);

	public static readonly Enemy V31TheOrb = new(GameVersion.V31, "The Orb", "FF3131", 2400, 0, 0, null, 2400, 2400, null, V31Leviathan);

	public static readonly Enemy V31Skull1 = new(GameVersion.V31, "Skull I", "352710", 1, 0, 0, null, 0.25f, 0.25f, null, V31Squid1, V31Squid2, V31Squid3);
	public static readonly Enemy V31Skull2 = new(GameVersion.V31, "Skull II", "433114", 5, 1, 1, null, 1, 1, null, V31Squid1);
	public static readonly Enemy V31Skull3 = new(GameVersion.V31, "Skull III", "6E5021", 10, 1, 1, null, 1, 1, null, V31Squid2);
	public static readonly Enemy V31Skull4 = new(GameVersion.V31, "Skull IV", "976E2E", 100, 0, 0, null, 10, 10, null, V31Squid3);

	public static readonly Enemy V31TransmutedSkull1 = new(GameVersion.V31, "Transmuted Skull I", "4C110C", 10, 0, 0, null, 0.25f, 10, null, V31Leviathan, V31TheOrb);
	public static readonly Enemy V31TransmutedSkull2 = new(GameVersion.V31, "Transmuted Skull II", "721A13", 20, 1, 1, null, 2, 2, null, V31Leviathan, V31TheOrb);
	public static readonly Enemy V31TransmutedSkull3 = new(GameVersion.V31, "Transmuted Skull III", "982319", 100, 1, 1, null, 10, 10, null, V31Leviathan, V31TheOrb);
	public static readonly Enemy V31TransmutedSkull4 = new(GameVersion.V31, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, 30, 30, null, V31Leviathan, V31TheOrb);

	public static readonly Enemy V31SpiderEgg1 = new(GameVersion.V31, "Spider Egg I", "99A100", 3, 0, 0, null, 3, 3, null, V31Spider1);
	public static readonly Enemy V31SpiderEgg2 = new(GameVersion.V31, "Spider Egg II", "657A00", 3, 0, 0, null, 3, 3, null, V31Spider2);
	public static readonly Enemy V31Spiderling = new(GameVersion.V31, "Spiderling", "DCCB00", 3, 0, 0, null, 1, 1, null, V31SpiderEgg1, V31SpiderEgg2);

	#endregion V3.1

	#region V3.2

	public static readonly Enemy V32Squid1 = new(GameVersion.V32, "Squid I", "4E3000", 10, 1, 2, 0x0, 1, 1, 3);
	public static readonly Enemy V32Squid2 = new(GameVersion.V32, "Squid II", "804E00", 20, 2, 3, 0x1, 2, 1, 39);
	public static readonly Enemy V32Squid3 = new(GameVersion.V32, "Squid III", "AF6B00", 90, 3, 3, 0x6, 3, 9, 244);
	public static readonly Enemy V32Centipede = new(GameVersion.V32, "Centipede", "837E75", 75, 25, 25, 0x2, 25, 25, 114);
	public static readonly Enemy V32Gigapede = new(GameVersion.V32, "Gigapede", "478B41", 250, 50, 50, 0x5, 50, 50, 259);
	public static readonly Enemy V32Ghostpede = new(GameVersion.V32, "Ghostpede", "C8A2C8", 500, 10, 10, 0x9, null, null, 442);
	public static readonly Enemy V32Leviathan = new(GameVersion.V32, "Leviathan", "FF0000", 1500, 6, 6, 0x4, 1500, 1500, 350);
	public static readonly Enemy V32Thorn = new(GameVersion.V32, "Thorn", "771D00", 120, 0, 0, 0x7, 12, 12, 447);
	public static readonly Enemy V32Spider1 = new(GameVersion.V32, "Spider I", "097A00", 25, 1, 1, 0x3, 3, 3, 39);
	public static readonly Enemy V32Spider2 = new(GameVersion.V32, "Spider II", "13FF00", 200, 1, 1, 0x8, 20, 20, 274);

	public static readonly Enemy V32TheOrb = new(GameVersion.V32, "The Orb", "FF3131", 2400, 0, 0, null, 2400, 2400, null, V32Leviathan);

	public static readonly Enemy V32Skull1 = new(GameVersion.V32, "Skull I", "352710", 1, 0, 0, null, 0.25f, 0.25f, null, V32Squid1, V32Squid2, V32Squid3);
	public static readonly Enemy V32Skull2 = new(GameVersion.V32, "Skull II", "433114", 5, 1, 1, null, 1, 1, null, V32Squid1);
	public static readonly Enemy V32Skull3 = new(GameVersion.V32, "Skull III", "6E5021", 10, 1, 1, null, 1, 1, null, V32Squid2);
	public static readonly Enemy V32Skull4 = new(GameVersion.V32, "Skull IV", "976E2E", 100, 0, 0, null, 10, 10, null, V32Squid3);

	public static readonly Enemy V32TransmutedSkull1 = new(GameVersion.V32, "Transmuted Skull I", "4C110C", 10, 0, 0, null, 1, 1, null, V32Leviathan, V32TheOrb);
	public static readonly Enemy V32TransmutedSkull2 = new(GameVersion.V32, "Transmuted Skull II", "721A13", 20, 1, 1, null, 2, 2, null, V32Leviathan, V32TheOrb);
	public static readonly Enemy V32TransmutedSkull3 = new(GameVersion.V32, "Transmuted Skull III", "982319", 100, 1, 1, null, 10, 10, null, V32Leviathan, V32TheOrb);
	public static readonly Enemy V32TransmutedSkull4 = new(GameVersion.V32, "Transmuted Skull IV", "BE2C20", 300, 0, 0, null, 30, 30, null, V32Leviathan, V32TheOrb);

	public static readonly Enemy V32SpiderEgg1 = new(GameVersion.V32, "Spider Egg I", "99A100", 3, 0, 0, null, 1, 1, null, V32Spider1);
	public static readonly Enemy V32SpiderEgg2 = new(GameVersion.V32, "Spider Egg II", "657A00", 3, 0, 0, null, 1, 1, null, V32Spider2);
	public static readonly Enemy V32Spiderling = new(GameVersion.V32, "Spiderling", "DCCB00", 3, 0, 0, null, 1, 1, null, V32SpiderEgg1, V32SpiderEgg2);

	#endregion V3.2

	private static readonly IEnumerable<Enemy> _enemies = typeof(GameInfo).GetFields().Where(f => f.FieldType == typeof(Enemy)).Select(f => (Enemy)f.GetValue(null)!);

	private static readonly List<Enemy> _v1Enemies = _enemies.Where(e => e.GameVersion == GameVersion.V1).ToList();
	private static readonly List<Enemy> _v2Enemies = _enemies.Where(e => e.GameVersion == GameVersion.V2).ToList();
	private static readonly List<Enemy> _v3Enemies = _enemies.Where(e => e.GameVersion == GameVersion.V3).ToList();
	private static readonly List<Enemy> _v31Enemies = _enemies.Where(e => e.GameVersion == GameVersion.V31).ToList();
	private static readonly List<Enemy> _v32Enemies = _enemies.Where(e => e.GameVersion == GameVersion.V32).ToList();

	public static List<Enemy> GetEnemies(GameVersion gameVersion) => gameVersion switch
	{
		GameVersion.V1 => _v1Enemies,
		GameVersion.V2 => _v2Enemies,
		GameVersion.V3 => _v3Enemies,
		GameVersion.V31 => _v31Enemies,
		_ => _v32Enemies,
	};

	public static Enemy? GetEnemyBySpawnsetType(GameVersion gameVersion, int spawnsetType)
		=> GetEnemies(gameVersion).Find(e => e.SpawnsetType == spawnsetType);
}
