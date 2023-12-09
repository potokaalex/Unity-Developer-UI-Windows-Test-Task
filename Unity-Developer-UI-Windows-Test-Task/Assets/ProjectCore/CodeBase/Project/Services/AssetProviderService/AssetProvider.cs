using UnityEngine;

namespace CodeBase.Project.Services.AssetProviderService
{
    public class AssetProvider : IAssetProvider
    {
        public T Get<T>(string path) where T : Object => Resources.Load<T>(path);
    }
}