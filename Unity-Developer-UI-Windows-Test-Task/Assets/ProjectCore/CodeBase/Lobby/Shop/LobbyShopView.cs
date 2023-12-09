using System.Collections.Generic;
using System.Linq;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Shop.Item;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopView : WindowBase
    {
        [SerializeField] private LobbyCloseCurrentWindowButton _closeCurrentWindowButton;
        [SerializeField] private Transform _itemGroupsRoot;

        private readonly Dictionary<string, LobbyShopItem> _items = new();
        private LobbyShopAdapter _shopAdapter;
        private LobbyShopUIFactory _shopUIFactory;

        [Inject]
        public void Construct(LobbyShopAdapter shopAdapter, LobbyShopUIFactory shopUIFactory)
        {
            _shopAdapter = shopAdapter;
            _shopUIFactory = shopUIFactory;
        }

        public void Initialize(List<LobbyShopItemPreset> itemPresets)
        {
            _closeCurrentWindowButton.Initialize(_shopAdapter);
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

        private void CreateItems(List<LobbyShopItemPreset> presets)
        {
            var ticketsItemsPresets = presets.Where(p => p.GroupType == ShopGroupType.Tickets);
            var skinsItemsPresets = presets.Where(p => p.GroupType == ShopGroupType.Skins);
            var locationsItemsPresets = presets.Where(p => p.GroupType == ShopGroupType.Locations);

            CreateItemsInGroups(ticketsItemsPresets, ShopGroupType.Tickets);
            CreateItemsInGroups(skinsItemsPresets, ShopGroupType.Skins);
            CreateItemsInGroups(locationsItemsPresets, ShopGroupType.Locations);
        }

        private void CreateItemsInGroups(IEnumerable<LobbyShopItemPreset> itemsPresets, ShopGroupType groupType)
        {
            var group = _shopUIFactory.CreateItemGroup(_itemGroupsRoot, groupType);

            foreach (var preset in itemsPresets)
            {
                if (groupType == ShopGroupType.Tickets)
                    _shopUIFactory.CreateDonateItem(preset, group.GetItemsRoot());
                else
                    _items.Add(preset.ID, _shopUIFactory.CreateItem(preset, group.GetItemsRoot()));
            }
        }

        public void ShowBuy(string presetID) => _items[presetID].ShowBuy();

        public void UnlockItem(string presetID) => _items[presetID].Unlock();
    }
}