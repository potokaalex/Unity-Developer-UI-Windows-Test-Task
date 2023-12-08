using ProjectCore.CodeBase.Utilities.UI;
using Zenject;

namespace ProjectCore.CodeBase.Lobby.Main
{
    public class LobbyMainCloseWindowButton : ButtonBase
    {
        private LobbyMainAdapter _lobbyMainAdapter;

        [Inject]
        public void Construct(LobbyMainAdapter lobbyMainAdapter) => _lobbyMainAdapter = lobbyMainAdapter;

        private protected override void OnClick() => _lobbyMainAdapter.CloseCurrentWindow();
    }
}