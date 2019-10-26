using NetBase.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevilDaggersCore.Leaderboards
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Leaderboard
	{
		[JsonProperty]
		public DateTime DateTime { get; set; } = DateTime.UtcNow;

		[CompletionProperty]
		[JsonProperty]
		public int Players { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong TimeGlobal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong KillsGlobal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong GemsGlobal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong DeathsGlobal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong ShotsHitGlobal { get; set; }

		[CompletionProperty]
		[JsonProperty]
		public ulong ShotsFiredGlobal { get; set; }

		[JsonProperty]
		public List<Entry> Entries { get; set; } = new List<Entry>();

		public double AccuracyGlobal => ShotsFiredGlobal == 0 ? 0 : ShotsHitGlobal / (double)ShotsFiredGlobal;

		public bool HasBlankName => Entries.Any(e => e.IsBlankName());

		public Completion Completion { get; } = new Completion();
		public CompletionCombined UserCompletion { get; } = new CompletionCombined();

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

				if (!Attribute.IsDefined(info, typeof(CompletionProperty)))
					continue;

				if (valueString == ReflectionUtils.GetDefaultValue(value.GetType()).ToString())
					Completion.CompletionEntries[info.Name] = CompletionEntry.Missing;
				else
					Completion.CompletionEntries[info.Name] = CompletionEntry.Complete;
			}

			int players = Players == 0 ? 100 : Math.Min(Players, 100);
			if (Entries.Count != players)
				Completion.CompletionEntries[$"{players - Entries.Count} users"] = CompletionEntry.Missing;

			Completion.Initialized = true;
			return Completion;
		}

		public CompletionCombined GetUserCompletion()
		{
			if (UserCompletion.Initialized)
				return UserCompletion;

			List<Completion> completions = new List<Completion>();
			foreach (Entry entry in Entries)
				completions.Add(entry.GetCompletion());
			int total = HasBlankName ? completions.Count - 1 : completions.Count;

			foreach (KeyValuePair<string, CompletionEntry> kvp in completions[0].CompletionEntries)
			{
				int missing = 0;
				for (int i = 0; i < completions.Count; i++)
				{
					if (Entries[i].IsBlankName())
						continue;

					if (completions[i].CompletionEntries.TryGetValue(kvp.Key, out CompletionEntry ce) && ce == CompletionEntry.Missing)
						missing++;
				}

				UserCompletion.CompletionEntries[kvp.Key] = missing == 0 ? CompletionEntryCombined.Complete : missing == total ? CompletionEntryCombined.Missing : CompletionEntryCombined.PartiallyMissing;
			}

			UserCompletion.Initialized = true;
			return UserCompletion;
		}

		public float GetCompletionRate()
		{
			int total = HasBlankName ? 99 : 100;
			int totalEntries = Players == 0 ? total : Math.Min(Players, total);

			float globalCompletionRate = GetCompletion().GetCompletionRate();
			float userCompletionRate = 0;
			foreach (Entry entry in Entries)
			{
				if (entry.IsBlankName())
					continue;
				userCompletionRate += entry.GetCompletion().GetCompletionRate() * (1f / totalEntries);
			}

			return userCompletionRate * 0.99f + globalCompletionRate * 0.01f;
		}
	}
}