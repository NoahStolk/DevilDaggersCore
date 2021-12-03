using DevilDaggersCore.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevilDaggersCore.Tests;

[TestClass]
public class DaggerTests
{
	[TestMethod]
	public void TestLeviathanDagger()
	{
		const int seconds = 1000;
		const int tenthsOfMilliseconds = 1000_0000;

		Assert.AreEqual(GameInfo.V31LeviathanDagger, GameInfo.GetDaggerFromSeconds(GameVersion.V31, seconds));
		Assert.AreEqual(GameInfo.V31LeviathanDagger, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMilliseconds));
	}

	[TestMethod]
	public void TestDevilDagger()
	{
		const int secondsLastV31 = 999;
		const int tenthsOfMillisecondsLastV31 = 999_9999;

		const int secondsLastV3 = 1000;
		const int tenthsOfMillisecondsLastV3 = 1000_0000;

		const int secondsFirst = 500;
		const int tenthsOfMillisecondsFirst = 500_0000;

		Assert.AreEqual(GameInfo.V31Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsLastV31));
		Assert.AreEqual(GameInfo.V31Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsLastV31));

		Assert.AreEqual(GameInfo.V31Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsFirst));
		Assert.AreEqual(GameInfo.V31Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V3Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsLastV3));
		Assert.AreEqual(GameInfo.V3Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsLastV3));

		Assert.AreEqual(GameInfo.V3Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsFirst));
		Assert.AreEqual(GameInfo.V3Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V2Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsLastV3));
		Assert.AreEqual(GameInfo.V2Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsLastV3));

		Assert.AreEqual(GameInfo.V2Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsFirst));
		Assert.AreEqual(GameInfo.V2Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V1Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsLastV3));
		Assert.AreEqual(GameInfo.V1Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsLastV3));

		Assert.AreEqual(GameInfo.V1Devil, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsFirst));
		Assert.AreEqual(GameInfo.V1Devil, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsFirst));
	}

	[TestMethod]
	public void TestGoldenDagger()
	{
		const int secondsLast = 499;
		const int tenthsOfMillisecondsLast = 499_9999;

		const int secondsFirst = 250;
		const int tenthsOfMillisecondsFirst = 250_0000;

		Assert.AreEqual(GameInfo.V31Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsLast));
		Assert.AreEqual(GameInfo.V31Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V31Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsFirst));
		Assert.AreEqual(GameInfo.V31Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V3Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsLast));
		Assert.AreEqual(GameInfo.V3Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V3Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsFirst));
		Assert.AreEqual(GameInfo.V3Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V2Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsLast));
		Assert.AreEqual(GameInfo.V2Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V2Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsFirst));
		Assert.AreEqual(GameInfo.V2Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V1Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsLast));
		Assert.AreEqual(GameInfo.V1Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V1Golden, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsFirst));
		Assert.AreEqual(GameInfo.V1Golden, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsFirst));
	}

	[TestMethod]
	public void TestSilverDagger()
	{
		const int secondsLast = 249;
		const int tenthsOfMillisecondsLast = 249_9999;

		const int secondsFirst = 120;
		const int tenthsOfMillisecondsFirst = 120_0000;

		Assert.AreEqual(GameInfo.V31Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsLast));
		Assert.AreEqual(GameInfo.V31Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V31Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsFirst));
		Assert.AreEqual(GameInfo.V31Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V3Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsLast));
		Assert.AreEqual(GameInfo.V3Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V3Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsFirst));
		Assert.AreEqual(GameInfo.V3Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V2Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsLast));
		Assert.AreEqual(GameInfo.V2Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V2Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsFirst));
		Assert.AreEqual(GameInfo.V2Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V1Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsLast));
		Assert.AreEqual(GameInfo.V1Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V1Silver, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsFirst));
		Assert.AreEqual(GameInfo.V1Silver, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsFirst));
	}

	[TestMethod]
	public void TestBronzeDagger()
	{
		const int secondsLast = 119;
		const int tenthsOfMillisecondsLast = 119_9999;

		const int secondsFirst = 60;
		const int tenthsOfMillisecondsFirst = 60_0000;

		Assert.AreEqual(GameInfo.V31Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsLast));
		Assert.AreEqual(GameInfo.V31Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V31Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsFirst));
		Assert.AreEqual(GameInfo.V31Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V3Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsLast));
		Assert.AreEqual(GameInfo.V3Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V3Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsFirst));
		Assert.AreEqual(GameInfo.V3Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V2Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsLast));
		Assert.AreEqual(GameInfo.V2Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V2Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsFirst));
		Assert.AreEqual(GameInfo.V2Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V1Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsLast));
		Assert.AreEqual(GameInfo.V1Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V1Bronze, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsFirst));
		Assert.AreEqual(GameInfo.V1Bronze, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsFirst));
	}

	[TestMethod]
	public void TestDefaultDagger()
	{
		const int secondsLast = 59;
		const int tenthsOfMillisecondsLast = 59_9999;

		const int secondsFirst = 0;
		const int tenthsOfMillisecondsFirst = 0;

		Assert.AreEqual(GameInfo.V31Default, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsLast));
		Assert.AreEqual(GameInfo.V31Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V31Default, GameInfo.GetDaggerFromSeconds(GameVersion.V31, secondsFirst));
		Assert.AreEqual(GameInfo.V31Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V31, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V3Default, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsLast));
		Assert.AreEqual(GameInfo.V3Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V3Default, GameInfo.GetDaggerFromSeconds(GameVersion.V3, secondsFirst));
		Assert.AreEqual(GameInfo.V3Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V3, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V2Default, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsLast));
		Assert.AreEqual(GameInfo.V2Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V2Default, GameInfo.GetDaggerFromSeconds(GameVersion.V2, secondsFirst));
		Assert.AreEqual(GameInfo.V2Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V2, tenthsOfMillisecondsFirst));

		Assert.AreEqual(GameInfo.V1Default, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsLast));
		Assert.AreEqual(GameInfo.V1Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsLast));

		Assert.AreEqual(GameInfo.V1Default, GameInfo.GetDaggerFromSeconds(GameVersion.V1, secondsFirst));
		Assert.AreEqual(GameInfo.V1Default, GameInfo.GetDaggerFromTenthsOfMilliseconds(GameVersion.V1, tenthsOfMillisecondsFirst));
	}

	[TestMethod]
	public void TestOutOfRange()
	{
		Assert.ThrowsException<ArgumentOutOfRangeException>(() => GameInfo.GetDaggerFromSeconds(GameVersion.V31, -1));
	}
}
