using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

namespace CodeBase.Lobby.Shop.Item
{
    public class LobbyShopItemDonate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _itemsCountText;
        [SerializeField] private CodelessIAPButton _iapButton;

        private LobbyShopAdapter _adapter;
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyShopDonateItemPreset _preset;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyShopAdapter adapter,LobbyAudioManagerProvider audioManagerProvider)
        {
            _adapter = adapter;
            _audioManagerProvider = audioManagerProvider;
        }

        public void Initialize(LobbyShopDonateItemPreset preset)
        {
            _preset = preset;
            _audioManager = _audioManagerProvider.GetManager();
            _nameText.text = $"[{preset.ID}]";
            _costText.text = $"${preset.Cost}";
            _itemsCountText.text = $"X{preset.Count}";
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

        private void OnBuyItem(Product arg) => _adapter.BuyItem(_preset);
    }
}