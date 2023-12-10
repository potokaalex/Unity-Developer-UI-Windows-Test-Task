using CodeBase.Project.Services;
using CodeBase.Project.Services.AssetProviderService;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.Project.Services.WindowsManagerService;
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
            Container.Bind<GameDataSaveLoader>().AsSingle();
            Container.Bind<AudioManager>().FromComponentInNewPrefab(_audioManagerPrefab).AsSingle();
            Container.Bind<UnityEventsObserver>().FromComponentInNewPrefab(_unityEventsObserverPrefab).AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<WindowsManager>().AsSingle();
        }
    }
}