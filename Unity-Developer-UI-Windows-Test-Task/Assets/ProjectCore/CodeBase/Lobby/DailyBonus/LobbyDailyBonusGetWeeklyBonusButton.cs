using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusGetWeeklyBonusButton : ButtonBase
    {
        private LobbyDailyBonusAdapter _adapter;

        [Inject]
        public void Construct(LobbyDailyBonusAdapter adapter) => _adapter = adapter;

        private protected override void OnClick() => _adapter.GetWeeklyBonus();
    }
}