using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;

namespace CodeBase.UI.Levels
{
    public class LevelsAdapter
    {
        private readonly UIModel _model;
        private readonly WindowsManager _windowsManager;
        private LobbyLevelsView _levelsView;
        private readonly LevelsUIFactory _levelsUIFactory;

        public LevelsAdapter(UIModel model, WindowsManager windowsManager, LevelsUIFactory levelsUIFactory)
        {
            _model = model;
            _windowsManager = windowsManager;
            _levelsUIFactory = levelsUIFactory;
        }

        public void Initialize()
        {
            _levelsView = _levelsUIFactory.CreateView();
            _windowsManager.RegisterWindow(WindowType.Levels, _levelsView);
            _levelsView.Initialize(_model.ReadOnlyData.PlayerProgress.ReachedLevel);
        }

        public void OnOpenLevelClicked(int levelNumber)
        {
            if (levelNumber != _model.ReadOnlyData.PlayerProgress.ReachedLevel + 1)
                return;

            _model.SetNextLevel();
            _levelsView.OnReachedLevelChanged(levelNumber + 1);
        }
    }
}