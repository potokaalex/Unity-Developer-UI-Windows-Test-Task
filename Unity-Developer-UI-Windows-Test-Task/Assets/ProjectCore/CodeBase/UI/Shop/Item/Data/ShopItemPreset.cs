using CodeBase.UI.Shop.Item.Group;
using UnityEngine;

namespace CodeBase.UI.Shop.Item.Data
{
    [CreateAssetMenu(menuName = "Configurations/ShopItem", fileName = "ShopItemPreset", order = 0)]
    public class ShopItemPreset : ScriptableObject
    {
        public ShopItemGroupType GroupType;
        public ShopItemType Type;
        public string ID;
        public string Name;
        public string IconName;
        public string LockIconName;
        public float DonateCost;
        public int TicketsCost;
        public int ItemsCount;
        public int RequiredLevelNumber;
        public bool IsConsumable;
    }
}