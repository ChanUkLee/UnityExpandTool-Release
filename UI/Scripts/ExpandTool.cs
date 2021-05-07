using System;
using UnityEngine;

namespace UnityExpandTool
{
    #pragma warning disable 0414 // private field assigned but not used.
    public class ExpandTool : MonoBehaviour
    {
        private static ExpandTool _instance = null;

        public static ExpandTool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ExpandTool>();
                    if (_instance == null)
                    {
                        var prefab = Resources.Load("Prefabs/ExpandTool");
                        var instance = Instantiate(prefab, null) as GameObject;
                        _instance = instance.GetComponent<ExpandTool>();
                    }
                    _instance.Initialize();
                }

                return _instance;
            }
        }

        [SerializeField]
        private GameObject _root = null;

        [SerializeField]
        private ConsoleView _consoleView = null;

        [SerializeField]
        private CommandView _commandView = null;

        [SerializeField]
        private SystemView _systemView = null;

        private static UITheme _theme = null;

        public static UITheme Theme
        {
            get
            {
                if (_theme == null)
                    _theme = Resources.Load<UITheme>("Theme/UnityTheme");

                return _theme;
            }
        }

        private Log _log = null;

        public Log Log { get => _log; }

        private void Initialize()
        {
            if (_log == null)
            {
                _log = FindObjectOfType<Log>();

                if (_log == null)
                {
                    var instance = new GameObject("@Log");
                    instance.transform.SetParent(transform);
                    _log = instance.AddComponent<Log>();
                }
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.touchCount > 5 || Input.GetKeyDown(KeyCode.F7))
            {
                Open();
            }
        }

        private static string _targetMail = string.Empty;

        public static string TargetMail { get => _targetMail; set => _targetMail = value; }

        public static void Build()
        {
            Instance.Initialize();
        }

        public void OnClose()
        {
            _root.SetActive(false);
        }

        public static void Open()
        {
            if (!Instance._root.activeSelf)
            {
                Instance._root.SetActive(true);

                if (!Instance._consoleView.gameObject.activeSelf
                   && !Instance._commandView.gameObject.activeSelf
                   && !Instance._systemView.gameObject.activeSelf)
                    Instance._consoleView.gameObject.SetActive(true);
            }
        }

        public static void Close()
        {
            Instance.OnClose();
        }

        public static void AppendFunc(string name, Action action)
        {
            Instance._commandView.Append(name, action);
        }

        public static void RemoveFunc(string name)
        {
            // TODO 치트 제거 기능
        }

        /// <summary>
        /// 추가로 노출할 정보를 입력
        /// </summary>
        /// <param name="name">그룸명</param>
        /// <param name="key">제목</param>
        /// <param name="value">내용</param>
        public static void AppendExtraInfo(string name, string key, string value)
        {
            Instance._systemView.AppendExtra(name, key, value);
        }
    }
}