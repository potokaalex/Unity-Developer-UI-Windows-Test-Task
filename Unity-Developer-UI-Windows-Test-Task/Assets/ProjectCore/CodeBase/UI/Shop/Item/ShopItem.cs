using CodeBase.Project.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Shop.Item
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _requiredLevelText;
        [SerializeField] private GameObject _notBoughtRoot;
        [SerializeField] private GameObject _boughtRoot;
        [SerializeField] private Button _selectableButton;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Sprite _lockIcon;

        private ShopAdapter _adapter;
        private ShopItemPreset _preset;
        private Sprite _defaultIcon;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(ShopAdapter adapter, AudioManager audioManager)
        {
            _adapter = adapter;
            _audioManager = audioManager;
        }

        public void Initialize(ShopItemPreset preset, Sprite defaultIcon)
        {
            _preset = preset;
            _defaultIcon = defaultIcon;
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
            _audioManager.PlayButtonClickUISound();
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