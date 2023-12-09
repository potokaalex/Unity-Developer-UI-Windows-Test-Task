using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Project.Data;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopAdapter : ILobbyCloseCurrentWindowAdapter, IDisposable
    {
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyModel _model;
        private LobbyShopView _lobbyShopView;
        private LobbyConfig _config;
        private GameData _data;

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
            _data = _model.GetGameData();

            foreach (var preset in _config.ShopItemPresets)
            {
                if (_data.PlayerProgress.BoughtItemsNames.Contains(preset.ID))
                    _lobbyShopView.ShowBuy(preset.ID);

                if (preset.RequiredLevelNumber <= _data.PlayerProgress.ReachedLevel)
                    if (preset.GroupType != ShopGroupType.Tickets)
                        _lobbyShopView.UnlockItem(preset.ID);
            }

            _model.OnLevelChanged += OnLevelChanged;
        }

        public void Dispose() => _model.OnLevelChanged -= OnLevelChanged;

        public void BuyItem(LobbyShopItemPreset preset)
        {
            if (_data.PlayerProgress.TicketsCount < preset.Cost)
                return;

            if (_data.PlayerProgress.BoughtItemsNames.Contains(preset.ID))
                return;

            if (_data.PlayerProgress.ReachedLevel < preset.RequiredLevelNumber)
                return;

            _data.PlayerProgress.BoughtItemsNames.Add(preset.ID);
            _lobbyShopView.ShowBuy(preset.ID);
            _model.RemoveTicketsCount((int)preset.Cost);
        }

        public void BuyItemDonate(LobbyShopItemPreset preset) => _model.AddTicketsCount(preset.Count);

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();

        private void OnLevelChanged(int reachedLevel)
        {
            foreach (var preset in _config.ShopItemPresets)
                if (preset.RequiredLevelNumber == reachedLevel)
                    _lobbyShopView.UnlockItem(preset.ID);
        }
    }
}