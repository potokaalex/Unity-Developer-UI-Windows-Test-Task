using CodeBase.Common.Data.Saved;

namespace CodeBase.Common.Services.SaveLoaderService
{
    public interface IGameDataReader : IGameDataWatcher
    {
        public void OnGameDataLoad(SavedGameData data);
    }
}