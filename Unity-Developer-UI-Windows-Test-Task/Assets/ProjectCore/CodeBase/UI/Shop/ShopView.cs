using System.Collections.Generic;
using System.Linq;
using CodeBase.UI.Shop.Item;
using CodeBase.Utilities.UI.Window;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Shop
{
    public class ShopView : WindowBase
    {
        [SerializeField] private Transform _itemGroupsRoot;

        private readonly Dictionary<string, ShopItem> _items = new();
        private ShopUIFactory _shopUIFactory;

        [Inject]
        public void Construct(ShopUIFactory shopUIFactory) => _shopUIFactory = shopUIFactory;

        public void Initialize(List<ShopItemPreset> itemPresets)
        {
            Close();
            CreateItems(itemPresets);
        }

        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }

        private void CreateItems(List<ShopItemPreset> presets)
        {
            var ticketsItemsPresets = presets.Where(p => p.GroupType == ShopItemGroupType.Tickets);
            var skinsItemsPresets = presets.Where(p => p.GroupType == ShopItemGroupType.Skins);
            var locationsItemsPresets = presets.Where(p => p.GroupType == ShopItemGroupType.Locations);

            CreateItemsInGroups(ticketsItemsPresets, ShopItemGroupType.Tickets);
            CreateItemsInGroups(skinsItemsPresets, ShopItemGroupType.Skins);
            CreateItemsInGroups(locationsItemsPresets, ShopItemGroupType.Locations);
        }

        private void CreateItemsInGroups(IEnumerable<ShopItemPreset> itemsPresets, ShopItemGroupType groupType)
        {
            var group = _shopUIFactory.CreateItemGroup(_itemGroupsRoot, groupType);

            foreach (var preset in itemsPresets)
            {
                if (groupType == ShopItemGroupType.Tickets)
                    _shopUIFactory.CreateDonateItem(preset, group.GetItemsRoot());
                else
                    _items.Add(preset.ID, _shopUIFactory.CreateItem(preset, group.GetItemsRoot()));
            }
        }

        public void ShowBuy(string presetID) => _items[presetID].ShowBuy();

        public void UnlockItem(string presetID) => _items[presetID].Unlock();
    }
}