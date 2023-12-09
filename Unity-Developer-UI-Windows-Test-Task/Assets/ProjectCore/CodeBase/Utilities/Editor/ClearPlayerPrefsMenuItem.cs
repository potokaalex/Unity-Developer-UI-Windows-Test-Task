using UnityEditor;
using UnityEngine;

namespace CodeBase.Utilities.Editor
{
    public class ClearPlayerPrefsMenuItem
    {
        [MenuItem("Tools/Clear Player Prefs")]
        private static void ClearPlayerPrefs() => PlayerPrefs.DeleteAll();
    }
}