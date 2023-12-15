using System;

namespace CodeBase.UI.Levels
{
    public class LevelsController : IDisposable
    {
        private readonly ILevelsModel _model;
        private LevelsConfig _config;
        private LevelsView _view;

        public LevelsController(ILevelsModel model) => _model = model;

        public void Initialize(LevelsConfig config, LevelsView view)
        {
            _config = config;
            _view = view;

            for (var i = 0; i < _config.LevelsCount; i++)
            {
                var isLocked = i > _model.CompletedLevelNumber.Value;
                _view.OpenLevelButtons[i].Initialize(i + 1, isLocked);
            }

            _view.Close();

            _model.CompletedLevelNumber.OnChanged += UnlockOpenLevelButton;
        }

        public void Dispose() => _model.CompletedLevelNumber.OnChanged -= UnlockOpenLevelButton;

        public void OpenLevel(int levelNumber)
        {
            if (levelNumber != _model.CompletedLevelNumber.Value + 1)
                return;

            _model.CompletedLevelNumber.Value++;
        }

        private void UnlockOpenLevelButton(int passedLevelNumber)
        {
            if (passedLevelNumber < _view.OpenLevelButtons.Count)
                _view.OpenLevelButtons[passedLevelNumber].SetLock(false);
        }
    }
}