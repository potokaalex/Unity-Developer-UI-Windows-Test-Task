using CodeBase.UI.Shop;

namespace CodeBase.Lobby.Data
{
    public class LobbyConfigProvider
    {
        private readonly LobbyConfig _config;
        private readonly ShopConfig _shopConfig;

        public LobbyConfigProvider(LobbyConfig config, ShopConfig shopConfig)
        {
            _config = config;
            _shopConfig = shopConfig;
        }

        public LobbyConfig GetConfig() => _config;

        public ShopConfig GetShopConfig() => _shopConfig;
    }
}