using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Utilities.UI
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleBase : MonoBehaviour
    {
        private protected Toggle SelectableToggle;

        private void Awake() => SelectableToggle = GetComponent<Toggle>();

        private void OnEnable() => SelectableToggle.onValueChanged.AddListener(OnValueChange);

        private void OnDisable() => SelectableToggle.onValueChanged.RemoveListener(OnValueChange);

        private protected abstract void OnValueChange(bool isActive);
    }
}