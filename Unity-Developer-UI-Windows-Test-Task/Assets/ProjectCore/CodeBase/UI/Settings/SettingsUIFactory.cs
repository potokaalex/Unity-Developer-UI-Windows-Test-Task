using CodeBase.Lobby.Infrastructure;
using CodeBase.Project.Services.WindowsManagerService;
using Zenject;

namespace CodeBase.UI.Settings
{
    public class SettingsUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly WindowsManager _windowsManager;

        public SettingsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
        }

        public SettingsView CreateView()
        {
            var prefab = _staticDataProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<SettingsView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }
    }
}