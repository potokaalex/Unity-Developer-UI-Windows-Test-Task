using System;

namespace CodeBase.UI.Shop.Item
{
    [Serializable]
    public struct ShopItemPreset
    {
        public ShopItemGroupType GroupType;
        public string IconName;
        public string ID;
        public float Cost;
        public int Count;
        public int RequiredLevelNumber;
    }
}