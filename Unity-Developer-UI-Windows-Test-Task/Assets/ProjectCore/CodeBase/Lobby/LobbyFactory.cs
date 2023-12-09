using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.WindowsManager;
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
        private readonly LobbyDailyBonusAdapter _dailyBonusAdapter;

        public LobbyFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyAudioManagerProvider audioManagerProvider, LobbyMainUIFactory mainUIFactory,
            LobbySettingsUIFactory settingsUIFactory, LobbyDailyBonusUIFactory dailyBonusUIFactory,
            LobbyWindowsManager windowsManager, LobbyMainAdapter mainAdapter, LobbySettingsAdapter settingsAdapter,
            LobbyDailyBonusAdapter dailyBonusAdapter)
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
            _dailyBonusAdapter = dailyBonusAdapter;
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
            var viewsRoot = mainView.GetViewsRoot();
            var settingsView = _settingsUIFactory.CreateView(viewsRoot);
            var congratsView = _dailyBonusUIFactory.CreateCongratsView(viewsRoot);
            var overviewView = _dailyBonusUIFactory.CreateOverviewView(viewsRoot);

            _windowsManager.Initialize(settingsView, overviewView, congratsView);

            _mainAdapter.Initialize(mainView);
            _settingsAdapter.Initialize();
            _dailyBonusAdapter.Initialize(congratsView, overviewView);
        }
    }
}