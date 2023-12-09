using System;
using System.Collections.Generic;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public double LastEntryOADate = DateTime.Now.ToOADate();
        public int ConsecutiveEntryCount;
        public int TicketsCount;
        public int ReachedLevel;

        public List<string> BoughtItemsNames = new()
        {
            "Character 1",
            "Location 1"
        };
    }
}