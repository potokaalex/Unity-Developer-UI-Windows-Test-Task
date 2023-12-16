using CodeBase.Lobby.UI;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using UnityEngine;

namespace CodeBase.Lobby.Data
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public Transform CanvasPrefab;
        public LobbyView ViewPrefab;
        public LobbySettingsConfig Settings;
        public DailyBonusConfig DailyBonus;
        public LevelsConfig Levels;
    }
}