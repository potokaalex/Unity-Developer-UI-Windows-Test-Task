using UnityEngine;

namespace CodeBase.Common.Services.AssetProviderService
{
    public interface IAssetProvider
    {
        public Sprite GetIcon(string path);
    }
}