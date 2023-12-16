using System;
using CodeBase.Common.Utilities.UI.UIToggle;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Settings.Toggle
{
    public class SettingsToggle : ToggleBaseSfx
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
                    SetMusicSound(isActive);
                    break;
                case SettingsToggleType.UISound:
                    SetUISound(isActive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ShowActive(bool isActive) => _onDisableRoot.SetActive(!isActive);

        private void SetMusicSound(bool isActive)
        {
            _controller.SetMusicActive(isActive);
            PlayButtonClickSound();
        }

        private void SetUISound(bool isActive)
        {
            if (isActive)
            {
                _controller.SetUISoundActive(true);
                PlayButtonClickSound();
            }
            else
                PlayButtonClickSound(() => _controller.SetUISoundActive(false));
        }
    }
}