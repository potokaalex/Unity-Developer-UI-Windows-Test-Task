using UnityEditor;
using UnityEngine;

namespace CodeBase.Utilities.Editor
{
    public class ClearPlayerPrefsMenuItem
    {
        [MenuItem("Tools/ClearPlayerPrefs")]
        private static void ClearPlayerPrefs() => PlayerPrefs.DeleteAll();
    }
}