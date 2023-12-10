using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.DailyBonus;

namespace CodeBase.Lobby
{
    public class LobbyFactory
    {
        private readonly SettingsUIFactory _settingsUIFactory;
        private readonly DailyBonusUIFactory _dailyBonusUIFactory;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly SettingsAdapter _settingsAdapter;
        private readonly DailyBonusAdapter _dailyBonusAdapter;
        private readonly LobbyShopUIFactory _shopUIFactory;
        private readonly LobbyShopAdapter _shopAdapter;
        private readonly LevelsUIFactory _levelsUIFactory;
        private readonly LobbyLevelsAdapter _levelsAdapter;
        private readonly WindowsManager _windowsManager;

        public LobbyFactory(SettingsUIFactory settingsUIFactory, DailyBonusUIFactory dailyBonusUIFactory,
            LobbyMainAdapter mainAdapter, SettingsAdapter settingsAdapter,
            DailyBonusAdapter dailyBonusAdapter, LobbyShopUIFactory shopUIFactory, LobbyShopAdapter shopAdapter,
            LevelsUIFactory levelsUIFactory, LobbyLevelsAdapter levelsAdapter, WindowsManager windowsManager)
        {
            _settingsUIFactory = settingsUIFactory;
            _dailyBonusUIFactory = dailyBonusUIFactory;
            _mainAdapter = mainAdapter;
            _settingsAdapter = settingsAdapter;
            _dailyBonusAdapter = dailyBonusAdapter;
            _shopUIFactory = shopUIFactory;
            _shopAdapter = shopAdapter;
            _levelsUIFactory = levelsUIFactory;
            _levelsAdapter = levelsAdapter;
            _windowsManager = windowsManager;
        }

        public void CreateUI()
        {
            _mainAdapter.Initialize();
            _settingsAdapter.Initialize();
            _dailyBonusAdapter.Initialize();
            
            var viewsRoot = _windowsManager.WindowsRoot;
            //var congratsView = _dailyBonusUIFactory.CreateCongratsView(viewsRoot);
            //var overviewView = _dailyBonusUIFactory.CreateOverviewView(viewsRoot);
            var shopView = _shopUIFactory.CreateView(viewsRoot);
            var levelsView = _levelsUIFactory.CreateView(viewsRoot);

            _shopAdapter.Initialize(shopView);
            _levelsAdapter.Initialize(levelsView);
        }
    }
}