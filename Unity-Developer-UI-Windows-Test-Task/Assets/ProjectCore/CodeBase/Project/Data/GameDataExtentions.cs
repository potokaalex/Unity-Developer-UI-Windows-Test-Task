using CodeBase.Project.Data.Saved;

namespace CodeBase.Project.Data
{
    public static class PlayerProgressExtensions
    {
        public static GameData FromSaved(this SavedGameData gameData)
        {
            return new GameData
            {
                Settings = gameData.Settings.FromSaved(),
                PlayerProgress = gameData.PlayerProgress.FromSaved()
            };
        }

        public static SettingsData FromSaved(this SavedSettingsData settings)
        {
            return new SettingsData
            {
                IsMusicActive = settings.IsMusicActive,
                IsUISoundActive = settings.IsUISoundActive
            };
        }

        public static SavedSettingsData ToSaved(this SettingsData settings)
        {
            return new SavedSettingsData
            {
                IsMusicActive = settings.IsMusicActive,
                IsUISoundActive = settings.IsUISoundActive
            };
        }

        public static PlayerProgressData FromSaved(this SavedPlayerProgressData playerProgress)
        {
            return new PlayerProgressData
            {
                BoughtItemsNames = playerProgress.BoughtItemsNames,
                LastEntryOADate = playerProgress.LastEntryOADate,
                ConsecutiveEntryCount = playerProgress.ConsecutiveEntryCount,
                TicketsCount = playerProgress.TicketsCount,
                ReachedLevel = playerProgress.ReachedLevel
            };
        }

        public static SavedPlayerProgressData ToSaved(this PlayerProgressData playerProgress)
        {
            return new SavedPlayerProgressData
            {
                BoughtItemsNames = playerProgress.BoughtItemsNames,
                LastEntryOADate = playerProgress.LastEntryOADate,
                ConsecutiveEntryCount = playerProgress.ConsecutiveEntryCount,
                TicketsCount = playerProgress.TicketsCount,
                ReachedLevel = playerProgress.ReachedLevel
            };
        }
    }
}