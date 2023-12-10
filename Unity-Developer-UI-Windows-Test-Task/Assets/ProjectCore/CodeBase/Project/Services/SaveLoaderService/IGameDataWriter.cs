using CodeBase.Project.Data;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public interface IGameDataWriter : IGameDataWatcher
    {
        public void OnGameDataSave(SavedGameData data);
    }
}