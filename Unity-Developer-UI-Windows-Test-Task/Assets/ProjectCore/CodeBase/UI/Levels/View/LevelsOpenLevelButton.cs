using CodeBase.Utilities.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Levels.View
{
    public class LevelsOpenLevelButton : ButtonBase
    {
        [SerializeField] private TextMeshProUGUI _levelNumberText;
        [SerializeField] private Transform _isLockedRoot;
        [SerializeField] private Transform _isOpenedRoot;
        private LevelsController _controller;
        private int _levelNumber;

        [Inject]
        public void Construct(LevelsController controller) => _controller = controller;

        public void Initialize(int levelNumber, bool isLocked)
        {
            _levelNumberText.text = levelNumber.ToString();
            _levelNumber = levelNumber;

            SetLock(isLocked);
        }

        public void SetLock(bool isLocked)
        {
            _isLockedRoot.gameObject.SetActive(isLocked);
            _isOpenedRoot.gameObject.SetActive(!isLocked);
        }

        private protected override void OnClick() => _controller.OpenLevel(_levelNumber);
    }
}