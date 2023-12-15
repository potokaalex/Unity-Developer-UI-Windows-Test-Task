using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.UI
{
    public abstract class ButtonBaseSfx : ButtonBase
    {
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager) => _audioManager = audioManager;

        private protected void PlayButtonClickSound()
        {
            //_audioManager.PlayButtonClickUISound();
        }
    }
}