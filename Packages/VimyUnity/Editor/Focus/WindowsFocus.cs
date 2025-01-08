using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VimyUnity.Editor
{
    public class WindowsFocus : IWindowsFocus
    {
        private const float Stickness = 0.7f;


        private enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }


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
                    FocusByDirection(Direction.Up);
                    break;
                case IWindowsFocus.FocusType.Down:
                    FocusByDirection(Direction.Down);
                    break;
                case IWindowsFocus.FocusType.Right:
                    FocusByDirection(Direction.Right);
                    break;
                case IWindowsFocus.FocusType.Left:
                    FocusByDirection(Direction.Left);
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

        private static void FocusByDirection(Direction direction)
        {
            var windows = Windows();
            var focusedWindow = EditorWindow.focusedWindow;
            var rect = focusedWindow.position;
            switch (direction)
            {
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
                case Direction.Right:
                    break;
                case Direction.Left:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
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