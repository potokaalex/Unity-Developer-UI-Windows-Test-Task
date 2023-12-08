using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.StateMachineService;

namespace CodeBase.Lobby.Infrastructure.States
{
    public class LobbyExitState : IEnterState
    {
        private readonly GameDataSaveLoader _gameDataSaveLoader;
        private readonly LobbyModel _model;

        public LobbyExitState(GameDataSaveLoader gameDataSaveLoader) => _gameDataSaveLoader = gameDataSaveLoader;

        public void Enter() => _gameDataSaveLoader.Save();
    }
}