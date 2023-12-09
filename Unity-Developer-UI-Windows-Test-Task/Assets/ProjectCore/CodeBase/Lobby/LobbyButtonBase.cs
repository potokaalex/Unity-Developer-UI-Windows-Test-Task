using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby
{
    public abstract class LobbyButtonBase : ButtonBase
    {
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyAudioManagerProvider audioManagerProvider) =>
            _audioManagerProvider = audioManagerProvider;

        private protected virtual void Initialize() => _audioManager = _audioManagerProvider.GetManager();

        private protected void PlayClickSound() => _audioManager.PlayButtonClick();
    }
}