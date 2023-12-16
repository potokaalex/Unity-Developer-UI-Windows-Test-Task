using System;
using System.Collections.Generic;

namespace CodeBase.Common.Data.Saved
{
    [Serializable]
    public class SavedPlayerProgressData
    {
        public double LastExitOADate;
        public int ConsecutiveEntryCount;
        public int TicketsCount;
        public int CompletedLevelNumber = 5;

        public List<string> BoughtItemsIDs = new()
        {
            "Character 1",
            "Location 1"
        };
    }
}