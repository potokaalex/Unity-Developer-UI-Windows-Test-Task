using System;
using CodeBase.Lobby;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;
using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusAdapter : IInitializable
    {
        private readonly UIModel _model;
        private readonly WindowsManager _windowsManager;
        private readonly LobbyConfigProvider _configProvider;
        private readonly DailyBonusUIFactory _dailyBonusUIFactory;

        private DailyBonusCongratsView _congratsView;
        private DailyBonusOverviewView _overviewView;
        private LobbyConfig _config;

        public DailyBonusAdapter(UIModel model, WindowsManager windowsManager,
            LobbyConfigProvider configProvider, DailyBonusUIFactory dailyBonusUIFactory)
        {
            _model = model;
            _windowsManager = windowsManager;
            _configProvider = configProvider;
            _dailyBonusUIFactory = dailyBonusUIFactory;
        }

        private int ConsecutiveEntryCount => _model.ReadOnlyData.PlayerProgress.ConsecutiveEntryCount;

        public void Initialize()
        {
            _config = _configProvider.GetConfig();
            _congratsView = _dailyBonusUIFactory.CreateCongratsView();
            _overviewView = _dailyBonusUIFactory.CreateOverviewView();

            _congratsView.Initialize();
            _overviewView.Initialize();

            _windowsManager.RegisterWindow(WindowType.DailyBonusCongrats, _congratsView);
            _windowsManager.RegisterWindow(WindowType.DailyBonusOverview, _overviewView);

            CheckDailyBonus();
            _overviewView.SetSliderProgress(ConsecutiveEntryCount); //TODO: call by event
        }

        public void GetWeeklyBonus()
        {
            if (ConsecutiveEntryCount > _config.DailyBonusCountItemPresets.Count)
            {
                OpenCongratsWindow(_config.WeeklyBonusCountItemPreset);
                _model.SetConsecutiveEntryCount(0);
                _overviewView.SetSliderProgress(ConsecutiveEntryCount);
            }
        }

        private void CheckDailyBonus()
        {
            var lastExitData = _model.ReadOnlyData.PlayerProgress.LastExitOADate;
            var difference = DateTime.Now.ToOADate() - lastExitData;
            var presets = _config.DailyBonusCountItemPresets;

            if (difference < 1 && lastExitData != 0)
                return;
            if (difference > 2)
                _model.SetConsecutiveEntryCount(0);

            if (ConsecutiveEntryCount < presets.Count)
                OpenCongratsWindow(presets[ConsecutiveEntryCount]);

            if (ConsecutiveEntryCount <= presets.Count)
                _model.SetConsecutiveEntryCount(ConsecutiveEntryCount + 1);
        }

        private void OpenCongratsWindow(DailyBonusCountItemPreset preset)
        {
            _windowsManager.ToggleCurrentWindow(WindowType.DailyBonusCongrats);
            _congratsView.SetTicketsCount(preset.TicketsCount);
            _congratsView.SetDayNumber(preset.DayNumber);
            _model.AddTicketsCount(preset.TicketsCount);
        }
    }
}