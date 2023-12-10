using CodeBase.Utilities.UI.Window;
using UnityEngine;

namespace CodeBase.Lobby.Settings
{
    public class SettingsView : WindowBase
    {
        [SerializeField] private SettingsToggle _musicToggle;
        [SerializeField] private SettingsToggle _uiSoundToggle;

        public void Initialize(bool isMusicActive, bool isUISoundActive)
        {
            _musicToggle.Initialize(isMusicActive);
            _uiSoundToggle.Initialize(isUISoundActive);
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