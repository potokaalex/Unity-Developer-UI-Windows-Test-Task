using UnityEngine;

namespace CodeBase.Project.Services.AssetProviderService
{
    public interface IAssetProvider
    {
        public T Get<T>(string path) where T : Object;
    }
}