using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
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
            Container.Bind<LobbyDailyBonusUIFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<LobbyAudioManagerProvider>().AsSingle();
            Container.Bind<LobbyStaticDataProvider>().AsSingle().WithArguments(_lobbyConfig);
        }

        private void BindAdapters()
        {
            Container.Bind<LobbyMainAdapter>().AsSingle();
            Container.Bind<LobbySettingsAdapter>().AsSingle();
            Container.Bind<LobbyDailyBonusAdapter>().AsSingle();
        }
    }
}