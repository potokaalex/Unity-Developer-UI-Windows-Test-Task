using System;
using CodeBase.Lobby.Data;
using CodeBase.Project.Data;
using CodeBase.Project.Services;
using CodeBase.Project.Services.WindowsManagerService;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsAdapter
    {
        private readonly AudioManager _audioManager;
        private readonly LobbyModel _model;
        private readonly WindowsManager _windowsManager;
        private GameSettingsData _data;

        public LobbySettingsAdapter(AudioManager audioManager, LobbyModel model, WindowsManager windowsManager)
        {
            _audioManager = audioManager;
            _model = model;
            _windowsManager = windowsManager;
        }

        public void Initialize(LobbySettingsView settingsView)
        {
            _data = _model.GetGameData().Settings;
            _windowsManager.RegisterWindow(WindowType.Settings, settingsView);

            SetMusicActive(_data.IsMusicActive);
            SetUISoundActive(_data.IsUISoundActive);
        }

        public void Set(LobbySettingsToggleType settingsType, bool isActive)
        {
            switch (settingsType)
            {
                case LobbySettingsToggleType.Music:
                    SetMusicActive(isActive);
                    break;
                case LobbySettingsToggleType.UISound:
                    SetUISoundActive(isActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(settingsType), settingsType, null);
            }
        }

        private void SetMusicActive(bool isActive)
        {
            _audioManager.SetMusicActive(isActive);
            _data.IsMusicActive = isActive;
        }

        private void SetUISoundActive(bool isActive)
        {
            _audioManager.SetUISoundActive(isActive);
            _data.IsUISoundActive = isActive;
        }
    }
}