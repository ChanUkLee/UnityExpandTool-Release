using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace UnityExpandTool
{
    public class ExpandToolWindow : EditorWindow
    {
        [MenuItem("Window/UnityExpandTool/Settings")]
        static void View()
        {
            var texture = Resources.Load<Texture>("icons/icon_window");

            var window = EditorWindow.GetWindow<ExpandToolWindow>();
            window.Show();
            window.titleContent = new GUIContent("ExpandTool", texture);
        }

        [MenuItem("Window/UnityExpandTool/UnityExpandTool")]
        static void CreateToolInstance()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/ExpandTool");
            var tool = FindObjectsOfType<ExpandTool>();
            if (tool == null)
            {
                PrefabUtility.InstantiatePrefab(prefab);
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
            else
            {
                Debug.LogWarning("exists tool");
            }
        }

        [MenuItem("Window/UnityExpandTool/Mail Setting")]
        static void CreateMailInstance()
        {
            CreateEncryptInstance();

            Directory.CreateDirectory(Path.GetDirectoryName(Mail.ASSET_PATH));

            var asset = AssetDatabase.LoadAssetAtPath<Mail>($"{Mail.ASSET_PATH}");

            if (asset == null)
            {
                asset = CreateInstance<Mail>();
                AssetDatabase.CreateAsset(asset, $"{Mail.ASSET_PATH}");
                AssetDatabase.Refresh();
            }

            Selection.activeObject = asset;
        }

        static void CreateEncryptInstance()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Encrypt.ASSET_PATH));

            var asset = AssetDatabase.LoadAssetAtPath<Encrypt>($"{Encrypt.ASSET_PATH}");

            if (asset == null)
            {
                asset = CreateInstance<Encrypt>();
                AssetDatabase.CreateAsset(asset, $"{Encrypt.ASSET_PATH}");

                asset.Generate();
                EditorUtility.SetDirty(asset);
                AssetDatabase.SaveAssets();

                AssetDatabase.Refresh();
            }
        }

        void OnGUI()
        {
            
        }
    }
}
