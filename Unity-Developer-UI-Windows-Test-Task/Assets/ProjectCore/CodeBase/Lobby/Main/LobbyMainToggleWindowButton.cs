using CodeBase.Lobby.Data;
using CodeBase.Utilities.UI;
using UnityEngine;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainToggleWindowButton : ButtonBase
    {
        [SerializeField] private LobbyWindowType _lobbyWindowType;
        private LobbyMainAdapter _lobbyMainAdapter;
        private LobbyAudioManager _audioManager;

        public void Initialize(LobbyMainAdapter lobbyMainAdapter, LobbyAudioManager audioManager)
        {
            _lobbyMainAdapter = lobbyMainAdapter;
            _audioManager = audioManager;
        }

        private protected override void OnClick()
        {
            _lobbyMainAdapter.ToggleCurrentWindow(_lobbyWindowType);
            _audioManager.PlayButtonClick();
        }
    }
}