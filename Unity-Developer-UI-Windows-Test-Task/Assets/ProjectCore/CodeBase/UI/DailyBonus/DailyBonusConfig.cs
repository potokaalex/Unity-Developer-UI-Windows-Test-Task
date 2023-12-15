using System;
using System.Collections.Generic;
using CodeBase.UI.DailyBonus.View;
using CodeBase.UI.DailyBonus.View.CountItem;

namespace CodeBase.UI.DailyBonus
{
    [Serializable]
    public class DailyBonusConfig
    {
        public DailyBonusCongratsView DailyBonusCongratsViewPrefab;
        public DailyBonusOverviewView DailyBonusOverviewViewPrefab;
        public DailyBonusCountItemView DailyBonusCountItemViewPrefab;
        public List<DailyBonusCountItemData> CountItemsPresets;
        public DailyBonusCountItemData WeeklyBonusCountItemPreset;
        public int DaysContToReachWeeklyBonus;
        public float DaysCountToReachDailyBonus;
        public int FirstDayNumber;
    }
}