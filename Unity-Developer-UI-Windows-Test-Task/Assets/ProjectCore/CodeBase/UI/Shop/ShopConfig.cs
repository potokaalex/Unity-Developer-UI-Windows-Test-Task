using System.Collections.Generic;
using CodeBase.UI.Shop.Item;
using CodeBase.UI.Shop.Item.Data;
using CodeBase.UI.Shop.Item.Donate;
using CodeBase.UI.Shop.Item.Group;
using UnityEngine;

namespace CodeBase.UI.Shop
{
    [CreateAssetMenu(menuName = "Configurations/Shop", fileName = "ShopConfig", order = 0)]
    public class ShopConfig : ScriptableObject
    {
        public ShopView ViewPrefab;
        public ShopItemsGroup ItemsGroupPrefab;
        public ShopItemView ItemPrefab;
        public ShopDonateItemView DonateItemPrefab;
        public List<ShopItemPreset> ItemsPresets;
    }
}