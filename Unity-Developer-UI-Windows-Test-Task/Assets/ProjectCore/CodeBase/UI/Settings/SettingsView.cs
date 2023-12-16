using CodeBase.Common.Utilities.UI.Window;
using CodeBase.UI.Settings.Toggle;
using UnityEngine;

namespace CodeBase.UI.Settings
{
    public class SettingsView : MonoBehaviour, IWindow
    {
        [SerializeField] private SettingsToggle _musicToggle;
        [SerializeField] private SettingsToggle _uiSoundToggle;

        public SettingsToggle MusicToggle => _musicToggle;

        public SettingsToggle UISoundToggle => _uiSoundToggle;

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}