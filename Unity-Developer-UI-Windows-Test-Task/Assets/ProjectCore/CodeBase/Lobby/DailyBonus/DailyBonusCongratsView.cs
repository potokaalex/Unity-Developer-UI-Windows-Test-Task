using CodeBase.Utilities.UI;
using CodeBase.Utilities.UI.Window;
using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.DailyBonus
{
    public class DailyBonusCongratsView : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _ticketsCountText;
        [SerializeField] private TextMeshProUGUI _dayNumberText;

        public void Initialize() => Close();

        public void SetTicketsCount(int count) => _ticketsCountText.text = $"x{count.ToString()}";

        public void SetDayNumber(int number) => _dayNumberText.text = $"day {number.ToString()}";

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