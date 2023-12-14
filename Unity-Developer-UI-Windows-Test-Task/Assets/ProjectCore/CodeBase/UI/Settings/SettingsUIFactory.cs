using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure;
using CodeBase.Project.Services.WindowsManagerService;
using Zenject;

namespace CodeBase.UI.Settings
{
    public class SettingsUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyConfigProvider _configProvider;
        private readonly WindowsManager _windowsManager;

        public SettingsUIFactory(IInstantiator instantiator, LobbyConfigProvider configProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _windowsManager = windowsManager;
        }

        public SettingsView CreateView()
        {
            var prefab = _configProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<SettingsView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }
    }
}