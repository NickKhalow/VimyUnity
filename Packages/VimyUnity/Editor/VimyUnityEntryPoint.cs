using UnityEditor;
using UnityEngine;

namespace VimyUnity.Editor
{
    [InitializeOnLoad]
    public static class VimyUnityWindowsEntryPoint
    {
        private const string ToolsPath = "Tools/Vimy/";
        private static readonly IWindowsFocus WindowsFocus;

        static VimyUnityWindowsEntryPoint()
        {
            WindowsFocus = new WindowsFocus();
        }

        [MenuItem(ToolsPath + nameof(ActiveWindowsCount))]
        private static void ActiveWindowsCount()
        {
            var windows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            var index = 0;
            Debug.Log($"Total active windows: {windows.Length}");
            foreach (var w in windows)
            {
                Debug.Log($"{++index} Active windows: {w.GetType().Name} - {w.hasFocus}");
            }
        }

        [MenuItem(ToolsPath + nameof(SwitchNext))]
        private static void SwitchNext()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Next);
        }

        [MenuItem(ToolsPath + nameof(SwitchPrevious))]
        private static void SwitchPrevious()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Previous);
        }

        [MenuItem(ToolsPath + nameof(SwitchUp))]
        private static void SwitchUp()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Up);
        }

        [MenuItem(ToolsPath + nameof(SwitchDown))]
        private static void SwitchDown()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Down);
        }

        [MenuItem(ToolsPath + nameof(SwitchRight))]
        private static void SwitchRight()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Right);
        }

        [MenuItem(ToolsPath + nameof(SwitchLeft))]
        private static void SwitchLeft()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Left);
        }
    }
}