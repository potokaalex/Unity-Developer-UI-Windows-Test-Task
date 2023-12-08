using CodeBase.Utilities.UI;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyCloseCurrentWindowButton : ButtonBase
    {
        private ILobbyCloseCurrentWindowAdapter _closeCurrentWindowAdapter;
        private LobbyAudioManager _audioManager;

        public void Initialize(ILobbyCloseCurrentWindowAdapter closeCurrentWindowAdapter, LobbyAudioManager audioManager)
        {
            _closeCurrentWindowAdapter = closeCurrentWindowAdapter;
            _audioManager = audioManager;
        }

        private protected override void OnClick()
        {
            _closeCurrentWindowAdapter.CloseCurrentWindow();
            _audioManager.PlayButtonClick();
        }
    }
}