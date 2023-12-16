using CodeBase.Common.Data.Saved;

namespace CodeBase.Common.Services.SaveLoaderService
{
    public interface IGameDataWriter : IGameDataWatcher
    {
        public void OnGameDataSave(SavedGameData data);
    }
}