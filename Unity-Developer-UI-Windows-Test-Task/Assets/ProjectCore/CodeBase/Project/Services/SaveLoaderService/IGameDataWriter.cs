using CodeBase.Project.Data;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public interface IGameDataWriter : IGameDataWatcher
    {
        public void OnGameDataSave(GameData data);
    }
}