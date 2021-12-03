using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Wpf.Models;

public class ChangelogEntry
{
	public ChangelogEntry(Version versionNumber, DateTimeOffset date, List<Change> changes)
	{
		VersionNumber = versionNumber;
		Date = date;
		Changes = changes;
	}

	public Version VersionNumber { get; }
	public DateTimeOffset Date { get; }
	public List<Change> Changes { get; }
}
