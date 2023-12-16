using CodeBase.Common.Data;

namespace CodeBase.UI.Levels
{
    public interface ILevelsModel
    {
        public EventField<int> CompletedLevelNumber { get; }
    }
}