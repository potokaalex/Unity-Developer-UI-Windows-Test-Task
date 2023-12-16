using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.UI
{
    public class LobbyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ticketsCount;

        public void SetCoinsCount(int count) => _ticketsCount.text = count.ToString();
    }
}