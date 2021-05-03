using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityExpandTool
{
    /// <summary>
    /// 로그 필터 버튼
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class Console_LogFilterButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private LogType _logType = LogType.Log;

        public LogType LogType { get => _logType; }

        [Header("Background")]
        /// <summary>
        /// 로그 필터 버튼 배경
        /// </summary>
        [SerializeField]
        private Image _imageBG = null;

        [Header("Icon")]
        /// <summary>
        /// 로그 아이콘
        /// </summary>
        [SerializeField]
        private Image _imageIcon = null;

        [Header("Text")]
        /// <summary>
        /// 로그 갯수 텍스트
        /// </summary>
        [SerializeField]
        private Text _textCount = null;

        [Header("Event")]
        /// <summary>
        /// 로그 필터 이벤트
        /// </summary>
        [SerializeField]
        private UnityEvent _onClick = null;

        /// <summary>
        /// 로그 갯수
        /// </summary>
        public int Count
        {
            set
            {
                var active = value != 0;

                _textCount.text = $"{value}";
                _textCount.color = active ? ExpandTool.Theme.ColorLogFilterBtnActiveText.Color : ExpandTool.Theme.ColorLogFilterBtnInactiveText.Color;
                _imageIcon.sprite = active ? ExpandTool.Theme.GetActiveLogIcon(_logType) : ExpandTool.Theme.GetInactiveLogIcon(_logType);
            }
        }

        /// <summary>
        /// 현재 활성화 여ㅂ
        /// </summary>
        /// <param name="selected">활성화 여부(TRUE:활성화, FALSE:비활성화)</param>
        public void SetActive(bool active)
        {
            _imageBG.color = active ? ExpandTool.Theme.ColorLogFilterBtnActiveBG.Color : ExpandTool.Theme.ColorLogFilterBtnInactiveBG.Color;
        }

        /// <summary>
        /// 로그 필터 이벤트
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            _onClick.Invoke();
        }
    }
}
