using System;
using UnityEngine;

namespace CodeBase.Project.Services.UnityEventsObserverService
{
    public class UnityEventsObserver : MonoBehaviour
    {
        public event Action OnApplicationExitEvent;

        private void OnApplicationQuit() => OnApplicationExitEvent?.Invoke();
    }
}