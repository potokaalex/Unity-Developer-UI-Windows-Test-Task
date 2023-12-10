using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Settings
{
    public class SettingsToggle : ToggleBase
    {
        [SerializeField] private LobbySettingsToggleType _settingsToggleType;
        [SerializeField] private GameObject _onDisableRoot;

        private AudioManager _audioManager;
        private SettingsAdapter _settingsAdapter;

        [Inject]
        public void Construct(AudioManager audioManager, SettingsAdapter settingsAdapter)
        {
            _audioManager = audioManager;
            _settingsAdapter = settingsAdapter;
        }

        public void Initialize(bool isActive)
        {
            SelectableToggle.SetIsOnWithoutNotify(isActive);
            SetActive(isActive);
        }

        private void SetActive(bool isActive) => _onDisableRoot.SetActive(!isActive);

        private protected override void OnValueChange(bool isActive)
        {
            _settingsAdapter.SetActive(_settingsToggleType, isActive);
            _audioManager.PlayButtonClickUISound();
            SetActive(isActive);
        }
    }
}