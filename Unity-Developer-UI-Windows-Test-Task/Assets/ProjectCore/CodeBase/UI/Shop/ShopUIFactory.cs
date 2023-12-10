using CodeBase.Lobby;
using CodeBase.Lobby.Infrastructure;
using CodeBase.Project.Services.AssetProviderService;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Shop.Item;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Shop
{
    public class ShopUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly WindowsManager _windowsManager;
        private LobbyConfig _config;

        public ShopUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            IAssetProvider assetProvider, WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _assetProvider = assetProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public ShopView CreateView()
        {
            var prefab = _config.ShopViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ShopView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }

        public ShopItemGroup CreateItemGroup(Transform root, ShopItemGroupType groupType)
        {
            var prefab = _config.ShopItemGroupPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ShopItemGroup>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(groupType);

            return item;
        }

        public ShopItem CreateItem(ShopItemPreset preset, Transform root)
        {
            var prefab = _config.ShopItemPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ShopItem>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset, _assetProvider.Get<Sprite>(preset.IconName));

            return item;
        }

        public void CreateDonateItem(ShopItemPreset preset, Transform root)
        {
            var prefab = _config.ShopDonateItemPrefab;
            var args = new object[] { preset };
            var item = _instantiator.InstantiatePrefabForComponent<ShopItemDonate>(prefab, args);

            item.transform.SetParent(root, false);
            item.Initialize(_assetProvider.Get<Sprite>(preset.IconName));
        }
    }
}