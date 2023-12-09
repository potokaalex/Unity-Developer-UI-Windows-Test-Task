using System;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Settings;
using CodeBase.Utilities.UI;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyWindowsManager
    {
        private LobbySettingsView _settingsView;
        private WindowBase _dailyBonusCongratsWindow;
        private WindowBase _dailyBonusOverviewWindow;

        private LobbyWindowType _currentWindowType;
        private WindowBase _currentWindow;

        public void Initialize(LobbySettingsView settingsView, LobbyDailyBonusOverviewView dailyBonusOverviewWindow,
            LobbyDailyBonusCongratsView dailyBonusCongratsWindow)
        {
            _settingsView = settingsView;
            _dailyBonusOverviewWindow = dailyBonusOverviewWindow;
            _dailyBonusCongratsWindow = dailyBonusCongratsWindow;
        }

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
                case LobbyWindowType.DailyBonusCongrats:
                    OpenWindow(_dailyBonusCongratsWindow);
                    break;
                case LobbyWindowType.DailyBonusOverview:
                    OpenWindow(_dailyBonusOverviewWindow);
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