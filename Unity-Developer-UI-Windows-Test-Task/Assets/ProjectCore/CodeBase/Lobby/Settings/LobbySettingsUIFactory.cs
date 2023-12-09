using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Settings
{
    public class LobbySettingsUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbySettingsAdapter _adapter;
        private readonly LobbyModel _model;

        public LobbySettingsUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbySettingsAdapter adapter, LobbyModel model)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _adapter = adapter;
            _model = model;
        }

        public LobbySettingsView CreateView(Transform root)
        {
            var prefab = _staticDataProvider.GetConfig().SettingsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbySettingsView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(_adapter, _model.GetGameData().Settings);

            return item;
        }
    }
}