using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.DailyBonus
{
    public class DailyBonusCountItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dayNumberText;
        [SerializeField] private TextMeshProUGUI _ticketsCountText;

        public void Initialize(int dayNumber,int ticketsCount)
        {
            _dayNumberText.text = $"day{dayNumber.ToString()}";
            _ticketsCountText.text = $"X{ticketsCount.ToString()}";
        }
    }
}