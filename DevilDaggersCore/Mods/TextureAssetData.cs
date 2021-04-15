using System.Collections.Generic;

namespace DevilDaggersCore.Mods
{
	public class TextureAssetData : AssetData
	{
		public TextureAssetData(string assetName, string description, bool isProhibited, List<string> tags, int defaultWidth, int defaultHeight, bool isModelTexture, string modelBinding)
			: base(assetName, description, isProhibited, tags)
		{
			DefaultWidth = defaultWidth;
			DefaultHeight = defaultHeight;
			IsModelTexture = isModelTexture;
			ModelBinding = modelBinding;
		}

		public int DefaultWidth { get; }
		public int DefaultHeight { get; }
		public bool IsModelTexture { get; }
		public string ModelBinding { get; }
	}
}
