using ProjectCore.CodeBase.Lobby.Data;
using ProjectCore.CodeBase.Lobby.Main;
using ProjectCore.CodeBase.Lobby.Settings;
using UnityEngine;
using Zenject;

namespace ProjectCore.CodeBase.Lobby.Infrastructure
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LobbyConfig _lobbyConfig;

        public override void InstallBindings()
        {
            Container.Bind<LobbyMainAdapter>().AsSingle();
            Container.Bind<LobbyModel>().AsSingle();
            Container.Bind<LobbyUIFactory>().AsSingle();
            Container.Bind<LobbySettingsUIFactory>().AsSingle();
            Container.Bind<LobbyStaticDataProvider>().AsSingle().WithArguments(_lobbyConfig);
        }
    }
}