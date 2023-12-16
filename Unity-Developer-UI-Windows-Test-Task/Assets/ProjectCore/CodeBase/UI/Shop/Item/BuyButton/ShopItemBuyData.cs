using CodeBase.UI.Shop.Item.Group;

namespace CodeBase.UI.Shop.Item.BuyButton
{
    public struct ShopItemBuyData
    {
        public ShopItemGroupType GroupType;
        public string ID;
        public int TicketsCost;
        public int ItemsCount;
        public int RequiredLevelNumber;
        public bool IsConsumable;
    }
}