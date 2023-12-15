using CodeBase.Project.Data;

namespace CodeBase.UI.Settings
{
    public interface ISettingsModel
    {
        public EventField<bool> IsMusicActive { get; }

        public EventField<bool> IsUISoundActive { get; }
    }
}