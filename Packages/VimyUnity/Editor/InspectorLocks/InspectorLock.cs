using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace VimyUnity.Editor
{
    public class InspectorLock : IInspectorLock
    {
        public void ToggleLock()
        {
            Type inspectorType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");
            EditorWindow window = EditorWindow.GetWindow(inspectorType);
            
            // Hack via reflection because unity won't expose API
            PropertyInfo? isLockedProperty = inspectorType.GetProperty(
                "isLocked",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            );

            if (isLockedProperty == null)
            {
                Debug.LogError($"Cannot find isLock property for {nameof(ToggleLock)} operation");
                return;
            }
            
            bool isLocked = (bool) isLockedProperty.GetValue(window);
            isLockedProperty.SetValue(window, !isLocked);
            window.Repaint();
        }
    }
}