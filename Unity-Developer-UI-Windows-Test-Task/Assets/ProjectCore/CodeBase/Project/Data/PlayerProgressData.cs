using System;
using System.Collections.Generic;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public double LastEntryOADate;
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