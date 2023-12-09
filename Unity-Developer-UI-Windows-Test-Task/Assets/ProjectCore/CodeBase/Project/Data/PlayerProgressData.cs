using System;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public double LastEntryOADate = DateTime.Now.ToOADate();
        public int ConsecutiveEntryCount;
        public int TicketsCount;
    }
}