using UnityEngine;
using UnityEngine.Audio;

namespace CodeBase.Project.Services
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mainMixer;
        [SerializeField] private AudioSource _uiAudioSource;
        [SerializeField] private AudioClip _onButtonClickClip;

        private const string MusicVolumeName = "MusicVolume";
        private const string UIVolumeName = "UIVolume";
        private const int ActiveVolume = 0;
        private const int DisActiveVolume = -80;

        public void SetMusicActive(bool isActive) =>
            _mainMixer.audioMixer.SetFloat(MusicVolumeName, isActive ? ActiveVolume : DisActiveVolume);

        public void SetUISoundActive(bool isActive) =>
            _mainMixer.audioMixer.SetFloat(UIVolumeName, isActive ? ActiveVolume : DisActiveVolume);

        public void PlayButtonClickUISound() => _uiAudioSource.PlayOneShot(_onButtonClickClip);
    }
}