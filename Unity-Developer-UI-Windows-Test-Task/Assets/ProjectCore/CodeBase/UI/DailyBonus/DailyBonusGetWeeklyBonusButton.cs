using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusGetWeeklyBonusButton : ButtonBaseSfx
    {
        private DailyBonusAdapter _adapter;

        [Inject]
        public void Construct(DailyBonusAdapter adapter) => _adapter = adapter;

        private protected override void OnClick()
        {
            _adapter.GetWeeklyBonus();
            PlayButtonClickSound();
        }
    }
}