using System.Collections.Generic;

namespace DevilDaggersCore.Mods
{
	public class AssetData
	{
		public AssetData(string assetName, string description, bool isProhibited, List<string> tags)
		{
			AssetName = assetName;
			Description = description;
			IsProhibited = isProhibited;
			Tags = tags;
		}

		public string AssetName { get; }
		public string Description { get; }
		public bool IsProhibited { get; }
		public List<string> Tags { get; }

		public AssetType AssetType { get; set; }
	}
}
