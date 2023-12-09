using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.WindowsManager
{
    public class LobbyCloseCurrentWindowButton : ButtonBase
    {
        private LobbyAudioManagerProvider _audioManagerProvider;
        private ILobbyCloseCurrentWindowAdapter _closeCurrentWindowAdapter;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyAudioManagerProvider audioManagerProvider) =>
            _audioManagerProvider = audioManagerProvider;

        public void Initialize(ILobbyCloseCurrentWindowAdapter closeCurrentWindowAdapter)
        {
            _closeCurrentWindowAdapter = closeCurrentWindowAdapter;
            _audioManager = _audioManagerProvider.GetManager();
        }

        private protected override void OnClick()
        {
            _closeCurrentWindowAdapter.CloseCurrentWindow();
            _audioManager.PlayButtonClick();
        }
    }
}