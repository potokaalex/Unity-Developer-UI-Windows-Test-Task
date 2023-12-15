using System.Collections.Generic;
using CodeBase.Lobby.UI;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Shop;
using CodeBase.UI.Shop.Item;
using UnityEngine;

namespace CodeBase.Lobby.Data
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public Transform CanvasPrefab;
        public LobbyView ViewPrefab;
        public LobbySettingsConfig Settings;
        
        //next - old.

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