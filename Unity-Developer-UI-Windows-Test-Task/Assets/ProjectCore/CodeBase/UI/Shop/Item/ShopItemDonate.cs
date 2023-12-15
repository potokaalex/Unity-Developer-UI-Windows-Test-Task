using CodeBase.Project.Services;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Shop.Item
{
    public class ShopItemDonate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _itemsCountText;
        [SerializeField] private CodelessIAPButton _iapButton;
        [SerializeField] private Image _itemIcon;

        private ShopAdapter _adapter;
        private ShopItemPreset _preset;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(ShopAdapter adapter, AudioManager audioManager,
            ShopItemPreset preset)
        {
            _adapter = adapter;
            _audioManager = audioManager;
            _preset = preset;
            _iapButton.productId = preset.ID;
        }

        public void Initialize(Sprite sprite)
        {
            _nameText.text = $"[{_preset.ID}]";
            _costText.text = $"${_preset.Cost}";
            _itemsCountText.text = $"X{_preset.Count}";
            _itemIcon.sprite = sprite;
        }

        private void OnEnable()
        {
            _iapButton.onPurchaseComplete.AddListener(OnBuyItem);
            _iapButton.button.onClick.AddListener(OnClickBuyItem);
        }

        private void OnDisable()
        {
            _iapButton.button.onClick.RemoveListener(OnClickBuyItem);
            _iapButton.onPurchaseComplete.RemoveListener(OnBuyItem);
        }

        private void OnClickBuyItem()
        {
            //_audioManager.PlayButtonClickUISound();
        }

        private void OnBuyItem(Product arg) => _adapter.BuyItemDonate(_preset);
    }
}