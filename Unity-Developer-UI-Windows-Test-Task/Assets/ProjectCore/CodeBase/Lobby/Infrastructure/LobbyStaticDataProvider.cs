namespace CodeBase.Lobby.Infrastructure
{
    public class LobbyStaticDataProvider
    {
        private readonly LobbyConfig _config;

        public LobbyStaticDataProvider(LobbyConfig config) => _config = config;

        public LobbyConfig GetConfig() => _config;
    }
}