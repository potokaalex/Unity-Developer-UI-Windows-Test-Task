using System;
using CodeBase.Common.Services.AudioManagerService;

namespace CodeBase.UI.Settings
{
    public class SettingsController : IDisposable
    {
        private readonly AudioManager _audioManager;
        private readonly ISettingsModel _model;
        private SettingsView _view;

        public SettingsController(ISettingsModel model, AudioManager audioManager)
        {
            _model = model;
            _audioManager = audioManager;
        }

        public void Initialize(SettingsView view)
        {
            _view = view;

            _view.MusicToggle.Initialize(_model.IsMusicActive.Value);
            _view.UISoundToggle.Initialize(_model.IsUISoundActive.Value);
            _view.Close();

            _model.IsMusicActive.OnChanged += _view.MusicToggle.ShowActive;
            _model.IsUISoundActive.OnChanged += _view.UISoundToggle.ShowActive;
        }

        public void Dispose()
        {
            _model.IsMusicActive.OnChanged -= _view.MusicToggle.ShowActive;
            _model.IsUISoundActive.OnChanged -= _view.UISoundToggle.ShowActive;
        }

        public void SetMusicActive(bool isActive)
        {
            _audioManager.SetMusicActive(isActive);
            _model.IsMusicActive.Value = isActive;
        }

        public void SetUISoundActive(bool isActive)
        {
            _audioManager.SetUISoundActive(isActive);
            _model.IsUISoundActive.Value = isActive;
        }
    }
}