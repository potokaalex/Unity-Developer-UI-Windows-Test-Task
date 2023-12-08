using UnityEngine;

namespace CodeBase.Lobby
{
    public class LobbyAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _buttonClickClip;

        public void PlayButtonClick() => _audioSource.PlayOneShot(_buttonClickClip);
    }
}