using System.Collections.Generic;

namespace DevilDaggersCore.Mods
{
	public class AudioAssetData : AssetData
	{
		public AudioAssetData(string assetName, string description, bool isProhibited, List<string> tags, float defaultLoudness, bool presentInDefaultLoudness)
			: base(assetName, description, isProhibited, tags)
		{
			DefaultLoudness = defaultLoudness;
			PresentInDefaultLoudness = presentInDefaultLoudness;
		}

		public float DefaultLoudness { get; }

		public bool PresentInDefaultLoudness { get; }
	}
}
