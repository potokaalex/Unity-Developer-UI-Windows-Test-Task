using System;
using CodeBase.Project.Data;
using CodeBase.Project.Data.Saved;
using CodeBase.Project.Services.SaveLoaderService;

namespace CodeBase.UI.Model
{
    public class UIModel : IGameDataWriter, IGameDataReader
    {
        private ModelGameData _currentData;

        public event Action<int> OnTicketsCountChanged;

        public event Action<int> OnLevelChanged;
        
        public ModelGameData ReadOnlyData => _currentData;

        public SavedGameData GetGameData() => new();

        public void AddTicketsCount(int count)
        {
            _currentData.PlayerProgress.TicketsCount += count;
            OnTicketsCountChanged?.Invoke(_currentData.PlayerProgress.TicketsCount);
        }

        public void RemoveTicketsCount(int count)
        {
            _currentData.PlayerProgress.TicketsCount -= count;
            OnTicketsCountChanged?.Invoke(_currentData.PlayerProgress.TicketsCount);
        }

        public void SetNextLevel()
        {
            _currentData.PlayerProgress.ReachedLevel += 1;
            OnLevelChanged?.Invoke(_currentData.PlayerProgress.ReachedLevel);
        }

        public void SetMusicActive(bool isActive) => _currentData.Settings.IsMusicActive = isActive;

        public void SetUISoundActive(bool isActive) => _currentData.Settings.IsUISoundActive = isActive;

        public void SetConsecutiveEntryCount(int count) => _currentData.PlayerProgress.ConsecutiveEntryCount = count;

        public void OnGameDataLoad(SavedGameData data) => _currentData = data.FromSaved();

        public void OnGameDataSave(SavedGameData data)
        {
            data.Settings = _currentData.Settings.ToSaved();
            data.PlayerProgress = _currentData.PlayerProgress.ToSaved();
            data.PlayerProgress.LastExitOADate = DateTime.Now.ToOADate();
        }
    }
}