using CodeBase.Project.Services;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.StateMachineService;

namespace CodeBase.Lobby.Infrastructure.States
{
    public class LobbyStartState : IEnterState, IExitState
    {
        private readonly LobbyUIFactory _uiFactory;
        private readonly GameDataSaveLoader _gameDataSaveLoader;
        private readonly LobbyModel _model;
        private readonly UnityEventsObserver _unityEventsObserver;
        private readonly StateMachine _stateMachine;
        private readonly LobbyFactory _lobbyFactory;

        public LobbyStartState(LobbyUIFactory uiFactory, GameDataSaveLoader gameDataSaveLoader, LobbyModel model,
            UnityEventsObserver unityEventsObserver, StateMachine stateMachine, LobbyFactory lobbyFactory)
        {
            _uiFactory = uiFactory;
            _gameDataSaveLoader = gameDataSaveLoader;
            _model = model;
            _unityEventsObserver = unityEventsObserver;
            _stateMachine = stateMachine;
            _lobbyFactory = lobbyFactory;
        }

        public void Enter()
        {
            _gameDataSaveLoader.RegisterWatcher(_model);
            _gameDataSaveLoader.Load();
            _lobbyFactory.CreateAudioManager();
            _uiFactory.Create();            

            _unityEventsObserver.OnApplicationExitEvent += _stateMachine.SwitchTo<LobbyExitState>;
        }

        public void Exit() => _unityEventsObserver.OnApplicationExitEvent -= _stateMachine.SwitchTo<LobbyExitState>;
    }
}