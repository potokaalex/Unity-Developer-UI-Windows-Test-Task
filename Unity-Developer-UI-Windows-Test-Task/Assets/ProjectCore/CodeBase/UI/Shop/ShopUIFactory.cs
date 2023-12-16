using System.Collections.Generic;
using System.Linq;
using CodeBase.Common.Services.AssetProviderService;
using CodeBase.Common.Services.WindowsManagerService;
using CodeBase.UI.Shop.Item;
using CodeBase.UI.Shop.Item.BuyButton;
using CodeBase.UI.Shop.Item.Data;
using CodeBase.UI.Shop.Item.Donate;
using CodeBase.UI.Shop.Item.Group;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Shop
{
    public class ShopUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly WindowsManager _windowsManager;
        private readonly ShopController _controller;
        private ShopConfig _config;

        public ShopUIFactory(IInstantiator instantiator, IAssetProvider assetProvider, WindowsManager windowsManager,
            ShopController controller)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _windowsManager = windowsManager;
            _controller = controller;
        }

        public void Initialize(ShopConfig config) => _config = config;

        public void Create(Transform viewsRoot)
        {
            var view = CreateView(viewsRoot, _config.ViewPrefab);
            _windowsManager.RegisterWindow(WindowType.Shop, view);
            _controller.Initialize(view);
        }

        private T CreateView<T>(Transform root, T prefab) where T : MonoBehaviour
        {
            var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab);
            instance.transform.SetParent(root, false);
            return instance;
        }

        public List<IShopItemView> CreateItems(Transform itemGroupsRoot)
        {
            var result = new List<IShopItemView>();

            result.AddRange(CreateGroupWithItems(ShopItemGroupType.Tickets, itemGroupsRoot));
            result.AddRange(CreateGroupWithItems(ShopItemGroupType.Skins, itemGroupsRoot));
            result.AddRange(CreateGroupWithItems(ShopItemGroupType.Locations, itemGroupsRoot));

            return result;
        }

        private List<IShopItemView> CreateGroupWithItems(ShopItemGroupType type, Transform root)
        {
            var items = new List<IShopItemView>();
            var group = CreateView(root, _config.ItemsGroupPrefab);
            var presets = _config.ItemsPresets.Where(p => p.GroupType == type);

            group.Initialize(type);

            foreach (var preset in presets)
            {
                IShopItemView item = preset.Type switch
                {
                    ShopItemType.NonDonate => CreateNonDonateItem(group.GetItemsRoot(), preset),
                    ShopItemType.Donate => CreateDonateItem(group.GetItemsRoot(), preset),
                    _ => default
                };

                item.BuyButton.Initialize(new ShopItemBuyData
                {
                    GroupType = preset.GroupType,
                    ID = preset.ID,
                    TicketsCost = preset.TicketsCost,
                    ItemsCount = preset.ItemsCount,
                    RequiredLevelNumber = preset.RequiredLevelNumber,
                    IsConsumable = preset.IsConsumable
                });

                items.Add(item);
            }

            return items;
        }

        private ShopItemView CreateNonDonateItem(Transform root, ShopItemPreset preset)
        {
            var item = CreateView(root, _config.ItemPrefab);
            item.Initialize(new ShopItemData
            {
                ID = preset.ID,
                Name = preset.Name,
                TicketsCost = preset.TicketsCost,
                RequiredLevelNumber = preset.RequiredLevelNumber,
                UnLockIcon = _assetProvider.GetIcon(preset.IconName),
                LockIcon = _assetProvider.GetIcon(preset.LockIconName)
            });
            return item;
        }

        private ShopDonateItemView CreateDonateItem(Transform root, ShopItemPreset preset)
        {
            var item = CreateView(root, _config.DonateItemPrefab);
            item.Initialize(new ShopDonateItemData
            {
                ID = preset.ID,
                Name = preset.Name,
                Cost = preset.DonateCost,
                ItemsCount = preset.ItemsCount,
                DefaultIcon = _assetProvider.GetIcon(preset.IconName)
            });
            return item;
        }
    }
}