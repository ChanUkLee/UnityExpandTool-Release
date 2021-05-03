using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace UnityExpandTool
{
    public class ExpandToolWindow : EditorWindow
    {
        Mail _mail = null;

        [MenuItem("Window/UnityExpandTool/Settings")]
        static void View()
        {
            var texture = Resources.Load<Texture>("icons/icon_window");

            var window = EditorWindow.GetWindow<ExpandToolWindow>();
            window.Show();
            window.titleContent = new GUIContent("ExpandTool", texture);
        }

        void Init()
        {
            _mail = Resources.Load<ScriptableObject>("ExpandTool/Mail") as Mail;
        }

        void OnGUI()
        {
            
        }

        void DrawMail()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            _mail.SenderName = GUILayout.TextField(_mail.SenderName);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}
