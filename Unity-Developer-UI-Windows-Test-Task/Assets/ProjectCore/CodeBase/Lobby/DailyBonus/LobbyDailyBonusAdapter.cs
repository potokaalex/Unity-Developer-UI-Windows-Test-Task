using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Project.Data;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyModel _model;
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyStaticDataProvider _staticDataProvider;

        private LobbyDailyBonusCongratsView _congratsView;
        private LobbyDailyBonusOverviewView _overviewView;
        private LobbyConfig _config;
        private GameData _data;

        public LobbyDailyBonusAdapter(LobbyModel model, LobbyWindowsManager windowsManager,
            LobbyStaticDataProvider staticDataProvider)
        {
            _model = model;
            _windowsManager = windowsManager;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize(LobbyDailyBonusCongratsView congratsView, LobbyDailyBonusOverviewView overviewView)
        {
            _congratsView = congratsView;
            _overviewView = overviewView;
            _config = _staticDataProvider.GetConfig();
            _data = _model.GetGameData();

            CheckDailyBonus();
            _overviewView.SetSliderProgress(_data.ConsecutiveEntryCount);
        }

        public void GetWeeklyBonus()
        {
            if (_data.ConsecutiveEntryCount > _config.DailyBonusCountItemPresets.Count)
            {
                OpenCongratsWindow(_config.WeeklyBonusCountItemPreset);
                _data.ConsecutiveEntryCount = 0;
                _overviewView.SetSliderProgress(_data.ConsecutiveEntryCount);
            }
        }

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();

        private void CheckDailyBonus()
        {
            var currentDate = DateTime.Now.ToOADate();
            var difference = currentDate - _data.LastEntryOADate;
            var presets = _config.DailyBonusCountItemPresets;

            if (difference > 1)
                _data.ConsecutiveEntryCount = 0;

            if (_data.ConsecutiveEntryCount < presets.Count)
            {
                OpenCongratsWindow(presets[_data.ConsecutiveEntryCount]);
                _data.ConsecutiveEntryCount++;
            }
            else if (_data.ConsecutiveEntryCount == presets.Count)
                _data.ConsecutiveEntryCount++;
        }

        private void OpenCongratsWindow(LobbyDailyBonusCountItemPreset preset)
        {
            _windowsManager.ToggleCurrentWindow(LobbyWindowType.DailyBonusCongrats);
            _congratsView.SetTicketsCount(preset.TicketsCount);
            _congratsView.SetDayNumber(preset.DayNumber);
            _model.AddTicketsCount(preset.TicketsCount);
        }
    }
}