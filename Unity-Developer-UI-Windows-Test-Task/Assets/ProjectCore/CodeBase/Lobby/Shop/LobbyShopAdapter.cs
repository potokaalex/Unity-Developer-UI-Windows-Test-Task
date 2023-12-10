using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Data;
using CodeBase.Project.Data.Saved;
using CodeBase.Project.Services.WindowsManagerService;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopAdapter : IDisposable
    {
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly WindowsManager _windowsManager;
        private readonly LobbyModel _model;
        private LobbyShopView _lobbyShopView;
        private LobbyConfig _config;
        private SavedGameData _data;

        public LobbyShopAdapter(LobbyStaticDataProvider staticDataProvider, WindowsManager windowsManager,
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
            _windowsManager.RegisterWindow(WindowType.Shop, lobbyShopView);

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

        private void OnLevelChanged(int reachedLevel)
        {
            foreach (var preset in _config.ShopItemPresets)
                if (preset.RequiredLevelNumber == reachedLevel)
                    _lobbyShopView.UnlockItem(preset.ID);
        }
    }
}