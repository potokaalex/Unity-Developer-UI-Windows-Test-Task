using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        private protected Button SelectableButton;

        private protected void Awake() => SelectableButton = GetComponent<Button>();

        private protected void OnEnable() => SelectableButton.onClick.AddListener(OnClick);

        private protected void OnDisable() => SelectableButton.onClick.RemoveListener(OnClick);

        private protected abstract void OnClick();
    }
}