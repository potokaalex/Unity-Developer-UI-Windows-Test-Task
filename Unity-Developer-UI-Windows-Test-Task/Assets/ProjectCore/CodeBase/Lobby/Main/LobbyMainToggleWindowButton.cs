using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainToggleWindowButton : ButtonBase
    {
        [SerializeField] private LobbyWindowType _lobbyWindowType;

        private LobbyMainAdapter _lobbyMainAdapter;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager) => _audioManager = audioManager;

        public void Initialize(LobbyMainAdapter lobbyMainAdapter)
        {
            _lobbyMainAdapter = lobbyMainAdapter;
        }

        private protected override void OnClick()
        {
            _lobbyMainAdapter.ToggleCurrentWindow(_lobbyWindowType);
            _audioManager.PlayButtonClickUISound();
        }
    }
}