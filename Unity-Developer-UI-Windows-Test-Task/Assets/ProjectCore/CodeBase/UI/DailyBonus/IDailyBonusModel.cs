using CodeBase.Common.Data;

namespace CodeBase.UI.DailyBonus
{
    public interface IDailyBonusModel
    {
        public EventField<int> TicketsCount { get; }

        public EventField<double> LastExitOADate { get; }

        public EventField<int> ConsecutiveEntryCount { get; }
    }
}