using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Levels
{
    public class LevelsUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private LobbyConfig _config;

        public LevelsUIFactory(IInstantiator instantiator,LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public LobbyLevelsView CreateView(Transform root)
        {
            var prefab = _config.LobbyLevelsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyLevelsView>(prefab);

            item.transform.SetParent(root, false);
            
            return item;
        }
    }
}