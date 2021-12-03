using DevilDaggersCore.Spawnsets;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DevilDaggersCore.Tests;

[TestClass]
public class SpawnsetDataTests
{
	[TestMethod]
	public void TestSpawnsetDataV0()
		=> TestSpawnsetData("V0", 275, 57, 30, 18, null, null, null);

	[TestMethod]
	public void TestSpawnsetDataV1()
		=> TestSpawnsetData("V1", 421, 99, 54, 21, null, null, null);

	[TestMethod]
	public void TestSpawnsetDataV2()
		=> TestSpawnsetData("V2", 375, 71, 58, 7, null, null, null);

	[TestMethod]
	public void TestSpawnsetDataV3()
		=> TestSpawnsetData("V3", 451, 90, 56, 17, null, null, null);

	[TestMethod]
	public void TestSpawnsetDataV3_229()
		=> TestSpawnsetData("V3_229", 222, 52, 56, 17, 3, 57, 229);

	[TestMethod]
	public void TestSpawnsetDataV3_451()
		=> TestSpawnsetData("V3_451", null, 0, 56, 17, 4, 0, 451);

	[AssertionMethod]
	private static void TestSpawnsetData(string spawnsetFileName, float? expectedNonLoopLength, int expectedNonLoopSpawnCount, float? expectedLoopLength, int expectedLoopSpawnCount, byte? expectedHand, int? expectedAdditionalGems, float? expectedTimerStart)
	{
		if (!Spawnset.TryGetSpawnsetData(File.ReadAllBytes(Path.Combine("Resources", spawnsetFileName)), out SpawnsetData spawnsetData))
			Assert.Fail("Could not parse spawnset.");

		Assert.AreEqual(expectedNonLoopLength, spawnsetData.NonLoopLength);
		Assert.AreEqual(expectedNonLoopSpawnCount, spawnsetData.NonLoopSpawnCount);

		Assert.AreEqual(expectedLoopLength, spawnsetData.LoopLength);
		Assert.AreEqual(expectedLoopSpawnCount, spawnsetData.LoopSpawnCount);

		Assert.AreEqual(expectedHand, spawnsetData.Hand);
		Assert.AreEqual(expectedAdditionalGems, spawnsetData.AdditionalGems);
		Assert.AreEqual(expectedTimerStart, spawnsetData.TimerStart);
	}
}
