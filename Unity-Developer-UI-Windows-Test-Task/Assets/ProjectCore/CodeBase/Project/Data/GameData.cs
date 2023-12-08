using System;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class GameData
    {
        public GameSettingsData Settings = new();
        public double LastEntryOADate;
        public int TicketsCount;
    }
}