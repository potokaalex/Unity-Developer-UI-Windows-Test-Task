using CodeBase.Common.Services.AssetProviderService;
using CodeBase.Common.Services.AudioManagerService;
using CodeBase.Common.Services.SaveLoaderService;
using UnityEngine;
using Zenject;

namespace CodeBase.Common
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager _audioManagerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<GameDataSaveLoader>().AsSingle();
            Container.Bind<AudioManager>().FromComponentInNewPrefab(_audioManagerPrefab).AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
    }
}