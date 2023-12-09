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
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Sprite _lockIcon;

        private LobbyShopAdapter _adapter;
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyShopItemPreset _preset;
        private LobbyAudioManager _audioManager;
        private Sprite _defaultIcon;

        [Inject]
        public void Construct(LobbyShopAdapter adapter, LobbyAudioManagerProvider audioManagerProvider)
        {
            _adapter = adapter;
            _audioManagerProvider = audioManagerProvider;
        }

        public void Initialize(LobbyShopItemPreset preset, Sprite defaultIcon)
        {
            _preset = preset;
            _defaultIcon = defaultIcon;
            _audioManager = _audioManagerProvider.GetManager();
            _nameText.text = $"{preset.ID}";
            _costText.text = $"{preset.Cost}";

            if (preset.RequiredLevelNumber == 0)
                Unlock();
            else
                Lock();
        }

        private void OnEnable() => _selectableButton.onClick.AddListener(OnClickBuy);

        private void OnDisable() => _selectableButton.onClick.RemoveListener(OnClickBuy);

        private void OnClickBuy()
        {
            _adapter.BuyItem(_preset);
            _audioManager.PlayButtonClick();
        }

        public void ShowBuy()
        {
            _notBoughtRoot.SetActive(false);
            _boughtRoot.SetActive(true);
        }

        public void Unlock()
        {
            _requiredLevelText.gameObject.SetActive(false);
            _itemIcon.sprite = _defaultIcon;
        }

        private void Lock()
        {
            _requiredLevelText.text = $"LV. {_preset.RequiredLevelNumber}";
            _itemIcon.sprite = _lockIcon;
        }
    }
}