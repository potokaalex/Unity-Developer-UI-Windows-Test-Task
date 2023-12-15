using CodeBase.Lobby.Data;
using CodeBase.Lobby.UI;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Settings;
using CodeBase.UI.Shop;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LobbyConfig _lobbyConfig;

        public override void InstallBindings()
        {
            Container.Bind<LobbyConfigProvider>().AsSingle().WithArguments(_lobbyConfig);

            Container.BindInterfacesAndSelfTo<LobbyUIFactory>().AsSingle();
            Container.Bind<DailyBonusUIFactory>().AsSingle();

            Container.Bind(typeof(LobbyModel), typeof(ISettingsModel), typeof(IDailyBonusModel), typeof(ILevelsModel))
                .To<LobbyModel>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<LobbyController>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsController>().AsSingle();
            Container.Bind<DailyBonusController>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsController>().AsSingle();

            Container.Bind<WindowsManager>().AsSingle();
        }

        private void BindFactories()
        {
            //Container.Bind<LobbyMainUIFactory>().AsSingle();
            //Container.Bind<SettingsUIFactory>().AsSingle();
            //Container.BindInterfacesAndSelfTo<DailyBonusUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShopUIFactory>().AsSingle();
            //Container.BindInterfacesAndSelfTo<LevelsUIFactory>().AsSingle();
        }

        private void BindAdapters()
        {
            //Container.Bind(typeof(LobbyMainAdapter), typeof(IDisposable)).To<LobbyMainAdapter>().AsSingle();
            //Container.Bind<SettingsAdapter>().AsSingle();
            //Container.Bind<DailyBonusAdapter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShopAdapter>().AsSingle();
            //Container.Bind<LevelsAdapter>().AsSingle();
        }
    }
}