using CodeBase.UI.Shop.Item.BuyButton;
using CodeBase.UI.Shop.Item.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Shop.Item
{
    public class ShopItemView : MonoBehaviour, IShopItemView
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _requiredLevelText;

        [SerializeField] private Transform _notBoughtRoot;
        [SerializeField] private Transform _boughtRoot;

        [SerializeField] private Image _itemIcon;
        [SerializeField] private ShopItemBuyButton _buyButton;

        private ShopItemData _data;

        public void Initialize(ShopItemData data)
        {
            _data = data;
            _nameText.text = $"{_data.Name}";
            _costText.text = $"{_data.TicketsCost}";
            _requiredLevelText.text = $"LV. {_data.RequiredLevelNumber}";
        }

        public IShopItemBuyButton BuyButton => _buyButton;

        public string ID => _data.ID;

        public int RequiredLevelNumber => _data.RequiredLevelNumber;

        public void ShowBought()
        {
            _notBoughtRoot.gameObject.SetActive(false);
            _boughtRoot.gameObject.SetActive(true);
        }

        public void ShowLock(bool isLocked)
        {
            if (isLocked)
            {
                _requiredLevelText.gameObject.SetActive(true);
                _itemIcon.sprite = _data.LockIcon;
            }
            else
            {
                _requiredLevelText.gameObject.SetActive(false);
                _itemIcon.sprite = _data.UnLockIcon;
            }
        }
    }
}