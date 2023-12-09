using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Lobby.Shop.Item
{
    public class LobbyShopItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _requiredLevelText;
        [SerializeField] private GameObject _notBoughtRoot;
        [SerializeField] private GameObject _boughtRoot;
        [SerializeField] private Button _selectableButton;

        private LobbyShopAdapter _adapter;
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyShopItemPreset _preset;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyShopAdapter adapter, LobbyAudioManagerProvider audioManagerProvider)
        {
            _adapter = adapter;
            _audioManagerProvider = audioManagerProvider;
        }

        public void Initialize(LobbyShopItemPreset preset)
        {
            _preset = preset;
            _audioManager = _audioManagerProvider.GetManager();
            _nameText.text = $"{preset.ID}";
            _costText.text = $"{preset.Cost}";

            if (preset.RequiredLevelNumber != 0)
                _requiredLevelText.text = $"LV. {preset.RequiredLevelNumber}";
            else 
                _requiredLevelText.gameObject.SetActive(false);
        }

        private void OnEnable() => _selectableButton.onClick.AddListener(OnClickBuy);

        private void OnDisable() => _selectableButton.onClick.RemoveListener(OnClickBuy);

        private void OnClickBuy()
        {
            _adapter.BuyItem(_preset);
            _audioManager.PlayButtonClick();
        }

        public void ShowBuy(bool isBought)
        {
            if (isBought)
            {
                _notBoughtRoot.SetActive(false);
                _boughtRoot.SetActive(true);
            }
            else
            {
                _notBoughtRoot.SetActive(true);
                _boughtRoot.SetActive(false);
            }
        }
    }
}