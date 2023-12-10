using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyCloseCurrentWindowButton : ButtonBase
    {
        private ILobbyCloseCurrentWindowAdapter _closeCurrentWindowAdapter;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager) => _audioManager = audioManager;

        public void Initialize(ILobbyCloseCurrentWindowAdapter closeCurrentWindowAdapter) => _closeCurrentWindowAdapter = closeCurrentWindowAdapter;

        private protected override void OnClick()
        {
            _closeCurrentWindowAdapter.CloseCurrentWindow();
            _audioManager.PlayButtonClickUISound();
        }
    }
}