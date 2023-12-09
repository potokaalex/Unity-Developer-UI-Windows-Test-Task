using System.Collections.Generic;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Shop.Item;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Utilities.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Shop
{
    public class LobbyShopView : WindowBase
    {
        [SerializeField] private LobbyCloseCurrentWindowButton _closeCurrentWindowButton;
        [SerializeField] private List<LobbyShopItemDonate> _shopBuyTicketItems;
        [SerializeField] private List<LobbyShopItem> _shopBuySkinItems;
        [SerializeField] private List<LobbyShopItem> _shopBuyLocationItems;
        private LobbyShopAdapter _shopAdapter;

        [Inject]
        public void Construct(LobbyShopAdapter shopAdapter) => _shopAdapter = shopAdapter;

        public void Initialize(List<LobbyShopDonateItemPreset> ticketPresets, List<LobbyShopItemPreset> skinPresets,
            List<LobbyShopItemPreset> locationPresets)
        {
            _closeCurrentWindowButton.Initialize(_shopAdapter);
            Close();

            for (var i = 0; i < _shopBuyTicketItems.Count; i++)
                _shopBuyTicketItems[i].Initialize(ticketPresets[i]);

            for (var i = 0; i < _shopBuySkinItems.Count; i++)
                _shopBuySkinItems[i].Initialize(skinPresets[i]);

            for (var i = 0; i < _shopBuyLocationItems.Count; i++)
                _shopBuyLocationItems[i].Initialize(locationPresets[i]);
        }

        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }
    }
}