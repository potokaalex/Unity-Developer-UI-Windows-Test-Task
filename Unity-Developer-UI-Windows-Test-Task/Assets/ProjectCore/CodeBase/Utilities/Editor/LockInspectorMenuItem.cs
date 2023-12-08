using UnityEditor;

namespace ProjectCore.CodeBase.Utilities.Editor
{
    public class LockInspectorMenuItem
    {
        // taken from: http://answers.unity3d.com/questions/282959/set-inspector-lock-by-code.html
        [MenuItem("Tools/Toggle Inspector Lock #a")] // Shift + A
        private static void ToggleInspectorLock()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }
    }
}