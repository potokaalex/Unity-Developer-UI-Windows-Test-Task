using UnityEngine;
using Zenject;

namespace CodeBase.Project.Services.UnityEventsObserverService
{
    public class UnityEventsObserverInstaller : MonoInstaller
    {
        [SerializeField] private UnityEventsObserver _unityEventsObserverPrefab;

        public override void InstallBindings() => Container.Bind<UnityEventsObserver>()
            .FromComponentInNewPrefab(_unityEventsObserverPrefab).AsSingle();
    }
}