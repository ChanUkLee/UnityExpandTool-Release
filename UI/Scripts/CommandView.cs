using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityExpandTool
{
    [DisallowMultipleComponent]
    public class CommandView : MonoBehaviour
    {
        [SerializeField]
        private Transform _content;

        [SerializeField]
        private NameItemView _itemViewPrefab = null;

        private List<NameItemView> _itemViewList = null;

        public void Append(string name, Action action)
        {
            if (_itemViewList == null)
                _itemViewList = new List<NameItemView>();

            var obj = Instantiate(_itemViewPrefab, _content);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            var comp = obj.GetComponent<NameItemView>();
            comp.Name = name;
            comp.Action = action;

            _itemViewList.Add(comp);
        }

        public void Remove(string name)
        {
            if (_itemViewList == null)
                return;

            foreach (var itemView in _itemViewList)
            {
                if (itemView.Name == name)
                {
                    _itemViewList.Remove(itemView);
                    Destroy(itemView);
                    break;
                }
            }
        }

        public void Clear()
        {
            foreach (var itemView in _itemViewList)
                Destroy(itemView);

            _itemViewList.Clear();
        }
    }
}