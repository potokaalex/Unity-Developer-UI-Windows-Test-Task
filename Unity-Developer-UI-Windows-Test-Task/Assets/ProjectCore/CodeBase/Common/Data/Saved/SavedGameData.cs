using System;

namespace CodeBase.Common.Data.Saved
{
    [Serializable]
    public class SavedGameData
    {
        public SavedSettingsData Settings = new();
        public SavedPlayerProgressData PlayerProgress = new();
    }
}