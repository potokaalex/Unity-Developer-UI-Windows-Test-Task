using ProjectCore.CodeBase.Lobby.Main;
using ProjectCore.CodeBase.Lobby.Settings;
using UnityEngine;

namespace ProjectCore.CodeBase.Lobby.Data
{
    [CreateAssetMenu(menuName = "Configurations/Lobby", fileName = "LobbyConfig", order = 0)]
    public class LobbyConfig : ScriptableObject
    {
        public LobbyMainView MainViewPrefab;
        public LobbySettingsView SettingsViewPrefab;
    }
}