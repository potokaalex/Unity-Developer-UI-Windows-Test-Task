using CodeBase.Project.Services;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class DailyBonusGetWeeklyBonusButton : ButtonBase
    {
        private DailyBonusAdapter _adapter;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(DailyBonusAdapter adapter, AudioManager audioManager)
        {
            _adapter = adapter;
            _audioManager = audioManager;
        }

        private protected override void OnClick()
        {
            _adapter.GetWeeklyBonus();
            _audioManager.PlayButtonClickUISound();
        }
    }
}