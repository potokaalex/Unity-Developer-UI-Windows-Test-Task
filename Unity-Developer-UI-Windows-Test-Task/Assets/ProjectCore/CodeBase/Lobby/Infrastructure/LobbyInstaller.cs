using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Model;
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
            Container.Bind<UIModel>().AsSingle();
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
            Container.Bind<LobbyMainAdapter>().AsSingle();
            Container.Bind<SettingsAdapter>().AsSingle();
            Container.Bind<DailyBonusAdapter>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyShopAdapter>().AsSingle();
            Container.Bind<LobbyLevelsAdapter>().AsSingle();
        }
    }
}