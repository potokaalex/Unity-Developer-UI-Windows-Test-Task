using CodeBase.UI.Shop.Item.BuyButton;

namespace CodeBase.UI.Shop.Item
{
    public interface IShopItemView
    {
        public string ID { get; }

        public int RequiredLevelNumber { get; }

        public IShopItemBuyButton BuyButton { get; }

        public void ShowBought();

        public void ShowLock(bool isLocked);
    }
}