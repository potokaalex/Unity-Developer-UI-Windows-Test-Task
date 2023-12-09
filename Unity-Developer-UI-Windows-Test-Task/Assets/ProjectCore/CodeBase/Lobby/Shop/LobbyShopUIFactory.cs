using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private LobbyConfig _config;

        public LobbyShopUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public LobbyShopView CreateView(Transform root)
        {
            var prefab = _config.LobbyShopViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyShopView>(prefab);

            item.transform.SetParent(root, false);

            return item;
        }
    }
}