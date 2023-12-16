using CodeBase.UI.Shop.Item.BuyButton;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Shop.Item.Donate
{
    public class ShopDonateItemView : MonoBehaviour, IShopItemView
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _itemsCountText;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private ShopDonateItemBuyButton _buyButton;
        private ShopDonateItemData _data;

        public void Initialize(ShopDonateItemData data)
        {
            _data = data;
            _nameText.text = $"[{_data.Name}]";
            _costText.text = $"${_data.Cost}";
            _itemsCountText.text = $"X{_data.ItemsCount}";
            _itemIcon.sprite = _data.DefaultIcon;
        }

        public IShopItemBuyButton BuyButton => _buyButton;

        public string ID => _data.ID;

        public int RequiredLevelNumber => 0;

        public void ShowBought()
        {
        }

        public void ShowLock(bool isLocked)
        {
        }
    }
}