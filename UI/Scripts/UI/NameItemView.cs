using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityExpandTool
{
    [DisallowMultipleComponent]
    public class NameItemView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Text _textName = null;

        public string Name { get => _textName.text; set => _textName.text = value; }

        public Action Action { get; set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            Action?.Invoke();
        }
    }
}