using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.UI.Shop.Item.BuyButton
{
    public class ShopItemBuyButton : ButtonBase, IShopItemBuyButton
    {
        private ShopController _controller;
        private ShopItemBuyData _data;

        [Inject]
        public void Construct(ShopController controller) => _controller = controller;

        public void Initialize(ShopItemBuyData data) => _data = data;

        private protected override void OnClick() => _controller.BuyItem(_data);
    }
}