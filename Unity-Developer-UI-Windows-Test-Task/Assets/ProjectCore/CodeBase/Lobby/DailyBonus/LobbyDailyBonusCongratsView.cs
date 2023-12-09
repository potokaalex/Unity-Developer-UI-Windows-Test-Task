using CodeBase.Lobby.WindowsManager;
using CodeBase.Utilities.UI;
using TMPro;
using UnityEngine;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusCongratsView : WindowBase
    {
        [SerializeField] private LobbyCloseCurrentWindowButton _closeWindowButton;
        [SerializeField] private TextMeshProUGUI _ticketsCountText;
        [SerializeField] private TextMeshProUGUI _dayNumberText;

        public void Initialize(LobbyDailyBonusAdapter dailyBonusAdapter)
        {
            Close();
            _closeWindowButton.Initialize(dailyBonusAdapter);
        }

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