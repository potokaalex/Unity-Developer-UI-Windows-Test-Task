using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.WindowsManager;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyModel _model;
        private LobbyShopView _lobbyShopView;
        private LobbyConfig _config;

        public LobbyShopAdapter(LobbyStaticDataProvider staticDataProvider, LobbyWindowsManager windowsManager,
            LobbyModel model)
        {
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
            _model = model;
        }

        public void Initialize(LobbyShopView lobbyShopView)
        {
            _config = _staticDataProvider.GetConfig();
            _lobbyShopView = lobbyShopView;

            _lobbyShopView.Initialize(_config.ShopItemPresets);

            var data = _model.GetGameData();

            /*
            foreach (var savedItem in data.PlayerProgress.BoughtItems)
            {
                if(_config.ShopTicketsItemPresets)

                savedItem.ItemID
            }
            */

            //разблокировать нужные сохранения!
            //_model.AddTicketsCount();
        }

        public void BuyItem(LobbyShopItemPreset preset)
        {

        }

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}