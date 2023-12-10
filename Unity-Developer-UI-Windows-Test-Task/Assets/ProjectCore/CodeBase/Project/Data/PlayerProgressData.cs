using System.Collections.Generic;

namespace CodeBase.Project.Data
{
    public struct PlayerProgressData
    {
        public List<string> BoughtItemsNames;
        public double LastEntryOADate;
        public int ConsecutiveEntryCount;
        public int TicketsCount;
        public int ReachedLevel;
    }
}