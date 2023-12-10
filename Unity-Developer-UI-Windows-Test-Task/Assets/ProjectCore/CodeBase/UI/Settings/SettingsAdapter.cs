using System;
using CodeBase.Project.Services;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;
using Zenject;

namespace CodeBase.UI.Settings
{
    public class SettingsAdapter : IInitializable
    {
        private readonly AudioManager _audioManager;
        private readonly UIModel _model;
        private readonly WindowsManager _windowsManager;
        private readonly SettingsUIFactory _settingsUIFactory;

        public SettingsAdapter(AudioManager audioManager, UIModel model, WindowsManager windowsManager,
            SettingsUIFactory settingsUIFactory)
        {
            _audioManager = audioManager;
            _model = model;
            _windowsManager = windowsManager;
            _settingsUIFactory = settingsUIFactory;
        }

        public void Initialize()
        {
            var settingsData = _model.ReadOnlyData.Settings;
            var settingsView = _settingsUIFactory.CreateView();

            settingsView.Initialize(settingsData.IsMusicActive, settingsData.IsUISoundActive);
            _windowsManager.RegisterWindow(WindowType.Settings, settingsView);

            //TODO: call by event
            SetMusicActive(settingsData.IsMusicActive);
            SetUISoundActive(settingsData.IsUISoundActive);
        }

        public void SetActive(SettingsToggleType settingsType, bool isActive)
        {
            switch (settingsType)
            {
                case SettingsToggleType.Music:
                    SetMusicActive(isActive);
                    break;
                case SettingsToggleType.UISound:
                    SetUISoundActive(isActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(settingsType), settingsType, null);
            }
        }

        private void SetMusicActive(bool isActive)
        {
            _audioManager.SetMusicActive(isActive);
            _model.SetMusicActive(isActive);
        }

        private void SetUISoundActive(bool isActive)
        {
            _audioManager.SetUISoundActive(isActive);
            _model.SetUISoundActive(isActive);
        }
    }
}