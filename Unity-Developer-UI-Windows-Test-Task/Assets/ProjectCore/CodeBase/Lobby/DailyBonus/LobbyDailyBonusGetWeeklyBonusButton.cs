using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Utilities.UI;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusGetWeeklyBonusButton : ButtonBase
    {
        private LobbyDailyBonusAdapter _adapter;
        private LobbyAudioManagerProvider _audioManagerProvider;
        private LobbyAudioManager _audioManager;

        [Inject]
        public void Construct(LobbyDailyBonusAdapter adapter, LobbyAudioManagerProvider audioManagerProvider)
        {
            _adapter = adapter;
            _audioManagerProvider = audioManagerProvider;
        }

        public void Initialize() => _audioManager = _audioManagerProvider.GetManager();

        private protected override void OnClick()
        {
            _adapter.GetWeeklyBonus();
            _audioManager.PlayButtonClick();
        }
    }
}