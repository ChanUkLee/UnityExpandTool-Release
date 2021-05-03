using System.Collections.Generic;
using UnityEngine;

namespace UnityExpandTool
{
    [DisallowMultipleComponent]
    public class RootView : MonoBehaviour
    {
        [SerializeField]
        private Transform _content = null;

        [SerializeField]
        private GroupView _groupViewPrefab = null;

        protected Dictionary<string, GroupView> _groups = null;

        protected void CreateGroup(string name)
        {
            if (_groups == null)
                _groups = new Dictionary<string, GroupView>();

            if (_groups.ContainsKey(name))
                return;

            var obj = Instantiate(_groupViewPrefab, _content);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            var comp = obj.GetComponent<GroupView>();
            comp.Name = name;

            _groups.Add(name, comp);
        }

        protected void Append(string name, string key, string value)
        {
            if (_groups == null)
                _groups = new Dictionary<string, GroupView>();

            if (!_groups.ContainsKey(name))
                CreateGroup(name);

            _groups[name].Append(key, value);
        }
    }
}
