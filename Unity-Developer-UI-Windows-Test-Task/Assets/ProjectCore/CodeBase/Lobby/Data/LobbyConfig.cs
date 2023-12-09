using System.Collections.Generic;
using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Main;
using CodeBase.Lobby.Settings;
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
    }
}