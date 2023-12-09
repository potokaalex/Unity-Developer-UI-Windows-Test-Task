namespace CodeBase.Lobby.Infrastructure.Providers
{
    public class LobbyAudioManagerProvider
    {
        private LobbyAudioManager _audioManager;

        public void Initialize(LobbyAudioManager audioManager) => _audioManager = audioManager;

        public LobbyAudioManager GetManager() => _audioManager;
    }
}