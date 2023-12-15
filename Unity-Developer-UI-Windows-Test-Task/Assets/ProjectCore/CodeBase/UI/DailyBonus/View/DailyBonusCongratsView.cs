using CodeBase.Utilities.UI.Window;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.DailyBonus.View
{
    public class DailyBonusCongratsView : MonoBehaviour, IWindow
    {
        [SerializeField] private TextMeshProUGUI _ticketsCountText;
        [SerializeField] private TextMeshProUGUI _dayNumberText;

        public void SetTicketsCount(int count) => _ticketsCountText.text = $"x{count.ToString()}";

        public void SetDayNumber(int number) => _dayNumberText.text = $"day {number.ToString()}";

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}