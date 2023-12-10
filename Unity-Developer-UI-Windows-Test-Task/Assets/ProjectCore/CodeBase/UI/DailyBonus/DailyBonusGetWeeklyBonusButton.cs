using CodeBase.Project.Services;
using CodeBase.UI.DailyBonus;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class DailyBonusGetWeeklyBonusButton : ButtonBase
    {
        private DailyBonusAdapter _adapter;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(AudioManager audioManager, DailyBonusAdapter adapter)
        {
            _audioManager = audioManager;
            _adapter = adapter;
        }

        private protected override void OnClick()
        {
            _adapter.GetWeeklyBonus();
            _audioManager.PlayButtonClickUISound();
        }
    }
}