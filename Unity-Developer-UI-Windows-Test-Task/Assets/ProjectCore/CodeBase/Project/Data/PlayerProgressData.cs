using System;
using System.Collections.Generic;
using CodeBase.Lobby.Data;

namespace CodeBase.Project.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public List<ShopItemSavedData> BoughtItems = new();
        public double LastEntryOADate = DateTime.Now.ToOADate();
        public int ConsecutiveEntryCount;
        public int TicketsCount;
    }
}