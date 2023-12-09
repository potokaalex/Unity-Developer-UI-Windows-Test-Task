using System;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class GameData
    {
        public GameSettingsData Settings = new();
        public PlayerProgressData PlayerProgress = new();
    }
}