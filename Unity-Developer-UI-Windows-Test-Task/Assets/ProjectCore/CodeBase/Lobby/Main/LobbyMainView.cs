using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ticketsCount;

        public Transform GetViewsRoot() => gameObject.transform;

        public void Initialize(int coinsCount) => SetCoinsCount(coinsCount);

        public void SetCoinsCount(int count) => _ticketsCount.text = count.ToString();
    }
}