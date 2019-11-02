﻿using DevilDaggersCore.Leaderboards.HistoryCompletion;
using NetBase.Utils;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace DevilDaggersCore.Leaderboards
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Entry
	{
		[CompletionProperty]
		[JsonProperty]
		public int Rank { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int ID { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public string Username { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int Time { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int Kills { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int Gems { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int DeathType { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int ShotsHit { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public int ShotsFired { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong TimeTotal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong KillsTotal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong GemsTotal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong DeathsTotal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong ShotsHitTotal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong ShotsFiredTotal { get; set; }

		public double Accuracy => ShotsFired == 0 ? 0 : ShotsHit / (double)ShotsFired;
		public double AccuracyTotal => ShotsFiredTotal == 0 ? 0 : ShotsHitTotal / (double)ShotsFiredTotal;

		public Completion Completion { get; } = new Completion();

		public Completion GetCompletion()
		{
			if (Completion.Initialized)
				return Completion;

			foreach (PropertyInfo info in GetType().GetProperties())
			{
				object value = info.GetValue(this);
				if (value == null)
					continue;

				string valueString = value.ToString();
				if (string.IsNullOrEmpty(valueString))
					continue;

				if (!Attribute.IsDefined(info, typeof(CompletionPropertyAttribute)))
					continue;

				if ((info.Name == nameof(DeathType) && valueString == "-1")
				 || (info.Name != nameof(DeathType) && valueString == ReflectionUtils.GetDefaultValue(value.GetType()).ToString()))
					Completion.CompletionEntries[info.Name] = CompletionEntry.Missing;
				else
					Completion.CompletionEntries[info.Name] = CompletionEntry.Complete;
			}

			Completion.Initialized = true;
			return Completion;
		}

		public bool IsBlankName()
		{
			return ID == 999999;
		}
	}
}