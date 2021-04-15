using System.Collections.Generic;

namespace DevilDaggersCore.Mods
{
	public class ModelAssetData : AssetData
	{
		public ModelAssetData(string assetName, string description, bool isProhibited, List<string> tags, int defaultIndexCount, int defaultVertexCount)
			: base(assetName, description, isProhibited, tags)
		{
			DefaultIndexCount = defaultIndexCount;
			DefaultVertexCount = defaultVertexCount;
		}

		public int DefaultIndexCount { get; }

		public int DefaultVertexCount { get; }
	}
}
