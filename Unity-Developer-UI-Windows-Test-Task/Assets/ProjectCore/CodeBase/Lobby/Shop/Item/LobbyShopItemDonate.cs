using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Lobby.Shop.Item
{
    public class LobbyShopItemDonate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _itemsCountText;
        [SerializeField] private CodelessIAPButton _iapButton;
        [SerializeField] private Image _itemIcon;

        private LobbyShopAdapter _adapter;
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyShopItemPreset _preset;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyShopAdapter adapter, LobbyAudioManagerProvider audioManagerProvider,
            LobbyShopItemPreset preset)
        {
            _adapter = adapter;
            _audioManagerProvider = audioManagerProvider;
            _preset = preset;
            _iapButton.productId = preset.ID;
        }

        public void Initialize(Sprite sprite)
        {
            _audioManager = _audioManagerProvider.GetManager();
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

        private void OnClickBuyItem() => _audioManager.PlayButtonClick();

        private void OnBuyItem(Product arg) => _adapter.BuyItemDonate(_preset);
    }
}