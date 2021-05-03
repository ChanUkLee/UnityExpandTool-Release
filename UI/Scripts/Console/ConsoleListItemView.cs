using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityExpandTool
{
    public class ConsoleListItemView : RecyclingListViewItem, IPointerClickHandler
    {
        [SerializeField]
        private Image _imageBG = null;

        [SerializeField]
        private Image _iconImage = null;

        [SerializeField]
        private Text _textCondition = null;

        private LogData _logData = null;

        public LogData LogData
        {
            get { return _logData; }
            set
            {
                _logData = value;
                _textCondition.text = $"[{_logData.Timestamp}] {_logData.Condition}";
                SetIcon(_logData.LogType);
            }
        }

        public int Index
        {
            set
            {
                var color = value % 2 == 0 ? ExpandTool.Theme.ColorListItemBG1.Color : ExpandTool.Theme.ColorListItemBG2.Color;
                SetBackgroundColor(color);
            }
        }

        public StacktraceView Stacktrace { get; set; }

        private void OnEnable()
        {
            _textCondition.color = ExpandTool.Theme.ColorListItemConditionText.Color;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Stacktrace.Open(_logData);
        }

        private void SetBackgroundColor(Color color)
        {
            _imageBG.color = color;
        }

        private void SetIcon(LogType logType)
        {
            _iconImage.sprite = ExpandTool.Theme.GetActiveLogIcon(logType);
        }
    }
}