using CodeBase.Lobby.Data;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.UI
{
    public class LobbyUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyConfigProvider _configProvider;
        private readonly LobbyController _controller;
        private LobbyConfig _config;

        public LobbyUIFactory(IInstantiator instantiator, LobbyConfigProvider configProvider,LobbyController controller)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _controller = controller;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public void Create()
        {
            var viewsRoot = CreateRootCanvas().transform;
            var lobbyView = CreateView(viewsRoot);
            
            _controller.Initialize(lobbyView);
        }

        private Transform CreateRootCanvas()
        {
            var prefab = _config.CanvasPrefab;
            var instance = _instantiator.InstantiatePrefab(prefab);
            return instance.transform;
        }

        private LobbyView CreateView(Transform root)
        {
            var prefab = _config.ViewPrefab;
            var instance = _instantiator.InstantiatePrefabForComponent<LobbyView>(prefab);

            instance.transform.SetParent(root, false);
            return instance;
        }
    }
}