using System.Collections.Generic;
using CodeBase.Utilities.UI.Window;
using UnityEngine;

namespace CodeBase.UI.Levels
{
    public class LobbyLevelsView : WindowBase
    {
        [SerializeField] private List<LevelsOpenLevelButton> _levelsOpenLevelButtons;

        public void Initialize(int reachedLevel)
        {
            Close();

            for (var i = 0; i < _levelsOpenLevelButtons.Count; i++)
                _levelsOpenLevelButtons[i].Initialize(i + 1, i <= reachedLevel);
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

        public void OnReachedLevelChanged(int levelNumber)
        {
            if (levelNumber <= _levelsOpenLevelButtons.Count)
                _levelsOpenLevelButtons[levelNumber - 1].Unlock();
        }
    }
}