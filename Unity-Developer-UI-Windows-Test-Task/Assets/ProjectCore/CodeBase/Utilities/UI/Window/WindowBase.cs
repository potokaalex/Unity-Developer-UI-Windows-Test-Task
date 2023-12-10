using UnityEngine;

namespace CodeBase.Utilities.UI.Window
{
    public abstract class WindowBase : MonoBehaviour, IWindow
    {
        public virtual void Open()
        {
        }

        public virtual void Close()
        {
        }
    }
}