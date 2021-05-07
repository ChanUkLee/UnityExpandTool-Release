using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace UnityExpandTool
{
    public class ConsoleView : MonoBehaviour
    {
        [SerializeField]
        private ConsoleListView _recyclingListView = null;

        [SerializeField]
        private SubmitInputField _inputSearchingFilter = null;

        [SerializeField]
        private Console_LogFilterButton _logFilterBtnLogType = null;

        [SerializeField]
        private Console_LogFilterButton _logFilterBtnWarnType = null;

        [SerializeField]
        private Console_LogFilterButton _logFilterBtnErrorType = null;

        [SerializeField]
        private StacktraceView _stacktrace = null;

        [SerializeField]
        private GameObject _wait = null;

        private List<LogData> _viewList = new List<LogData>();

        private bool _logActive = true;
        private bool _warnActive = true;
        private bool _errorActive = true;

        private void OnEnable()
        {
            _recyclingListView.Init();
            _recyclingListView.VerticalNormalizedPosition = 0f;
            _recyclingListView.ItemCallback = PopulateItem;
            //_recyclingListView.RowCount = LogManager.GetLogList().Count;

            _logFilterBtnLogType.SetActive(_logActive);
            _logFilterBtnWarnType.SetActive(_warnActive);
            _logFilterBtnErrorType.SetActive(_errorActive);

            ResetViewList();

            ExpandTool.Instance.Log.OnMessageReceived += UpdateLog;
        }

        private void OnDisable()
        {
            ExpandTool.Instance.Log.OnMessageReceived -= UpdateLog;

            _recyclingListView.ItemCallback = null;
            _recyclingListView.RowCount = 0;
        }

        /// <summary>
        /// 목록 갱신
        /// </summary>
        private void ResetViewList()
        {
            _viewList.Clear();

            ResetCountOnLogFilter();

            if (!_logActive && !_warnActive && !_errorActive)
            {
                _recyclingListView.RowCount = 0;
                return;
            }

            var skipSearching = string.IsNullOrEmpty(_inputSearchingFilter.text);
            var searchingText = _inputSearchingFilter.text.ToLower();

            for (var i = 0; i < ExpandTool.Instance.Log.GetLogList().Count; i++)
            {
                var logData = ExpandTool.Instance.Log.GetLogList().Get(i);

                if (!IsView(logData.LogType))
                    continue;

                if (!skipSearching && !logData.Condition.ToLower().Contains(searchingText))
                    continue;

                _viewList.Add(logData);
            }

            var normalizePos = _recyclingListView.VerticalNormalizedPosition;

            _recyclingListView.RowCount = _viewList.Count;

            _recyclingListView.VerticalNormalizedPosition = normalizePos;
        }

        /// <summary>
        /// 로그 필터 버튼위 카운트 텍스트 갱신
        /// </summary>
        private void ResetCountOnLogFilter()
        {
            _logFilterBtnLogType.Count = ExpandTool.Instance.Log.GetLogList().InfoCount;
            _logFilterBtnWarnType.Count = ExpandTool.Instance.Log.GetLogList().WarningCount;
            _logFilterBtnErrorType.Count = ExpandTool.Instance.Log.GetLogList().ErrorCount;
        }

        /// <summary>
        /// 활성화 된 로그 타입인지 확인
        /// </summary>
        /// <param name="logType"></param>
        /// <returns></returns>
        private bool IsView(LogType logType)
        {
            switch (logType)
            {
                case LogType.Log:
                    return _logActive;

                case LogType.Warning:
                    return _warnActive;

                case LogType.Error:
                default:
                    return _errorActive;
            }
        }

        /// <summary>
        /// 신규 로그 이벤트
        /// </summary>
        /// <param name="logData"></param>
        private void UpdateLog(LogData logData)
        {
            if (logData == null)
            {
                ResetCountOnLogFilter();

                _viewList.Clear();

                _recyclingListView.RowCount = 0;
            }
            else
            {
                ResetCountOnLogFilter();

                if (!IsView(logData.LogType))
                    return;

                _viewList.Add(logData);

                _recyclingListView.RowCount = _viewList.Count;
            }
        }

        /// <summary>
        /// 아이템 내용 갱신
        /// </summary>
        /// <param name="item"></param>
        /// <param name="rowIndex"></param>
        private void PopulateItem(RecyclingListViewItem item, int rowIndex)
        {
            var logViewerItem = item as ConsoleListItemView;
            logViewerItem.LogData = _viewList[rowIndex];
            logViewerItem.Index = rowIndex;
            logViewerItem.Stacktrace = _stacktrace;
        }

        /// <summary>
        /// 로그 필터 버튼 이벤트
        /// </summary>
        /// <param name="button"></param>
        public void OnLogFilterButtonClick(Console_LogFilterButton button)
        {
            switch (button.LogType)
            {
                case LogType.Log:
                    _logActive = !_logActive;
                    _logFilterBtnLogType.SetActive(_logActive);
                    ResetViewList();
                    break;

                case LogType.Warning:
                    _warnActive = !_warnActive;
                    _logFilterBtnWarnType.SetActive(_warnActive);
                    ResetViewList();
                    break;

                case LogType.Error:
                default:
                    _errorActive = !_errorActive;
                    _logFilterBtnErrorType.SetActive(_errorActive);
                    ResetViewList();
                    break;
            }
        }

        /// <summary>
        /// 로그 클린 이벤트
        /// </summary>
        public void LogClear()
        {
            ExpandTool.Instance.Log.Clear();
        }

        public void OnSearchingText()
        {
            ResetViewList();
        }

        public async void OnShare()
        {
            _wait?.SetActive(true);

            // TODO 메일 공유 기능
            await ExpandTool.Instance.Log.Pause();

            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    await Mail.SendAsync(ExpandTool.TargetMail, "Log share", new System.Net.Mail.Attachment(ExpandTool.Instance.Log.FilePath));
                    break;
                }
                catch (IOException)
                {
                    await Task.Delay(1000);
                }
            }

            await ExpandTool.Instance.Log.Resume();

            _wait?.SetActive(false);
        }
    }
}