using CodeBase.UI;
using Zenject;

namespace CodeBase.Project.Services.WindowsManagerService
{
    public class CloseCurrentWindowButton : ButtonBaseSfx
    {
        private WindowsManager _windowsManager;

        [Inject]
        public void Construct(WindowsManager windowsManager) => _windowsManager = windowsManager;

        private protected override void OnClick()
        {
            _windowsManager.CloseCurrentWindow();
            PlayButtonClickSound();
        }
    }
}