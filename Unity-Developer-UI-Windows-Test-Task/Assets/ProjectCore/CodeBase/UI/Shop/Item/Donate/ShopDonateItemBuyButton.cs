using CodeBase.Common.Utilities.UI.UIButton;
using CodeBase.UI.Shop.Item.BuyButton;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

namespace CodeBase.UI.Shop.Item.Donate
{
    public class ShopDonateItemBuyButton : ButtonBaseSfx, IShopItemBuyButton
    {
        [SerializeField] private CodelessIAPButton _iapButton;
        private ShopController _controller;
        private ShopItemBuyData _data;

        [Inject]
        public void Construct(ShopController controller)
        {
            _controller = controller;
            gameObject.SetActive(false); // productId is required in iapButton on OnEnable 
        }

        public void Initialize(ShopItemBuyData data)
        {
            _data = data;
            _iapButton.productId = _data.ID;
            gameObject.SetActive(true); // productId is required in iapButton on OnEnable 
        }

        private protected override void OnEnable()
        {
            base.OnEnable();
            _iapButton.onPurchaseComplete.AddListener(BuyItem);
        }

        private protected override void OnDisable()
        {
            base.OnDisable();
            _iapButton.onPurchaseComplete.RemoveListener(BuyItem);
        }

        private protected override void OnClick() => PlayButtonClickSound();

        private void BuyItem(Product _) => _controller.BuyItem(_data);
    }
}