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
    }
}