using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Common.Services.AudioManagerService
{
    public class UIAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _buttonSound;
        [SerializeField] private float _buttonSoundSecDuration;

        public void PlayButtonClick(Action afterSoundAction = null)
        {
            _source.PlayOneShot(_buttonSound);

            if (afterSoundAction != null)
                StartCoroutine(ActionAfterTime(_buttonSoundSecDuration, afterSoundAction));
        }

        private IEnumerator ActionAfterTime(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
        }
    }
}