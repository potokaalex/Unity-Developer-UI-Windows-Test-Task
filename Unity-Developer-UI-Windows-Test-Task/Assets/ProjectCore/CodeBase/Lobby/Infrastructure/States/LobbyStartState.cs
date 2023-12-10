using CodeBase.Lobby.Main;
using CodeBase.Project.Services;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.StateMachineService;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Model;
using CodeBase.UI.Settings;
using CodeBase.UI.Shop;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

namespace CodeBase.Lobby.Infrastructure.States
{
    public class LobbyStartState : IEnterState, IExitState
    {
        private readonly GameDataSaveLoader _gameDataSaveLoader;
        private readonly UIModel _model;
        private readonly UnityEventsObserver _unityEventsObserver;
        private readonly StateMachine _stateMachine;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly SettingsAdapter _settingsAdapter;
        private readonly DailyBonusAdapter _dailyBonusAdapter;
        private readonly ShopAdapter _shopAdapter;
        private readonly LevelsAdapter _levelsAdapter;

        public LobbyStartState(GameDataSaveLoader gameDataSaveLoader, UIModel model,
            UnityEventsObserver unityEventsObserver, StateMachine stateMachine, LobbyMainAdapter mainAdapter,
            SettingsAdapter settingsAdapter, DailyBonusAdapter dailyBonusAdapter, ShopAdapter shopAdapter,
            LevelsAdapter levelsAdapter)
        {
            _gameDataSaveLoader = gameDataSaveLoader;
            _model = model;
            _unityEventsObserver = unityEventsObserver;
            _stateMachine = stateMachine;
            _mainAdapter = mainAdapter;
            _settingsAdapter = settingsAdapter;
            _dailyBonusAdapter = dailyBonusAdapter;
            _shopAdapter = shopAdapter;
            _levelsAdapter = levelsAdapter;
        }

        public void Enter()
        {
            InitializeUnityServices();
            _gameDataSaveLoader.RegisterWatcher(_model);
            _gameDataSaveLoader.Load();
            InitializeUI();

            _unityEventsObserver.OnApplicationExitEvent += _stateMachine.SwitchTo<LobbyExitState>;
        }

        public void Exit() => _unityEventsObserver.OnApplicationExitEvent -= _stateMachine.SwitchTo<LobbyExitState>;

        private async void InitializeUnityServices()
        {
            try
            {
                var options = new InitializationOptions().SetEnvironmentName("production");
                await UnityServices.InitializeAsync(options);
            }
            catch
            {
                // ignored
            }
        }

        private void InitializeUI()
        {
            _mainAdapter.Initialize();
            _settingsAdapter.Initialize();
            _dailyBonusAdapter.Initialize();
            _shopAdapter.Initialize();
            _levelsAdapter.Initialize();
        }
    }
}