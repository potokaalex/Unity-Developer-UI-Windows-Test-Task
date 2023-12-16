using UnityEngine;

namespace CodeBase.Common.Services.AssetProviderService
{
    public class AssetProvider : IAssetProvider
    {
        public Sprite GetIcon(string path) => Resources.Load<Sprite>(path);
    }
}