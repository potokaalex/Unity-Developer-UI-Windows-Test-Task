using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Project.Data;
using CodeBase.Project.Services.AudioManagerService;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly IAudioManager _audioManager;
        private readonly LobbyModel _model;
        private readonly LobbyWindowsManager _windowsManager;
        private GameSettingsData _data;

        public LobbySettingsAdapter(IAudioManager audioManager, LobbyModel model, LobbyWindowsManager windowsManager)
        {
            _audioManager = audioManager;
            _model = model;
            _windowsManager = windowsManager;
        }

        public void Initialize()
        {
            _data = _model.GetGameData().Settings;

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

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}