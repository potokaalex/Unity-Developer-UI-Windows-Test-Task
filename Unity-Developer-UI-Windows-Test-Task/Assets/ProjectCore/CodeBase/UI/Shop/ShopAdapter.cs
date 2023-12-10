using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Data.Saved;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;
using CodeBase.UI.Shop;

namespace CodeBase.Lobby.Shop
{
    public class ShopAdapter : IDisposable
    {
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly WindowsManager _windowsManager;
        private readonly UIModel _model;
        private readonly ShopUIFactory _shopUIFactory;

        private ShopView _shopView;
        private LobbyConfig _config;

        public ShopAdapter(LobbyStaticDataProvider staticDataProvider, WindowsManager windowsManager,
            UIModel model, ShopUIFactory shopUIFactory)
        {
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
            _model = model;
            _shopUIFactory = shopUIFactory;
        }

        public void Initialize()
        {
            _config = _staticDataProvider.GetConfig();

            _shopView = _shopUIFactory.CreateView();
            _shopView.Initialize(_config.ShopItemPresets);
            _windowsManager.RegisterWindow(WindowType.Shop, _shopView);

            var playerProgress = _model.ReadOnlyData.PlayerProgress;

            foreach (var preset in _config.ShopItemPresets)
            {
                if (playerProgress.BoughtItemsNames.Contains(preset.ID))
                    _shopView.ShowBuy(preset.ID);

                if (preset.RequiredLevelNumber <= playerProgress.ReachedLevel)
                    if (preset.GroupType != ShopGroupType.Tickets)
                        _shopView.UnlockItem(preset.ID);
            }

            _model.OnLevelChanged += OnLevelChanged;
        }

        public void Dispose() => _model.OnLevelChanged -= OnLevelChanged;

        public void BuyItem(LobbyShopItemPreset preset)
        {
            var playerProgress = _model.ReadOnlyData.PlayerProgress;
            
            if (playerProgress.TicketsCount < preset.Cost)
                return;

            if (playerProgress.BoughtItemsNames.Contains(preset.ID))
                return;

            if (playerProgress.ReachedLevel < preset.RequiredLevelNumber)
                return;

            playerProgress.BoughtItemsNames.Add(preset.ID);
            _shopView.ShowBuy(preset.ID);
            _model.RemoveTicketsCount((int)preset.Cost);
        }

        public void BuyItemDonate(LobbyShopItemPreset preset) => _model.AddTicketsCount(preset.Count);

        private void OnLevelChanged(int reachedLevel)
        {
            foreach (var preset in _config.ShopItemPresets)
                if (preset.RequiredLevelNumber == reachedLevel)
                    _shopView.UnlockItem(preset.ID);
        }
    }
}