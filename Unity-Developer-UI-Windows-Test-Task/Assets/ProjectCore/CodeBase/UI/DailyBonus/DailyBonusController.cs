using System;
using CodeBase.Common.Services.WindowsManagerService;
using CodeBase.UI.DailyBonus.View;
using CodeBase.UI.DailyBonus.View.CountItem;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusController
    {
        private readonly IDailyBonusModel _model;
        private readonly WindowsManager _windowsManager;
        private DailyBonusConfig _config;
        private DailyBonusCongratsView _congratsView;
        private DailyBonusOverviewView _overviewView;

        public DailyBonusController(IDailyBonusModel model, WindowsManager windowsManager)
        {
            _model = model;
            _windowsManager = windowsManager;
        }

        public void Initialize(DailyBonusConfig config, DailyBonusCongratsView congratsView,
            DailyBonusOverviewView overviewView)
        {
            _config = config;
            _congratsView = congratsView;
            _overviewView = overviewView;

            _congratsView.Close();
            _overviewView.Initialize(_config.DaysContToReachWeeklyBonus);

            CheckDailyBonus();
            OverviewSetProgress();
        }

        public void GetWeeklyBonus()
        {
            var entryCount = _model.ConsecutiveEntryCount;

            if (entryCount.Value >= _config.DaysContToReachWeeklyBonus)
            {
                OpenCongratsWindow(_config.WeeklyBonusCountItemPreset);
                entryCount.Value = _config.FirstDayNumber - 1;
                OverviewSetProgress();
            }
        }

        private void OverviewSetProgress() => _overviewView.SetProgress(_model.ConsecutiveEntryCount.Value);

        private void CheckDailyBonus()
        {
            var lastExitData = _model.LastExitOADate.Value;
            var difference = DateTime.Now.ToOADate() - lastExitData;
            var entryCount = _model.ConsecutiveEntryCount;
            var daysToReachBonus = _config.DaysCountToReachDailyBonus;

            if (difference < daysToReachBonus && lastExitData != 0)
                return;

            if (difference > daysToReachBonus * 2 || lastExitData == 0)
                entryCount.Value = _config.FirstDayNumber;
            else
                entryCount.Value += 1;

            foreach (var preset in _config.CountItemsPresets)
                if (preset.DayNumber == entryCount.Value)
                    OpenCongratsWindow(preset);
        }

        private void OpenCongratsWindow(DailyBonusCountItemData preset)
        {
            _windowsManager.ToggleCurrentWindow(WindowType.DailyBonusCongrats);
            _congratsView.SetTicketsCount(preset.TicketsCount);
            _congratsView.SetDayNumber(preset.DayNumber);
            _model.TicketsCount.Value += preset.TicketsCount;
        }
    }
}