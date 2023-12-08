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
        private readonly LobbyAudioManagerProvider _audioManagerProvider;
        private readonly LobbySettingsAdapter _adapter;

        public LobbySettingsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyAudioManagerProvider audioManagerProvider, LobbySettingsAdapter adapter)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _audioManagerProvider = audioManagerProvider;
            _adapter = adapter;
        }

        public LobbySettingsView CreateView(Transform root)
        {
            var audioManger = _audioManagerProvider.GetManager();
            var prefab = _staticDataProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbySettingsView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(_adapter, audioManger);
            
            return item;
        }
    }
}