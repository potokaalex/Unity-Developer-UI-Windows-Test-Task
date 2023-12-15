using CodeBase.Utilities.UI.Window;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.DailyBonus.View
{
    public class DailyBonusOverviewView : MonoBehaviour, IWindow
    {
        [SerializeField] private Transform _countItemsRoot;
        [SerializeField] private TextMeshProUGUI _sliderProgressText;
        [SerializeField] private Slider _slider;
        private DailyBonusUIFactory _dailyBonusUIFactory;
        private float _daysContToReachWeeklyBonus;

        [Inject]
        public void Construct(DailyBonusUIFactory dailyBonusUIFactory) => _dailyBonusUIFactory = dailyBonusUIFactory;

        public void Initialize(float daysContToReachWeeklyBonus)
        {
            _daysContToReachWeeklyBonus = daysContToReachWeeklyBonus;
            _slider.maxValue = _daysContToReachWeeklyBonus;

            _dailyBonusUIFactory.CreateCountItems(_countItemsRoot);
            Close();
        }

        public void SetProgress(int consecutiveDaysCount)
        {
            _sliderProgressText.text = $"{consecutiveDaysCount}/{_daysContToReachWeeklyBonus}";
            _slider.value = consecutiveDaysCount;
        }

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}