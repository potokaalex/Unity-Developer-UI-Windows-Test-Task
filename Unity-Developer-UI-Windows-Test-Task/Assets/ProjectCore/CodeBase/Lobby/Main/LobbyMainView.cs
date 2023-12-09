using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainView : MonoBehaviour
    {
        [SerializeField] private List<LobbyMainToggleWindowButton> _toggleButtons;
        [SerializeField] private TextMeshProUGUI _ticketsCount;

        public void Initialize(LobbyMainAdapter lobbyMainAdapter)
        {
            foreach (var button in _toggleButtons)
                button.Initialize(lobbyMainAdapter);
        }

        public Transform GetViewsRoot() => gameObject.transform;

        public void SetCoinsCount(int count) => _ticketsCount.text = count.ToString();
    }
}