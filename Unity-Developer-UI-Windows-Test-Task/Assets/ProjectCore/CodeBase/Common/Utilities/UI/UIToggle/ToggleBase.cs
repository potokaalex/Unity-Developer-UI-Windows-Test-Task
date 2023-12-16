using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Common.Utilities.UI.UIToggle
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleBase : MonoBehaviour
    {
        private protected Toggle SelectableToggle;

        private void Awake() => SelectableToggle = GetComponent<Toggle>();

        private void OnEnable() => SelectableToggle.onValueChanged.AddListener(OnToggleValueChanged);

        private void OnDisable() => SelectableToggle.onValueChanged.RemoveListener(OnToggleValueChanged);

        private protected abstract void OnToggleValueChanged(bool isActive);
    }
}