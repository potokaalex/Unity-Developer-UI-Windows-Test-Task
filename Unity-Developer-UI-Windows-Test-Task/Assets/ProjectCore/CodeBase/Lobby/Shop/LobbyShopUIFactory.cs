using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.Shop.Item;
using CodeBase.Project.Services.AssetProviderService;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly IAssetProvider _assetProvider;
        private LobbyConfig _config;

        public LobbyShopUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _assetProvider = assetProvider;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public LobbyShopView CreateView(Transform root)
        {
            var prefab = _config.LobbyShopViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyShopView>(prefab);

            item.transform.SetParent(root, false);

            return item;
        }

        public LobbyShopItemGroup CreateItemGroup(Transform root, ShopGroupType groupType)
        {
            var prefab = _config.LobbyShopItemGroupPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyShopItemGroup>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(groupType);

            return item;
        }

        public LobbyShopItem CreateItem(LobbyShopItemPreset preset, Transform root)
        {
            var prefab = _config.LobbyShopItemPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyShopItem>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset, _assetProvider.Get<Sprite>(preset.IconName));
            
            return item;
        }

        public void CreateDonateItem(LobbyShopItemPreset preset, Transform root)
        {
            var prefab = _config.LobbyShopDonateItemPrefab;
            var args = new object[] { preset };
            var item = _instantiator.InstantiatePrefabForComponent<LobbyShopItemDonate>(prefab, args);

            item.transform.SetParent(root, false);
            item.Initialize(_assetProvider.Get<Sprite>(preset.IconName));
        }
    }
}