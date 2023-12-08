using CodeBase.Lobby.Data;
using CodeBase.Utilities.UI;
using UnityEngine;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsToggle : ToggleBase
    {
        [SerializeField] private LobbySettingsToggleType _settingsToggleType;
        private LobbySettingsAdapter _settingsAdapter;
        private LobbyAudioManager _audioManager;

        public void Initialize(LobbySettingsAdapter settingsAdapter,LobbyAudioManager audioManager)
        {
            _settingsAdapter = settingsAdapter;
            _audioManager = audioManager;
        }

        private protected override void OnValueChange(bool isActive)
        {
            _settingsAdapter.Set(_settingsToggleType, isActive);
            _audioManager.PlayButtonClick();
        }
    }
}