using UnityEditor;
using UnityEngine;

namespace VimyUnity.Editor
{
    [InitializeOnLoad]
    public static class VimyUnityEntryPoint
    {
        private const string ToolsPath = "Tools/Vimy/";

        private static readonly IWindowsFocus WindowsFocus;

        static VimyUnityEntryPoint()
        {
            WindowsFocus = new WindowsFocus();
        }

        [MenuItem(ToolsPath + nameof(ActiveWindowsCount))]
        private static void ActiveWindowsCount()
        {
            var windows = Resources.FindObjectsOfTypeAll<EditorWindow>()!;
            var index = 0;
            Debug.Log($"Total active windows: {windows.Length}");
            foreach (var w in windows)
            {
                Debug.Log($"{++index} Active windows: {w.GetType().Name} - {w.hasFocus}");
            }
        }

        [MenuItem(ToolsPath + nameof(SwitchNext) + " _n")]
        private static void SwitchNext()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Next);
        }

        [MenuItem(ToolsPath + nameof(SwitchPrevious) + " #n")]
        private static void SwitchPrevious()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Previous);
        }

        [MenuItem(ToolsPath + nameof(SwitchUp) + " #k")]
        private static void SwitchUp()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Up);
        }

        [MenuItem(ToolsPath + nameof(SwitchDown) + " #j")]
        private static void SwitchDown()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Down);
        }

        [MenuItem(ToolsPath + nameof(SwitchRight) + " #l")]
        private static void SwitchRight()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Right);
        }

        [MenuItem(ToolsPath + nameof(SwitchLeft) + " #h")]
        private static void SwitchLeft()
        {
            WindowsFocus.FocusOn(IWindowsFocus.FocusType.Left);
        }

        [MenuItem(ToolsPath + nameof(CloseCurrentWindow) + " #x")]
        private static void CloseCurrentWindow()
        {
            WindowsFocus.CloseCurrent();
        }
    }
}