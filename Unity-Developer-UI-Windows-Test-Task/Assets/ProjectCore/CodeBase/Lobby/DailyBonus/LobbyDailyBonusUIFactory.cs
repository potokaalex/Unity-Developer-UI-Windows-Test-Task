using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyDailyBonusAdapter _adapter;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private LobbyConfig _config;

        public LobbyDailyBonusUIFactory(IInstantiator instantiator, LobbyDailyBonusAdapter adapter,
            LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _adapter = adapter;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public LobbyDailyBonusCongratsView CreateCongratsView(Transform root)
        {
            var prefab = _config.DailyBonusCongratsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyDailyBonusCongratsView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(_adapter);

            return item;
        }

        public LobbyDailyBonusOverviewView CreateOverviewView(Transform root)
        {
            var prefab = _config.DailyBonusOverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyDailyBonusOverviewView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(_adapter, _config.DailyBonusCountItemPresets);

            return item;
        }

        public void CreateCountItemView(Transform root, LobbyDailyBonusCountItemPreset preset)
        {
            var prefab = _config.DailyBonusCountItemViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyDailyBonusCountItemView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset);
        }
    }
}