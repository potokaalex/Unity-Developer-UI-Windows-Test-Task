using System.Collections.Generic;
using CodeBase.Project.Data.Saved;
using UnityEngine;

namespace CodeBase.Project.Services.SaveLoaderService
{
    public class GameDataSaveLoader
    {
        private const string Key = "GameDataKey";

        private readonly List<IGameDataWriter> _writers = new();
        private readonly List<IGameDataReader> _readers = new();
        private SavedGameData _currentData;

        public void RegisterWatcher(IGameDataWatcher watcher)
        {
            if (watcher is IGameDataWriter writer)
                _writers.Add(writer);

            if (watcher is IGameDataReader reader)
                _readers.Add(reader);
        }

        public void Save()
        {
            foreach (var writer in _writers)
                writer.OnGameDataSave(_currentData);

            var stringData = JsonUtility.ToJson(_currentData);
            PlayerPrefs.SetString(Key, stringData);
        }

        public void Load()
        {
            var loadedString = PlayerPrefs.GetString(Key, string.Empty);
            var data = JsonUtility.FromJson<SavedGameData>(loadedString) ?? new SavedGameData();

            foreach (var reader in _readers)
                reader.OnGameDataLoad(data);

            _currentData = data;
        }
    }
}