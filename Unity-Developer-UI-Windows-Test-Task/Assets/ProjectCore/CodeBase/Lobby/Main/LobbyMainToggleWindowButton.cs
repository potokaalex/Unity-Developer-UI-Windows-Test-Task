using ProjectCore.CodeBase.Lobby.Data;
using ProjectCore.CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace ProjectCore.CodeBase.Lobby.Main
{
    public class LobbyMainToggleWindowButton : ButtonBase
    {
        [SerializeField] private LobbyWindowType _lobbyWindowType;
        private LobbyMainAdapter _lobbyMainAdapter;

        [Inject]
        public void Construct(LobbyMainAdapter lobbyMainAdapter) => _lobbyMainAdapter = lobbyMainAdapter;

        private protected override void OnClick() => _lobbyMainAdapter.ToggleCurrentWindow(_lobbyWindowType);
    }
}