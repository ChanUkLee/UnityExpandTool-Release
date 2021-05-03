using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityExpandTool
{
    public class StacktraceView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _dimmed = null;

        [SerializeField]
        private Image _infoImage = null;

        [SerializeField]
        private Text _condition = null;

        [SerializeField]
        private Text _stackTrace = null;

        private LogData _logData = null;

        public void Open(LogData logData)
        {
            _logData = logData;

            if (_logData == null)
                return;

            _infoImage.sprite = ExpandTool.Theme.GetActiveLogIcon(_logData.LogType);

            _condition.text = $"[{logData.Timestamp}] {logData.Condition}";
            _stackTrace.text = $"[{logData.Timestamp}] {logData.Condition}{Environment.NewLine}{logData.StackTrace}";

            gameObject.SetActive(true);

            _dimmed.SetActive(true);
        }

        public void Copy()
        {
            var textEditor = new TextEditor()
            {
                text = $"[{_logData.Timestamp}] {_logData.Condition}{Environment.NewLine}{_logData.StackTrace}"
            };
            textEditor.SelectAll();
            textEditor.Copy();
        }

        public void Close()
        {
            gameObject.SetActive(false);

            _dimmed.SetActive(false);
        }
    }
}
