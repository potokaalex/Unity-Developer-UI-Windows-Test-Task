using System;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Settings.Toggle
{
    public class SettingsToggle : ToggleBase
    {
        [SerializeField] private SettingsToggleType _toggleType;
        [SerializeField] private GameObject _onDisableRoot;

        private SettingsController _controller;

        [Inject]
        public void Construct(SettingsController controller) => _controller = controller;

        public void Initialize(bool isActive)
        {
            SelectableToggle.SetIsOnWithoutNotify(isActive);
            ShowActive(isActive);
        }

        private protected override void OnToggleValueChanged(bool isActive)
        {
            switch (_toggleType)
            {
                case SettingsToggleType.Music:
                    _controller.SetMusicActive(isActive);
                    break;
                case SettingsToggleType.UISound:
                    _controller.SetUISoundActive(isActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ShowActive(bool isActive) => _onDisableRoot.SetActive(!isActive);
    }
}