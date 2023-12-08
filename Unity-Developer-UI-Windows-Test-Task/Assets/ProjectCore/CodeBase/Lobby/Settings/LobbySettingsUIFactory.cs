using CodeBase.Lobby.Infrastructure;
using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyAudioManagerProvider _lobbyAudioManagerProvider;

        public LobbySettingsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyAudioManagerProvider lobbyAudioManagerProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _lobbyAudioManagerProvider = lobbyAudioManagerProvider;
        }

        public LobbySettingsView CreateView(Transform root, LobbySettingsAdapter settingsAdapter)
        {
            var audioManger = _lobbyAudioManagerProvider.GetManager();
            var prefab = _staticDataProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbySettingsView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(settingsAdapter, audioManger);

            return item;
        }
    }
}