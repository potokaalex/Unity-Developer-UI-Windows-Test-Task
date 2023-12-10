using System.Collections.Generic;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Lobby.Shop.Item;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Shop;
using UnityEngine;

namespace CodeBase.Lobby.Data
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public LobbyMainView MainViewPrefab;
        public SettingsView SettingsViewPrefab;

        public DailyBonusCongratsView DailyBonusCongratsViewPrefab;
        public DailyBonusOverviewView DailyBonusOverviewViewPrefab;
        public DailyBonusCountItemView DailyBonusCountItemViewPrefab;
        public List<LobbyDailyBonusCountItemPreset> DailyBonusCountItemPresets;
        public LobbyDailyBonusCountItemPreset WeeklyBonusCountItemPreset;

        public ShopView ShopViewPrefab;
        public ShopItemGroup ShopItemGroupPrefab;
        public ShopItem ShopItemPrefab;
        public ShopItemDonate ShopDonateItemPrefab;
        public List<LobbyShopItemPreset> ShopItemPresets;
        
        public LobbyLevelsView LobbyLevelsViewPrefab;
    }
}