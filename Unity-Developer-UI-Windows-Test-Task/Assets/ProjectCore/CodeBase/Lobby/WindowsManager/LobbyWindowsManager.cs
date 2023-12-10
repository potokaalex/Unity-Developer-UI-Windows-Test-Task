using System;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Utilities.UI;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyWindowsManager
    {
        private LobbySettingsView _settingsView;
        private DailyBonusCongratsView _dailyBonusCongratsWindow;
        private DailyBonusOverviewView _dailyBonusOverviewWindow;
        private LobbyShopView _shopView;
        private LobbyLevelsView _levelsView;

        private LobbyWindowType _currentWindowType;
        private WindowBase _currentWindow;

        public void Initialize(LobbySettingsView settingsView, DailyBonusOverviewView dailyBonusOverviewWindow,
            DailyBonusCongratsView dailyBonusCongratsWindow, LobbyShopView shopView,LobbyLevelsView levelsView)
        {
            _settingsView = settingsView;
            _dailyBonusOverviewWindow = dailyBonusOverviewWindow;
            _dailyBonusCongratsWindow = dailyBonusCongratsWindow;
            _shopView = shopView;
            _levelsView = levelsView;
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
                case LobbyWindowType.Levels:
                    OpenWindow(_levelsView);
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