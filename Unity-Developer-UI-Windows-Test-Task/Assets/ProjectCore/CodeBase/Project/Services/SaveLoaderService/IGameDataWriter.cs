using CodeBase.Project.Data.Saved;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public interface IGameDataWriter : IGameDataWatcher
    {
        public void OnGameDataSave(SavedGameData data);
    }
}