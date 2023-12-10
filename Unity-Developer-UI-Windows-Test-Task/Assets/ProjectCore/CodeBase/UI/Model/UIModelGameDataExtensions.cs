using CodeBase.Project.Data;
using CodeBase.UI.Model.Data;

namespace CodeBase.UI.Model
{
    public static class UIModelGameDataExtensions
    {
        public static ModelGameData FromSaved(this SavedGameData gameData)
        {
            return new ModelGameData
            {
                Settings = gameData.Settings.FromSaved(),
                PlayerProgress = gameData.PlayerProgress.FromSaved()
            };
        }

        public static ModelSettingsData FromSaved(this SavedSettingsData settings)
        {
            return new ModelSettingsData
            {
                IsMusicActive = settings.IsMusicActive,
                IsUISoundActive = settings.IsUISoundActive
            };
        }

        public static SavedSettingsData ToSaved(this ModelSettingsData settings)
        {
            return new SavedSettingsData
            {
                IsMusicActive = settings.IsMusicActive,
                IsUISoundActive = settings.IsUISoundActive
            };
        }

        public static ModelPlayerProgressData FromSaved(this SavedPlayerProgressData playerProgress)
        {
            return new ModelPlayerProgressData
            {
                BoughtItemsNames = playerProgress.BoughtItemsNames,
                LastExitOADate = playerProgress.LastExitOADate,
                ConsecutiveEntryCount = playerProgress.ConsecutiveEntryCount,
                TicketsCount = playerProgress.TicketsCount,
                ReachedLevel = playerProgress.ReachedLevel
            };
        }

        public static SavedPlayerProgressData ToSaved(this ModelPlayerProgressData playerProgress)
        {
            return new SavedPlayerProgressData
            {
                BoughtItemsNames = playerProgress.BoughtItemsNames,
                LastExitOADate = playerProgress.LastExitOADate,
                ConsecutiveEntryCount = playerProgress.ConsecutiveEntryCount,
                TicketsCount = playerProgress.TicketsCount,
                ReachedLevel = playerProgress.ReachedLevel
            };
        }
    }
}