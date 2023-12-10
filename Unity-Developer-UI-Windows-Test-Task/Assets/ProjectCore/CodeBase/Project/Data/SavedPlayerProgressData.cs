using System;
using System.Collections.Generic;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class SavedPlayerProgressData
    {
        public double LastExitOADate;
        public int ConsecutiveEntryCount;
        public int TicketsCount;
        public int ReachedLevel = 5;

        public List<string> BoughtItemsNames = new()
        {
            "Character 1",
            "Location 1"
        };
    }
}