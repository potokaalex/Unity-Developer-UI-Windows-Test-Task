using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyAudioManagerProvider _audioManagerProvider;
        private readonly LobbyMainUIFactory _mainUIFactory;
        private readonly LobbySettingsUIFactory _settingsUIFactory;
        private readonly LobbyDailyBonusUIFactory _dailyBonusUIFactory;
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly LobbySettingsAdapter _settingsAdapter;

        public LobbyFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyAudioManagerProvider audioManagerProvider, LobbyMainUIFactory mainUIFactory,
            LobbySettingsUIFactory settingsUIFactory, LobbyDailyBonusUIFactory dailyBonusUIFactory,
            LobbyWindowsManager windowsManager, LobbyMainAdapter mainAdapter, LobbySettingsAdapter settingsAdapter)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _audioManagerProvider = audioManagerProvider;
            _mainUIFactory = mainUIFactory;
            _settingsUIFactory = settingsUIFactory;
            _dailyBonusUIFactory = dailyBonusUIFactory;
            _windowsManager = windowsManager;
            _mainAdapter = mainAdapter;
            _settingsAdapter = settingsAdapter;
        }

        public void CreateAudioManager()
        {
            var prefab = _staticDataProvider.GetConfig().AudioManagerPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyAudioManager>(prefab);

            _audioManagerProvider.Initialize(item);
        }

        public void CreateUI()
        {
            var mainView = _mainUIFactory.CreateView();
            var settingsView = _settingsUIFactory.CreateView(mainView.GetViewsRoot());
            _dailyBonusUIFactory.Create();

            _mainAdapter.Initialize(mainView);
            _settingsAdapter.Initialize();
            
            _windowsManager.Initialize(settingsView);
        }
    }
}