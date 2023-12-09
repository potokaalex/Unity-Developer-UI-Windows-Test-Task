﻿using CodeBase.Lobby.Data;
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
        public void Construct(LobbySettingsAdapter settingsAdapter, LobbyAudioManagerProvider audioManagerProvider)
        {
            _settingsAdapter = settingsAdapter;
            _audioManagerProvider = audioManagerProvider;
        }

        public void Initialize(bool isActive)
        {
            SelectableToggle.SetIsOnWithoutNotify(isActive);
            _audioManager = _audioManagerProvider.GetManager();
        }

        private protected override void OnValueChange(bool isActive)
        {
            _audioManager.PlayButtonClick();
            _settingsAdapter.Set(_settingsToggleType, isActive);
        }
    }
}