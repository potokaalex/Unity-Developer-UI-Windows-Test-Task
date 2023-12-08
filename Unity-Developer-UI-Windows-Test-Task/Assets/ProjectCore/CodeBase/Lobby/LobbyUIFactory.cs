using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly LobbySettingsUIFactory _settingsUIFactory;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbySettingsAdapter _settingsAdapter;
        private readonly LobbyAudioManagerProvider _audioManagerProvider;
        private readonly LobbyWindowsManager _windowsManager;

        public LobbyUIFactory(IInstantiator instantiator, LobbyMainAdapter mainAdapter,
            LobbySettingsUIFactory settingsUIFactory, LobbyStaticDataProvider staticDataProvider,
            LobbySettingsAdapter settingsAdapter, LobbyAudioManagerProvider audioManagerProvider,
            LobbyWindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _mainAdapter = mainAdapter;
            _settingsUIFactory = settingsUIFactory;
            _staticDataProvider = staticDataProvider;
            _settingsAdapter = settingsAdapter;
            _audioManagerProvider = audioManagerProvider;
            _windowsManager = windowsManager;
        }

        public void Create()
        {
            var audioManager = _audioManagerProvider.GetManager();
            var mainView = CreateMainView();
            var settingsView = _settingsUIFactory.CreateView(mainView.GetViewsRoot(), _settingsAdapter);

            _windowsManager.Initialize(settingsView);
            _mainAdapter.Initialize(mainView, audioManager);
            _settingsAdapter.Initialize();
        }

        private LobbyMainView CreateMainView()
        {
            var prefab = _staticDataProvider.GetConfig().MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyMainView>(prefab);

            return item;
        }
    }
}