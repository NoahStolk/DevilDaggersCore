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

			Assert.AreEqual((byte)0, v0.Spawns[0].Enemy?.SpawnsetType);
			Assert.AreEqual(3, v0.Spawns[0].Delay);
			Assert.AreEqual(null, v0.Spawns[1].Enemy);
			Assert.AreEqual(6, v0.Spawns[1].Delay);
		}

		[TestMethod]
		public void TestParseV1()
		{
			if (!Spawnset.TryParse(File.ReadAllBytes(Path.Combine("Resources", "V1")), out Spawnset v1))
				Assert.Fail("Could not parse spawnset.");

			Assert.AreEqual(4, v1.SpawnVersion);
			Assert.AreEqual(8, v1.WorldVersion);

			Assert.AreEqual(130, v1.Spawns.Count);

			Assert.AreEqual((byte)0, v1.Spawns[0].Enemy?.SpawnsetType);
			Assert.AreEqual(3, v1.Spawns[0].Delay);
			Assert.AreEqual(null, v1.Spawns[1].Enemy);
			Assert.AreEqual(6, v1.Spawns[1].Delay);
		}

		[TestMethod]
		public void TestParseV2()
		{
			if (!Spawnset.TryParse(File.ReadAllBytes(Path.Combine("Resources", "V2")), out Spawnset v2))
				Assert.Fail("Could not parse spawnset.");

			Assert.AreEqual(4, v2.SpawnVersion);
			Assert.AreEqual(9, v2.WorldVersion);

			Assert.AreEqual(87, v2.Spawns.Count);

			Assert.AreEqual((byte)0, v2.Spawns[0].Enemy?.SpawnsetType);
			Assert.AreEqual(3, v2.Spawns[0].Delay);
			Assert.AreEqual(null, v2.Spawns[1].Enemy);
			Assert.AreEqual(6, v2.Spawns[1].Delay);
		}

		[TestMethod]
		public void TestParseV3()
		{
			if (!Spawnset.TryParse(File.ReadAllBytes(Path.Combine("Resources", "V3")), out Spawnset v3))
				Assert.Fail("Could not parse spawnset.");

			Assert.AreEqual(4, v3.SpawnVersion);
			Assert.AreEqual(9, v3.WorldVersion);

			Assert.AreEqual(118, v3.Spawns.Count);

			Assert.AreEqual((byte)0, v3.Spawns[0].Enemy?.SpawnsetType);
			Assert.AreEqual(3, v3.Spawns[0].Delay);
			Assert.AreEqual(null, v3.Spawns[1].Enemy);
			Assert.AreEqual(6, v3.Spawns[1].Delay);
		}
	}
}
