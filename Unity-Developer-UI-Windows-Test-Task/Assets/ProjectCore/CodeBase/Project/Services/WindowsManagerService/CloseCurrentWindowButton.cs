using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Project.Services.WindowsManagerService
{
    public class CloseCurrentWindowButton : ButtonBase
    {
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
            _windowsManager.CloseCurrentWindow();
            _audioManager.PlayButtonClickUISound();
        }
    }
}