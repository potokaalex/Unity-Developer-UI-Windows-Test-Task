using CodeBase.Project.Data;

namespace CodeBase.UI.Levels
{
    public interface ILevelsModel
    {
        public EventField<int> CompletedLevelNumber { get; }
    }
}