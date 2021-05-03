using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityExpandTool
{
    [DisallowMultipleComponent]
    public class GroupView : MonoBehaviour
    {
        [SerializeField]
        private Transform _content = null;

        [SerializeField]
        private LineView _lineViewPrefab = null;

        [SerializeField]
        private Text _textName = null;

        public string Name { set => _textName.text = value; }

        private LineView _currentLineView = null;

        private List<LineView> _lineViewList = null;

        public void Append(string key, string value)
        {
            if (_currentLineView == null || _currentLineView.IsFull)
            {
                var obj = Instantiate(_lineViewPrefab, _content);

                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                obj.transform.localScale = Vector3.one;

                _currentLineView = obj.GetComponent<LineView>();

                if (_lineViewList == null)
                    _lineViewList = new List<LineView>();

                _currentLineView.Index = _lineViewList.Count;
                _lineViewList.Add(_currentLineView);
            }

            _currentLineView.Append(key, value);
        }
    }
}