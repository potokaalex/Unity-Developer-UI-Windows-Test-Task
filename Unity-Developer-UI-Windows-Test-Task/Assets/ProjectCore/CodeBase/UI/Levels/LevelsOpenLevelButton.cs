using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Levels
{
    public class LevelsOpenLevelButton : ButtonBaseSfx
    {
        [SerializeField] private TextMeshProUGUI _levelNumberText;
        [SerializeField] private GameObject _isLockedRoot;
        [SerializeField] private GameObject _isOpenedRoot;
        private LevelsAdapter _adapter;
        private int _levelNumber;

        [Inject]
        public void Construct(LevelsAdapter adapter) => _adapter = adapter;

        public void Initialize(int levelNumber, bool isOpened)
        {
            _levelNumberText.text = levelNumber.ToString();
            _levelNumber = levelNumber;

            if (isOpened)
                Unlock();
        }

        public void Unlock()
        {
            _isLockedRoot.SetActive(false);
            _isOpenedRoot.SetActive(true);
        }

        private protected override void OnClick()
        {
            _adapter.OnOpenLevelClicked(_levelNumber);
            PlayButtonClickSound();
        }
    }
}