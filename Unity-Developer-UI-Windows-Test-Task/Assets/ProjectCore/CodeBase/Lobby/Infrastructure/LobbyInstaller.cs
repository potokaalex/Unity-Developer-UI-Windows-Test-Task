using System;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Lobby.WindowsManager;
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
            BindProviders();
            BindAdapters();

            Container.Bind<LobbyWindowsManager>().AsSingle();
            Container.Bind<LobbyModel>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<LobbyFactory>().AsSingle();
            Container.Bind<LobbyMainUIFactory>().AsSingle();
            Container.Bind<LobbySettingsUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyDailyBonusUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyShopUIFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<LobbyAudioManagerProvider>().AsSingle();
            Container.Bind<LobbyStaticDataProvider>().AsSingle().WithArguments(_lobbyConfig);
        }

        private void BindAdapters()
        {
            Container.Bind(typeof(LobbyMainAdapter), typeof(IDisposable)).To<LobbyMainAdapter>().AsSingle();
            Container.Bind<LobbySettingsAdapter>().AsSingle();
            Container.Bind<LobbyDailyBonusAdapter>().AsSingle();
            Container.Bind(typeof(LobbyShopAdapter)).To<LobbyShopAdapter>().AsSingle();
        }
    }
}