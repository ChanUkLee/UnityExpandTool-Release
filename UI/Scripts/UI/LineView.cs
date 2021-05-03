using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityExpandTool
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    [DisallowMultipleComponent]
    public class LineView : MonoBehaviour
    {
        private readonly int MAX = 2;

        [SerializeField]
        private Transform _content = null;

        [SerializeField]
        private KeyValueItemView _itemViewPrefab = null;

        public bool IsFull
        {
            get
            {
                return _itemViewList == null? false : (_itemViewList.Count >= MAX);
            }
        }

        private List<KeyValueItemView> _itemViewList = null;

        private HorizontalLayoutGroup _horizontalLayoutGroup = null;

        private RectTransform _rectTransform = null;

        public int Index { get; set; }

        public bool Append(string key, string value)
        {
            if (_itemViewList == null)
                _itemViewList = new List<KeyValueItemView>();

            if (_itemViewList.Count >= MAX)
                return false;

            var obj = Instantiate(_itemViewPrefab, _content);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            var comp = obj.GetComponent<KeyValueItemView>();
            comp.Key = key;
            comp.Value = value;
            comp.ColorBG = _itemViewList.Count % 2 == (Index % 2) ? new Color32(45, 45, 45, 255) : new Color32(50, 50, 50, 255);

            if (_horizontalLayoutGroup == null)
                _horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();

            _horizontalLayoutGroup.childControlWidth = _itemViewList.Count > 0;

            if (_itemViewList.Count == 0)
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();

                comp.Width = _rectTransform.sizeDelta.x / 2;
            }

            _itemViewList.Add(comp);

            return true;
        }

        private void OnRectTransformDimensionsChange()
        {
            if (_itemViewList != null && _itemViewList.Count == 1)
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();

                _itemViewList[0].Width = _rectTransform.sizeDelta.x / 2;
            }
        }
    }
}
