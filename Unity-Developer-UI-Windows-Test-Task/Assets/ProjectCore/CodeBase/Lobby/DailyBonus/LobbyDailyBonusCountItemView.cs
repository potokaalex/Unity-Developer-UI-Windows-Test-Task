using CodeBase.Lobby.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusCountItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dayNumberText;
        [SerializeField] private TextMeshProUGUI _ticketsCountText;

        public void Initialize(LobbyDailyBonusCountItemPreset preset)
        {
            _dayNumberText.text = $"day{preset.DayNumber.ToString()}";
            _ticketsCountText.text = $"X{preset.TicketsCount.ToString()}";
        }
    }
}