using System;
using CodeBase.Project.Data;
using CodeBase.Project.Services.SaveLoaderService;

namespace CodeBase.Lobby
{
    public class LobbyModel : IGameDataWriter, IGameDataReader
    {
        private GameData _gameData;

        public event Action<int> OnTicketsCountChanged;

        public GameData GetGameData() => _gameData;

        public void AddTicketsCount(int count)
        {
            _gameData.PlayerProgress.TicketsCount += count;
            OnTicketsCountChanged?.Invoke(_gameData.PlayerProgress.TicketsCount);
        }

        public void OnGameDataLoad(GameData data) => _gameData = data;

        public void OnGameDataSave(GameData data)
        {
            data.Settings = _gameData.Settings;
            data.PlayerProgress.LastEntryOADate = DateTime.Now.ToOADate();
        }
    }
}