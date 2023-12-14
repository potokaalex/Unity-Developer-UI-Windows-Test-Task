namespace CodeBase.Lobby.Data
{
    public class LobbyConfigProvider
    {
        private readonly LobbyConfig _config;

        public LobbyConfigProvider(LobbyConfig config) => _config = config;

        public LobbyConfig GetConfig() => _config;
    }
}