using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.UI.DailyBonus.View
{
    public class DailyBonusGetWeeklyBonusButton : ButtonBase
    {
        private DailyBonusController _controller;

        [Inject]
        public void Construct(DailyBonusController controller) => _controller = controller;

        private protected override void OnClick() => _controller.GetWeeklyBonus();
    }
}