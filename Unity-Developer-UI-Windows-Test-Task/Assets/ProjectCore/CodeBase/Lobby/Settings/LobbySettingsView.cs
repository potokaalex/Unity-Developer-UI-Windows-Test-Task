using System.Collections.Generic;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Utilities.UI;
using UnityEngine;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsView : WindowBase
    {
        [SerializeField] private List<LobbySettingsToggle> _settingsToggles;
        [SerializeField] private LobbyCloseCurrentWindowButton _closeWindowButton;

        public void Initialize(LobbySettingsAdapter settingsAdapter)
        {
            _closeWindowButton.Initialize(settingsAdapter);

            foreach (var toggle in _settingsToggles)
                toggle.Initialize(settingsAdapter);

            Close();
        }

        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }
    }
}