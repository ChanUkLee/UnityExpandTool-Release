using UnityEngine;
using UnityEngine.UI;

namespace UnityExpandTool
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class KeyValueItemView : MonoBehaviour
    {
        [SerializeField]
        private Image _imageBG = null;

        public Color32 ColorBG { set => _imageBG.color = value; }

        [SerializeField]
        private Text _textKey = null;

        public string Key { set => _textKey.text = value; }

        [SerializeField]
        private Text _textValue = null;

        public string Value { set => _textValue.text = value; }

        private RectTransform _rectTransform = null;

        public float Width
        {
            set
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();

                var sizeDelta = _rectTransform.sizeDelta;
                sizeDelta.x = value;
                _rectTransform.sizeDelta = sizeDelta;
            }
        }
    }
}