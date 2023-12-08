using System;
using ProjectCore.CodeBase.Lobby.Data;
using ProjectCore.CodeBase.Lobby.Settings;
using ProjectCore.CodeBase.Utilities;
using ProjectCore.CodeBase.Utilities.UI;

namespace ProjectCore.CodeBase.Lobby.Main
{
    public class LobbyMainAdapter
    {
        private LobbySettingsView _settingsView;
        private LobbyWindowType _currentWindowType;
        private WindowBase _currentWindow;

        public void Initialize(LobbySettingsView settingsView) => _settingsView = settingsView;

        public void ToggleCurrentWindow(LobbyWindowType windowType)
        {
            CloseCurrentWindow();

            if (_currentWindowType == windowType)
                return;

            switch (windowType)
            {
                case LobbyWindowType.Settings:
                    OpenWindow(_settingsView);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowType), windowType, null);
            }
        }

        public void CloseCurrentWindow()
        {
            _currentWindow?.Close();
            _currentWindowType = LobbyWindowType.None;
        }

        private void OpenWindow(WindowBase window)
        {
            _currentWindow = window;
            _currentWindow.Open();
        }
    }
}