using System.Collections.Generic;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Levels;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
using CodeBase.Lobby.Shop;
using CodeBase.Lobby.Shop.Item;
using UnityEngine;

namespace CodeBase.Lobby.Data
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public LobbyAudioManager AudioManagerPrefab;
        public LobbyMainView MainViewPrefab;
        public LobbySettingsView SettingsViewPrefab;

        public LobbyDailyBonusCongratsView DailyBonusCongratsViewPrefab;
        public LobbyDailyBonusOverviewView DailyBonusOverviewViewPrefab;
        public LobbyDailyBonusCountItemView DailyBonusCountItemViewPrefab;
        public List<LobbyDailyBonusCountItemPreset> DailyBonusCountItemPresets;
        public LobbyDailyBonusCountItemPreset WeeklyBonusCountItemPreset;

        public LobbyShopView LobbyShopViewPrefab;
        public LobbyShopItemGroup LobbyShopItemGroupPrefab;
        public LobbyShopItem LobbyShopItemPrefab;
        public LobbyShopItemDonate LobbyShopDonateItemPrefab;
        public List<LobbyShopItemPreset> ShopItemPresets;
        
        public LobbyLevelsView LobbyLevelsViewPrefab;
    }
}