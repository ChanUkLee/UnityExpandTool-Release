using UnityEngine;
using UnityEditor;

namespace UnityExpandTool
{
    [CustomEditor(typeof(Encrypt))]
    public class EncryptEditor : Editor
    {
        private Encrypt _target = null;

        private SerializedProperty _type = null;
        private SerializedProperty _key = null;
        private SerializedProperty _iv = null;

        public void OnEnable()
        {
            _target = target as Encrypt;

            _type = serializedObject.FindProperty("_type");
            _key = serializedObject.FindProperty("_key");
            _iv = serializedObject.FindProperty("_iv");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_type, new GUIContent("Type"));

            if (GUILayout.Button("Generate"))
            {
                serializedObject.ApplyModifiedProperties();

                Generate();
            }
        }

        private void Generate()
        {
            var algorithm = Encrypt.Create();

            if (algorithm == null)
                throw new System.ArgumentNullException();

            algorithm.GenerateKey();
            algorithm.GenerateIV();

            _key.ClearArray();
            _iv.ClearArray();

            byte[] key = Encrypt.StaticEncode(algorithm.Key);
            byte[] iv = Encrypt.StaticEncode(algorithm.IV);

            _key.arraySize = key.Length;
            for (int i = 0; i < key.Length; i++)
                _key.GetArrayElementAtIndex(i).intValue = key[i];

            _iv.arraySize = iv.Length;
            for (int i = 0; i < iv.Length; i++)
                _iv.GetArrayElementAtIndex(i).intValue = iv[i];

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(_target);
        }
    }
}