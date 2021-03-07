using DevilDaggersCore.Spawnsets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DevilDaggersCore.Tests
{
	[TestClass]
	public class SpawnsetTests
	{
		[TestMethod]
		public void TestParseV0()
		{
			if (!Spawnset.TryParse(File.ReadAllBytes(Path.Combine("Resources", "V0")), out Spawnset v0))
				Assert.Fail("Could not parse spawnset.");

			Assert.AreEqual(4, v0.SpawnVersion);
			Assert.AreEqual(8, v0.WorldVersion);

			Assert.AreEqual(82, v0.Spawns.Count);

			Assert.AreEqual((byte)0, v0.Spawns[0].Enemy.SpawnsetType);
			Assert.AreEqual(3, v0.Spawns[0].Delay);
			Assert.AreEqual(null, v0.Spawns[1].Enemy);
			Assert.AreEqual(6, v0.Spawns[1].Delay);
		}

		[TestMethod]
		public void TestParseV3()
		{
			if (!Spawnset.TryParse(File.ReadAllBytes(Path.Combine("Resources", "V3")), out Spawnset v3))
				Assert.Fail("Could not parse spawnset.");

			Assert.AreEqual(4, v3.SpawnVersion);
			Assert.AreEqual(9, v3.WorldVersion);

			Assert.AreEqual(118, v3.Spawns.Count);

			Assert.AreEqual((byte)0, v3.Spawns[0].Enemy.SpawnsetType);
			Assert.AreEqual(3, v3.Spawns[0].Delay);
			Assert.AreEqual(null, v3.Spawns[1].Enemy);
			Assert.AreEqual(6, v3.Spawns[1].Delay);
		}
	}
}
