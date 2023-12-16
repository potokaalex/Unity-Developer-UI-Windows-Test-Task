using CodeBase.Common.Services.AudioManagerService;
using Zenject;

namespace CodeBase.Common.Utilities.UI.UIButton
{
    public abstract class ButtonBaseSfx : ButtonBase
    {
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager) => _audioManager = audioManager;

        private protected void PlayButtonClickSound() => _audioManager.UIAudioSource.PlayButtonClick();
    }
}