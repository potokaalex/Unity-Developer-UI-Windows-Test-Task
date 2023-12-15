using TMPro;
using UnityEngine;

namespace CodeBase.UI.DailyBonus.View.CountItem
{
    public class DailyBonusCountItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dayNumberText;
        [SerializeField] private TextMeshProUGUI _ticketsCountText;

        public void Initialize(DailyBonusCountItemData data)
        {
            _dayNumberText.text = $"day{data.DayNumber.ToString()}";
            _ticketsCountText.text = $"X{data.TicketsCount.ToString()}";
        }
    }
}