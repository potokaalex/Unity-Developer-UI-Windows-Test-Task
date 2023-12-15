using CodeBase.Project.Data.Saved;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public interface IGameDataReader : IGameDataWatcher
    {
        public void OnGameDataLoad(SavedGameData data);
    }
}