using System;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Utilities.UI;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyWindowsManager
    {
        private LobbySettingsView _settingsView;
        private LobbyDailyBonusCongratsView _dailyBonusCongratsWindow;
        private LobbyDailyBonusOverviewView _dailyBonusOverviewWindow;
        private LobbyShopView _shopView;

        private LobbyWindowType _currentWindowType;
        private WindowBase _currentWindow;

        public void Initialize(LobbySettingsView settingsView, LobbyDailyBonusOverviewView dailyBonusOverviewWindow,
            LobbyDailyBonusCongratsView dailyBonusCongratsWindow, LobbyShopView shopView)
        {
            _settingsView = settingsView;
            _dailyBonusOverviewWindow = dailyBonusOverviewWindow;
            _dailyBonusCongratsWindow = dailyBonusCongratsWindow;
            _shopView = shopView;
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
                case LobbyWindowType.Shop:
                    OpenWindow(_shopView);
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