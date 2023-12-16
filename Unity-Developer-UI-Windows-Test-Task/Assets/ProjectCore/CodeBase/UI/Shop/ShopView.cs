using System.Collections.Generic;
using CodeBase.UI.Shop.Item;
using CodeBase.Utilities.UI.Window;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Shop
{
    public class ShopView : MonoBehaviour, IWindow
    {
        [SerializeField] private Transform _itemGroupsRoot;
        private ShopUIFactory _shopUIFactory;

        [Inject]
        public void Construct(ShopUIFactory shopUIFactory) => _shopUIFactory = shopUIFactory;

        public void Initialize()
        {
            Items = _shopUIFactory.CreateItems(_itemGroupsRoot);
            Close();
        }

        public List<IShopItemView> Items { get; private set; }

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}