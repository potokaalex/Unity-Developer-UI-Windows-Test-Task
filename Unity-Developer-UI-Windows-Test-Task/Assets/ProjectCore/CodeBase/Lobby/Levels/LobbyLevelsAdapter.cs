using CodeBase.Project.Data;
using CodeBase.Project.Services.WindowsManagerService;

namespace CodeBase.Lobby.Levels
{
    public class LobbyLevelsAdapter
    {
        private readonly LobbyModel _model;
        private readonly WindowsManager _windowsManager;
        private LobbyLevelsView _levelsView;
        private SavedPlayerProgressData _playerProgressData;

        public LobbyLevelsAdapter(LobbyModel model, WindowsManager windowsManager)
        {
            _model = model;
            _windowsManager = windowsManager;
        }

        public void Initialize(LobbyLevelsView levelsView)
        {
            _windowsManager.RegisterWindow(WindowType.Levels, levelsView);
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
    }
}