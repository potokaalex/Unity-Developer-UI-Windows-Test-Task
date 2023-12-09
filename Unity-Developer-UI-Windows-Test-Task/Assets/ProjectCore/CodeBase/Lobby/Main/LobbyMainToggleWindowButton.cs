using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainToggleWindowButton : ButtonBase
    {
        [SerializeField] private LobbyWindowType _lobbyWindowType;

        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyMainAdapter _lobbyMainAdapter;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyAudioManagerProvider audioManagerProvider) =>
            _audioManagerProvider = audioManagerProvider;

        public void Initialize(LobbyMainAdapter lobbyMainAdapter)
        {
            _lobbyMainAdapter = lobbyMainAdapter;
            _audioManager = _audioManagerProvider.GetManager();
        }

        private protected override void OnClick()
        {
            _lobbyMainAdapter.ToggleCurrentWindow(_lobbyWindowType);
            _audioManager.PlayButtonClick();
        }
    }
}