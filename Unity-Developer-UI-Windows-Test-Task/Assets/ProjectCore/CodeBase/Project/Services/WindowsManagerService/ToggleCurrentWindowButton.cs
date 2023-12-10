using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Project.Services.WindowsManagerService
{
    public class ToggleCurrentWindowButton : ButtonBaseSfx
    {
        [SerializeField] private WindowType _windowType;

        private WindowsManager _windowsManager;

        [Inject]
        public void Construct(WindowsManager windowsManager) => _windowsManager = windowsManager;

        private protected override void OnClick()
        {
            _windowsManager.ToggleCurrentWindow(_windowType);
            PlayButtonClickSound();
        }
    }
}