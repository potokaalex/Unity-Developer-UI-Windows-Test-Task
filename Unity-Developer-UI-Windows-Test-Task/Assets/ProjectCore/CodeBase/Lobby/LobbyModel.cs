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
            _gameData.TicketsCount += count;
            OnTicketsCountChanged?.Invoke(_gameData.TicketsCount);
        }

        public void OnGameDataLoad(GameData data) => _gameData = data;

        public void OnGameDataSave(GameData data)
        {
            data.Settings = _gameData.Settings;
            data.LastEntryOADate = DateTime.Now.ToOADate();
        }
    }
}