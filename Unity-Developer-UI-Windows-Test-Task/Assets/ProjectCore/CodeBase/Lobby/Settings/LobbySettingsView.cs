using CodeBase.Lobby.WindowsManager;
using CodeBase.Project.Data;
using CodeBase.Utilities.UI;
using UnityEngine;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsView : WindowBase
    {
        [SerializeField] private LobbySettingsToggle _musicToggle;
        [SerializeField] private LobbySettingsToggle _uiSoundToggle;
        [SerializeField] private LobbyCloseCurrentWindowButton _closeWindowButton;

        public void Initialize(LobbySettingsAdapter settingsAdapter, GameSettingsData settingsData)
        {
            _closeWindowButton.Initialize(settingsAdapter);

            _musicToggle.Initialize(settingsData.IsMusicActive);
            _uiSoundToggle.Initialize(settingsData.IsUISoundActive);

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