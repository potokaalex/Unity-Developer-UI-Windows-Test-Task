using ProjectCore.CodeBase.Lobby.Infrastructure;
using UnityEngine;
using Zenject;

namespace ProjectCore.CodeBase.Lobby.Settings
{
    public class LobbySettingsUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;

        public LobbySettingsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
        }

        public LobbySettingsView CreateView(Transform root)
        {
            var prefab = _staticDataProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbySettingsView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize();
            
            return item;
        }
    }
}