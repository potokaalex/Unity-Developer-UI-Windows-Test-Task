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
            Container.Bind<LobbyFactory>().AsSingle();
            Container.Bind<LobbyWindowsManager>().AsSingle();
            Container.Bind<LobbyAudioManagerProvider>().AsSingle();
            Container.Bind<LobbyMainAdapter>().AsSingle();
            Container.Bind<LobbySettingsAdapter>().AsSingle();
            Container.Bind<LobbyModel>().AsSingle();
            Container.Bind<LobbyUIFactory>().AsSingle();
            Container.Bind<LobbySettingsUIFactory>().AsSingle();
            Container.Bind<LobbyStaticDataProvider>().AsSingle().WithArguments(_lobbyConfig);
        }
    }
}