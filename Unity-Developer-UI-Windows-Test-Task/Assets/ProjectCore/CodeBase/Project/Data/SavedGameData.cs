using System;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class SavedGameData
    {
        public SavedSettingsData Settings = new();
        public SavedPlayerProgressData PlayerProgress = new();
    }
}