using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Infrastructure
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LobbyConfig _lobbyConfig;

        public override void InstallBindings()
        {
            BindFactories();
            BindAdapters();

            Container.Bind<LobbyStaticDataProvider>().AsSingle().WithArguments(_lobbyConfig);
            Container.Bind<LobbyModel>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<LobbyFactory>().AsSingle();
            Container.Bind<LobbyMainUIFactory>().AsSingle();
            Container.Bind<SettingsUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<DailyBonusUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyShopUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsUIFactory>().AsSingle();
        }

        private void BindAdapters()
        {
            Container.BindInterfacesAndSelfTo<LobbyMainAdapter>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyShopAdapter>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsAdapter>().AsSingle();
            Container.Bind<DailyBonusAdapter>().AsSingle();
            Container.Bind<LobbyLevelsAdapter>().AsSingle();
        }
    }
}