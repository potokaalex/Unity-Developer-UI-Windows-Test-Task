using System;
using CodeBase.Lobby.Data;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;
using CodeBase.UI.Shop.Item;

namespace CodeBase.UI.Shop
{
    public class ShopAdapter : IDisposable
    {
        private readonly LobbyConfigProvider _configProvider;
        private readonly WindowsManager _windowsManager;
        private readonly UIModel _model;
        private readonly ShopUIFactory _shopUIFactory;

        private ShopView _shopView;
        private LobbyConfig _config;

        public ShopAdapter(LobbyConfigProvider configProvider, WindowsManager windowsManager,
            UIModel model, ShopUIFactory shopUIFactory)
        {
            _configProvider = configProvider;
            _windowsManager = windowsManager;
            _model = model;
            _shopUIFactory = shopUIFactory;
        }

        public void Initialize()
        {
            _config = _configProvider.GetConfig();

            _shopView = _shopUIFactory.CreateView();
            _shopView.Initialize(_config.ShopItemPresets);
            _windowsManager.RegisterWindow(WindowType.Shop, _shopView);

            var playerProgress = _model.ReadOnlyData.PlayerProgress;

            foreach (var preset in _config.ShopItemPresets)
            {
                if (playerProgress.BoughtItemsNames.Contains(preset.ID))
                    _shopView.ShowBuy(preset.ID);

                if (preset.RequiredLevelNumber <= playerProgress.ReachedLevel)
                    if (preset.GroupType != ShopItemGroupType.Tickets)
                        _shopView.UnlockItem(preset.ID);
            }

            _model.OnLevelChanged += OnLevelChanged;
        }

        public void Dispose() => _model.OnLevelChanged -= OnLevelChanged;

        public void BuyItem(ShopItemPreset preset)
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

        public void BuyItemDonate(ShopItemPreset preset) => _model.AddTicketsCount(preset.Count);

        private void OnLevelChanged(int reachedLevel)
        {
            foreach (var preset in _config.ShopItemPresets)
                if (preset.RequiredLevelNumber == reachedLevel)
                    _shopView.UnlockItem(preset.ID);
        }
    }
}