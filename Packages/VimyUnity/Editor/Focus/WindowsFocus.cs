using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VimyUnity.Editor
{
    public class WindowsFocus : IWindowsFocus
    {
        private const float Threshold = 0.7f;

        public void FocusOn(IWindowsFocus.FocusType type)
        {
            switch (type)
            {
                case IWindowsFocus.FocusType.Next:
                    FocusByIndexOffset(1);
                    break;
                case IWindowsFocus.FocusType.Previous:
                    FocusByIndexOffset(-1);
                    break;
                case IWindowsFocus.FocusType.Up:
                    FocusByDirection(Vector2.up);
                    break;
                case IWindowsFocus.FocusType.Down:
                    FocusByDirection(Vector2.down);
                    break;
                case IWindowsFocus.FocusType.Right:
                    FocusByDirection(Vector2.right);
                    break;
                case IWindowsFocus.FocusType.Left:
                    FocusByDirection(Vector2.left);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static void FocusByIndexOffset(int offset)
        {
            var windows = Windows();
            var focusId = CurrentFocusId(windows);
            var desiredFocus = focusId + offset;
            if (desiredFocus < 0)
            {
                desiredFocus += windows.Count;
            }
            var index = desiredFocus % windows.Count;
            windows[index].Focus();
        }

        private static void FocusByDirection(Vector2 direction)
        {
            var windows = Windows();
            var focusedWindow = EditorWindow.focusedWindow;
            var rect = focusedWindow.position;
            var currentCenter = rect.center;

            var candidate = windows.Where(w => IsInDirection(w.position.center, currentCenter, direction))
                .OrderBy(w => Vector2.Distance(w.position.center, rect.center))
                .FirstOrDefault();

            if (candidate == null)
            {
                Debug.LogWarning("Next window to switch is not found");
                return;
            }

            candidate.Focus();
        }

        private static bool IsInDirection(Vector2 targetCenter, Vector2 currentCenter, Vector2 direction)
        {
            var delta = targetCenter - currentCenter;
            var dot = Vector2.Dot(delta.normalized, direction);
            return dot > Threshold;
        }

        private static int CurrentFocusId(IReadOnlyList<EditorWindow> windows)
        {
            var activeWindow = EditorWindow.focusedWindow;
            for (var i = 0; i < windows.Count; i++)
            {
                if (windows[i] == activeWindow)
                    return i;
            }
            throw new Exception("Doesn't have a focused window!");
        }

        private static IReadOnlyList<EditorWindow> Windows()
        {
            return Resources.FindObjectsOfTypeAll<EditorWindow>();
        }
    }
}