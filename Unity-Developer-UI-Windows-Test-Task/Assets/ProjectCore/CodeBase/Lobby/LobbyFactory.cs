using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Project.Services.WindowsManagerService;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyFactory
    {
        private readonly LobbyMainUIFactory _mainUIFactory;
        private readonly LobbySettingsUIFactory _settingsUIFactory;
        private readonly DailyBonusUIFactory _dailyBonusUIFactory;
        private readonly WindowsManager _windowsManager;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly LobbySettingsAdapter _settingsAdapter;
        private readonly DailyBonusAdapter _dailyBonusAdapter;
        private readonly LobbyShopUIFactory _shopUIFactory;
        private readonly LobbyShopAdapter _shopAdapter;
        private readonly LevelsUIFactory _levelsUIFactory;
        private readonly LobbyLevelsAdapter _levelsAdapter;

        public LobbyFactory(LobbyMainUIFactory mainUIFactory, LobbySettingsUIFactory settingsUIFactory,
            DailyBonusUIFactory dailyBonusUIFactory, WindowsManager windowsManager,
            LobbyMainAdapter mainAdapter, LobbySettingsAdapter settingsAdapter,
            DailyBonusAdapter dailyBonusAdapter, LobbyShopUIFactory shopUIFactory, LobbyShopAdapter shopAdapter,
            LevelsUIFactory levelsUIFactory, LobbyLevelsAdapter levelsAdapter)
        {
            _mainUIFactory = mainUIFactory;
            _settingsUIFactory = settingsUIFactory;
            _dailyBonusUIFactory = dailyBonusUIFactory;
            _windowsManager = windowsManager;
            _mainAdapter = mainAdapter;
            _settingsAdapter = settingsAdapter;
            _dailyBonusAdapter = dailyBonusAdapter;
            _shopUIFactory = shopUIFactory;
            _shopAdapter = shopAdapter;
            _levelsUIFactory = levelsUIFactory;
            _levelsAdapter = levelsAdapter;
        }

        public void CreateUI()
        {
            var mainView = _mainUIFactory.CreateView();
            var viewsRoot = mainView.GetViewsRoot();
            var settingsView = _settingsUIFactory.CreateView(viewsRoot);
            var congratsView = _dailyBonusUIFactory.CreateCongratsView(viewsRoot);
            var overviewView = _dailyBonusUIFactory.CreateOverviewView(viewsRoot);
            var shopView = _shopUIFactory.CreateView(viewsRoot);
            var levelsView = _levelsUIFactory.CreateView(viewsRoot);

            _mainAdapter.Initialize(mainView);
            _settingsAdapter.Initialize(settingsView);
            _dailyBonusAdapter.Initialize(congratsView, overviewView);
            _shopAdapter.Initialize(shopView);
            _levelsAdapter.Initialize(levelsView);
        }
    }
}