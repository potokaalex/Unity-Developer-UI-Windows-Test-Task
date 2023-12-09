using CodeBase.Project.Services;
using CodeBase.Project.Services.AssetProviderService;
using CodeBase.Project.Services.AudioManagerService;
using CodeBase.Project.Services.SaveLoaderService;
using UnityEngine;
using Zenject;

namespace CodeBase.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager _audioManagerPrefab;
        [SerializeField] private UnityEventsObserver _unityEventsObserverPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IAudioManager>().To<AudioManager>().FromComponentInNewPrefab(_audioManagerPrefab).AsSingle();
            Container.Bind<GameDataSaveLoader>().AsSingle();
            Container.Bind<UnityEventsObserver>().FromComponentInNewPrefab(_unityEventsObserverPrefab).AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
    }
}