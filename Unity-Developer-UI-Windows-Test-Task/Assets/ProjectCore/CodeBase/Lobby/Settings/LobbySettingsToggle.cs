﻿using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsToggle : ToggleBase
    {
        [SerializeField] private LobbySettingsToggleType _settingsToggleType;
        [SerializeField] private GameObject _onDisableRoot;

        private AudioManager _audioManager;
        private LobbySettingsAdapter _settingsAdapter;

        [Inject]
        public void Construct(LobbySettingsAdapter settingsAdapter, AudioManager audioManager)
        {
            _settingsAdapter = settingsAdapter;
            _audioManager = audioManager;
        }

        public void Initialize(bool isActive)
        {
            SelectableToggle.SetIsOnWithoutNotify(isActive);
            SetActive(isActive);
        }

        private void SetActive(bool isActive) => _onDisableRoot.SetActive(!isActive);

        private protected override void OnValueChange(bool isActive)
        {
            _audioManager.PlayButtonClickUISound();
            _settingsAdapter.Set(_settingsToggleType, isActive);
            SetActive(isActive);
        }
    }
}