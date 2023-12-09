using System;

namespace CodeBase.Lobby.Data
{
    [Serializable]
    public struct LobbyShopItemPreset
    {
        public ShopGroupType GroupType;
        public string IconName;
        public string ID;
        public float Cost;
        public int Count;
        public int RequiredLevelNumber;
    }
}