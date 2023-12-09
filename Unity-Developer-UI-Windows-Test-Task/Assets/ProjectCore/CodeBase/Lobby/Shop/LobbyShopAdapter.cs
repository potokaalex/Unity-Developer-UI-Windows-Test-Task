using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.WindowsManager;
using UnityEngine.Events;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyWindowsManager _windowsManager;
        private LobbyShopView _lobbyShopView;
        private LobbyConfig _config;

        public LobbyShopAdapter(LobbyStaticDataProvider staticDataProvider,LobbyWindowsManager windowsManager)
        {
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize(LobbyShopView lobbyShopView)
        {
            _config = _staticDataProvider.GetConfig();
            _lobbyShopView = lobbyShopView;

            _lobbyShopView.Initialize(_config.ShopTicketsItemPresets,_config.ShopSkinsItemPresets,_config.ShopLocationsItemPresets);
        }

        public void BuyItem(LobbyShopDonateItemPreset preset)
        {

        }

        public void BuyItem(LobbyShopItemPreset preset)
        {
            
        }

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}