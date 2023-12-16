using CodeBase.Common.Utilities.UI.UIButton;
using Zenject;

namespace CodeBase.UI.DailyBonus.View
{
    public class DailyBonusGetWeeklyBonusButton : ButtonBaseSfx
    {
        private DailyBonusController _controller;

        [Inject]
        public void Construct(DailyBonusController controller) => _controller = controller;

        private protected override void OnClick()
        {
            _controller.GetWeeklyBonus();
            PlayButtonClickSound();
        }
    }
}