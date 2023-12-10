using CodeBase.Lobby.WindowsManager;
using CodeBase.Project.Data;

namespace CodeBase.Lobby.Levels
{
    public class LobbyLevelsAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyModel _model;
        private readonly LobbyWindowsManager _windowsManager;
        private LobbyLevelsView _levelsView;
        private PlayerProgressData _playerProgressData;

        public LobbyLevelsAdapter(LobbyModel model, LobbyWindowsManager windowsManager)
        {
            _model = model;
            _windowsManager = windowsManager;
        }

        public void Initialize(LobbyLevelsView levelsView)
        {
            _playerProgressData = _model.GetGameData().PlayerProgress;
            _levelsView = levelsView;
            _levelsView.Initialize(_playerProgressData.ReachedLevel);
        }

        public void OnOpenLevelClicked(int levelNumber)
        {
            if (levelNumber != _playerProgressData.ReachedLevel + 1)
                return;

            _model.SetNextLevel();
            _levelsView.OnReachedLevelChanged(levelNumber + 1);
        }

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}