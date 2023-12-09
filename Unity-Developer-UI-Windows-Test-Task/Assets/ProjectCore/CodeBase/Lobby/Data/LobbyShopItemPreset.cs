using System;

namespace CodeBase.Lobby.Data
{
    [Serializable]
    public struct LobbyShopItemPreset
    {
        public string ID;
        public int Cost;
        public int RequiredLevelNumber;
    }
}