using CodeBase.Project.Data;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public interface IGameDataReader : IGameDataWatcher
    {
        public void OnGameDataLoad(GameData data);
    }
}