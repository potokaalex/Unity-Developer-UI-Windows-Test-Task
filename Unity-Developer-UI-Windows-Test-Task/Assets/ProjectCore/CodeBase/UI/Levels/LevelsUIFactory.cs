using CodeBase.Lobby;
using CodeBase.Lobby.Data;
using CodeBase.Project.Services.WindowsManagerService;
using Zenject;

namespace CodeBase.UI.Levels
{
    public class LevelsUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyConfigProvider _configProvider;
        private readonly WindowsManager _windowsManager;
        private LobbyConfig _config;

        public LevelsUIFactory(IInstantiator instantiator, LobbyConfigProvider configProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public LobbyLevelsView CreateView()
        {
            var prefab = _config.LobbyLevelsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyLevelsView>(prefab);

            item.transform.SetParent(null, false);

            return item;
        }
    }
}