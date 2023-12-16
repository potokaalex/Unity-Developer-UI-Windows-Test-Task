using System.Collections.Generic;
using CodeBase.Utilities.UI.Window;
using UnityEngine;

namespace CodeBase.UI.Levels.View
{
    public class LevelsView : MonoBehaviour, IWindow
    {
        [SerializeField] private List<LevelsOpenLevelButton> _levelsOpenLevelButtons;

        public List<LevelsOpenLevelButton> OpenLevelButtons => _levelsOpenLevelButtons;

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}