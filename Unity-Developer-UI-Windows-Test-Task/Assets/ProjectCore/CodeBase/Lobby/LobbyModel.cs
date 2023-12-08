using CodeBase.Project.Data;
using CodeBase.Project.Services.SaveLoaderService;

namespace CodeBase.Lobby
{
    public class LobbyModel : IGameDataWriter, IGameDataReader
    {
        private GameData _gameData;

        public GameData GetGameData() => _gameData;

        public void SetMusicActive(bool isActive) => _gameData.Settings.IsMusicActive = isActive;

        public void SetUISoundActive(bool isActive) => _gameData.Settings.IsUISoundActive = isActive;

        public void OnGameDataLoad(GameData data) => _gameData = data;

        public void OnGameDataSave(GameData data) => data.Settings = _gameData.Settings;
    }
}