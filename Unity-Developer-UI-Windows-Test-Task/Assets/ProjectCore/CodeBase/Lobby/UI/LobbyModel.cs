using CodeBase.Lobby.Infrastructure.States;
using CodeBase.Project.Data;
using CodeBase.Project.Services.SaveLoaderService;

namespace CodeBase.Lobby.UI
{
    public class LobbyModel : IGameDataReader, IGameDataWriter
    {
        public EventField<int> TicketsCount;

        public void OnGameDataLoad(SavedGameData data)
        {
            TicketsCount = new(data.PlayerProgress.TicketsCount);
        }

        public void OnGameDataSave(SavedGameData data)
        {
            data.PlayerProgress.TicketsCount = TicketsCount.Value;
        }
    }
}