using System;
using CodeBase.Common.Services.AudioManagerService;
using Zenject;

namespace CodeBase.Common.Utilities.UI.UIToggle
{
    public abstract class ToggleBaseSfx : ToggleBase
    {
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager) => _audioManager = audioManager;

        private protected void PlayButtonClickSound(Action afterSoundAction = null) =>
            _audioManager.UIAudioSource.PlayButtonClick(afterSoundAction);
    }
}