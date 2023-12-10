using System.Collections.Generic;
using CodeBase.Lobby.Main;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Settings;
using CodeBase.UI.Shop;
using CodeBase.UI.Shop.Item;
using UnityEngine;

namespace CodeBase.Lobby
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public LobbyMainView MainViewPrefab;
        public SettingsView SettingsViewPrefab;

        public DailyBonusCongratsView DailyBonusCongratsViewPrefab;
        public DailyBonusOverviewView DailyBonusOverviewViewPrefab;
        public DailyBonusCountItemView DailyBonusCountItemViewPrefab;
        public List<DailyBonusCountItemPreset> DailyBonusCountItemPresets;
        public DailyBonusCountItemPreset WeeklyBonusCountItemPreset;

        public ShopView ShopViewPrefab;
        public ShopItemGroup ShopItemGroupPrefab;
        public ShopItem ShopItemPrefab;
        public ShopItemDonate ShopDonateItemPrefab;
        public List<ShopItemPreset> ShopItemPresets;

        public LobbyLevelsView LobbyLevelsViewPrefab;
    }
}