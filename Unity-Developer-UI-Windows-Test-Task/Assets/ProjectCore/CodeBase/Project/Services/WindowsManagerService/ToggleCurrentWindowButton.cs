using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Project.Services.WindowsManagerService
{
    public class ToggleCurrentWindowButton : ButtonBase
    {
        [SerializeField] private WindowType _windowType;

        private AudioManager _audioManager;
        private WindowsManager _windowsManager;

        [Inject]
        public void Construct(AudioManager audioManager, WindowsManager windowsManager)
        {
            _audioManager = audioManager;
            _windowsManager = windowsManager;
        }

        private protected override void OnClick()
        {
            _windowsManager.ToggleCurrentWindow(_windowType);
            _audioManager.PlayButtonClickUISound();
        }
    }
}