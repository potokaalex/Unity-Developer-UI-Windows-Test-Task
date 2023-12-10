using CodeBase.Lobby.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.Shop
{
    public class ShopItemGroup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Transform _itemsRoot;

        public void Initialize(ShopGroupType groupType) => _name.text = groupType.ToString();

        public Transform GetItemsRoot() => _itemsRoot;
    }
}