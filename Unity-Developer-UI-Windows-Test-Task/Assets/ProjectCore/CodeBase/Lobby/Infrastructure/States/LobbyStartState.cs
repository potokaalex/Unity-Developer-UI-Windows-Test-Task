using CodeBase.Lobby.UI;
using CodeBase.Project.Services;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.StateMachineService;
using Unity.Services.Core;
using UnityEngine;

namespace CodeBase.Lobby.Infrastructure.States
{
    public class LobbyStartState : IEnterState, IExitState
    {
        private readonly UnityEventsObserver _unityEventsObserver;
        private readonly StateMachine _stateMachine;
        private readonly LobbyUIFactory _lobbyUIFactory;
        private readonly GameDataSaveLoader _gameDataSaveLoader;
        private readonly LobbyModel _lobbyModel;

        public LobbyStartState(UnityEventsObserver unityEventsObserver, StateMachine stateMachine,
            LobbyUIFactory lobbyUIFactory, GameDataSaveLoader gameDataSaveLoader,LobbyModel lobbyModel)
        {
            _unityEventsObserver = unityEventsObserver;
            _stateMachine = stateMachine;
            _lobbyUIFactory = lobbyUIFactory;
            _gameDataSaveLoader = gameDataSaveLoader;
            _lobbyModel = lobbyModel;
        }

        public void Enter()
        {
            InitializeUnityServices();

            _gameDataSaveLoader.RegisterWatcher(_lobbyModel);
            _gameDataSaveLoader.Load();
            
            CreateUI();
            
            _unityEventsObserver.OnApplicationExitEvent += _stateMachine.SwitchTo<LobbyExitState>;
        }

        public void Exit() => _unityEventsObserver.OnApplicationExitEvent -= _stateMachine.SwitchTo<LobbyExitState>;

        private async void InitializeUnityServices()
        {
            try
            {
                await UnityServices.InitializeAsync(new InitializationOptions());
            }
            catch
            {
                Debug.LogError("Initialize Unity Services: FAILED!");
            }
        }

        private void CreateUI()
        {
            _lobbyUIFactory.Create();
        }
    }
}