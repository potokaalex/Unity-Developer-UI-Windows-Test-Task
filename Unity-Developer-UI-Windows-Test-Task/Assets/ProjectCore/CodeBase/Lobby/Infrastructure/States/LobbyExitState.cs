using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.StateMachineService;
using CodeBase.UI.Model;

namespace CodeBase.Lobby.Infrastructure.States
{
    public class LobbyExitState : IEnterState
    {
        private readonly GameDataSaveLoader _gameDataSaveLoader;
        private readonly UIModel _model;

        public LobbyExitState(GameDataSaveLoader gameDataSaveLoader) => _gameDataSaveLoader = gameDataSaveLoader;

        public void Enter() => _gameDataSaveLoader.Save();
    }
}