using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure;
using CodeBase.Utilities.UI.Window;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusOverviewView : WindowBase
    {
        [SerializeField] private Transform _countItemsSpawnRoot;
        [SerializeField] private TextMeshProUGUI _sliderProgressText;
        [SerializeField] private Slider _slider;

        private LobbyConfigProvider _configProvider;
        private DailyBonusUIFactory _dailyBonusUIFactory;
        private int _maxSliderValue;

        [Inject]
        public void Construct(LobbyConfigProvider configProvider, DailyBonusUIFactory dailyBonusUIFactory)
        {
            _configProvider = configProvider;
            _dailyBonusUIFactory = dailyBonusUIFactory;
        }

        public void Initialize()
        {
            var config = _configProvider.GetConfig();

            _maxSliderValue = config.DailyBonusCountItemPresets.Count + 1;
            _slider.maxValue = _maxSliderValue;

            foreach (var preset in config.DailyBonusCountItemPresets)
                _dailyBonusUIFactory.CreateCountItemView(_countItemsSpawnRoot, preset);

            Close();
        }

        public void SetSliderProgress(int consecutiveDaysCount)
        {
            _sliderProgressText.text = $"{consecutiveDaysCount}/{_maxSliderValue}";
            _slider.value = consecutiveDaysCount;
        }

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