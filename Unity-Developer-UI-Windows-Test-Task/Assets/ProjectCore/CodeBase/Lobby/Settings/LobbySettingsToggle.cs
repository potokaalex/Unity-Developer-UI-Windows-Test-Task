using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsToggle : ToggleBase
    {
        [SerializeField] private LobbySettingsToggleType _settingsToggleType;

        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbySettingsAdapter _settingsAdapter;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyAudioManagerProvider audioManagerProvider) =>
            _audioManagerProvider = audioManagerProvider;

        public void Initialize(LobbySettingsAdapter settingsAdapter)
        {
            _settingsAdapter = settingsAdapter;
            _audioManager = _audioManagerProvider.GetManager();
        }

        private protected override void OnValueChange(bool isActive)
        {
            _audioManager.PlayButtonClick();
            _settingsAdapter.Set(_settingsToggleType, isActive);
        }
    }
}