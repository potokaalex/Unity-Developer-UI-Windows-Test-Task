using UnityEngine;

namespace CodeBase.Project.Services.AssetProviderService
{
    public interface IAssetProvider
    {
        public Sprite GetIcon(string path);
    }
}