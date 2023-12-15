using System;

namespace CodeBase.Project.Data.Saved
{
    [Serializable]
    public class SavedGameData
    {
        public SavedSettingsData Settings = new();
        public SavedPlayerProgressData PlayerProgress = new();
    }
}