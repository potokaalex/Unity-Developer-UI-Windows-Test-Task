using System;
using System.Linq;
using CodeBase.UI.Shop.Item.BuyButton;
using CodeBase.UI.Shop.Item.Group;

namespace CodeBase.UI.Shop
{
    public class ShopController : IDisposable
    {
        private readonly IShopModel _model;
        private ShopView _view;

        public ShopController(IShopModel model) => _model = model;

        public void Initialize(ShopView view)
        {
            _view = view;
            _view.Initialize();

            foreach (var item in _view.Items)
            {
                if (_model.BoughtItemsIDs.Value.Contains(item.ID))
                    item.ShowBought();

                item.ShowLock(item.RequiredLevelNumber >= _model.CompletedLevelNumber.Value);
            }

            _model.CompletedLevelNumber.OnChanged += UnLockItem;
        }

        public void Dispose() => _model.CompletedLevelNumber.OnChanged -= UnLockItem;

        public void BuyItem(ShopItemBuyData data)
        {
            if (_model.TicketsCount.Value < data.TicketsCost)
                return;

            if (_model.CompletedLevelNumber.Value < data.RequiredLevelNumber)
                return;

            if (!data.IsConsumable)
            {
                if (_model.BoughtItemsIDs.Value.Contains(data.ID))
                    return;

                _model.BoughtItemsIDs.Value.Add(data.ID);
            }
            else
            {
                if (data.GroupType == ShopItemGroupType.Tickets)
                    _model.TicketsCount.Value += data.ItemsCount;
            }

            _model.TicketsCount.Value -= data.TicketsCost;

            foreach (var item in _view.Items.Where(i => i.ID == data.ID))
                item.ShowBought();
        }

        private void UnLockItem(int levelNumber)
        {
            foreach (var item in _view.Items)
                if (item.RequiredLevelNumber == levelNumber)
                    item.ShowLock(false);
        }
    }
}