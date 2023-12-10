using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Infrastructure.Providers;
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

        private LobbyStaticDataProvider _staticDataProvider;
        private DailyBonusUIFactory _dailyBonusUIFactory;
        private int _maxSliderValue;

        [Inject]
        public void Construct(LobbyStaticDataProvider staticDataProvider, DailyBonusUIFactory dailyBonusUIFactory)
        {
            _staticDataProvider = staticDataProvider;
            _dailyBonusUIFactory = dailyBonusUIFactory;
        }

        public void Initialize()
        {
            var config = _staticDataProvider.GetConfig();

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