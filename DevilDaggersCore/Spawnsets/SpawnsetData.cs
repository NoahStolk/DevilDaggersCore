namespace DevilDaggersCore.Spawnsets;

public record SpawnsetData(int SpawnVersion, int WorldVersion, GameMode GameMode, int NonLoopSpawnCount, int LoopSpawnCount, float? NonLoopLength, float? LoopLength, byte? Hand, int? AdditionalGems, float? TimerStart);
