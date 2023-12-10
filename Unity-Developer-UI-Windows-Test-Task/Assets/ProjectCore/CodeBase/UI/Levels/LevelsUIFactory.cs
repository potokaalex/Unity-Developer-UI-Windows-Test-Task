using CodeBase.Lobby;
using CodeBase.Lobby.Infrastructure;
using CodeBase.Project.Services.WindowsManagerService;
using Zenject;

namespace CodeBase.UI.Levels
{
    public class LevelsUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly WindowsManager _windowsManager;
        private LobbyConfig _config;

        public LevelsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public LobbyLevelsView CreateView()
        {
            var prefab = _config.LobbyLevelsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyLevelsView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }
    }
}