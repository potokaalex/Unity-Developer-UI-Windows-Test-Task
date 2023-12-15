using CodeBase.Project.Data;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.UI.Settings;

namespace CodeBase.Lobby.UI
{
    public class LobbyModel : IGameDataReader, IGameDataWriter, ISettingsModel
    {
        public EventField<int> TicketsCount { get; private set; }

        public EventField<bool> IsMusicActive { get; private set; }

        public EventField<bool> IsUISoundActive { get; private set; }

        public void OnGameDataLoad(SavedGameData data)
        {
            TicketsCount = new EventField<int>(data.PlayerProgress.TicketsCount);
            IsMusicActive = new EventField<bool>(data.Settings.IsMusicActive);
            IsUISoundActive = new EventField<bool>(data.Settings.IsUISoundActive);
        }

        public void OnGameDataSave(SavedGameData data)
        {
            data.PlayerProgress.TicketsCount = TicketsCount.Value;
            data.Settings.IsMusicActive = IsMusicActive.Value;
            data.Settings.IsUISoundActive = IsUISoundActive.Value;
        }
    }
}