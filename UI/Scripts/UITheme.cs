using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityExpandTool
{
    [Serializable]
    public class UIThemeIcon
    {
        [SerializeField]
        private Sprite _icon;

        public Sprite Icon { get => _icon; }
    }

    [Serializable]
    public class UIThemeColor
    {
        [SerializeField]
        private Color _color;

        public Color Color { get => _color; }
    }

    [CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/ExpandToolTheme", order = 1)]
    public class UITheme : ScriptableObject
    {
        [Header("ConsoleView")]
        [Header("Icons")]
        [SerializeField]
        private UIThemeIcon _iconLogActive = null;

        public UIThemeIcon IconLogActive { get => _iconLogActive; }

        [SerializeField]
        private UIThemeIcon _iconWarnningActive = null;

        public UIThemeIcon IconWarnningActive { get => _iconWarnningActive; }

        [SerializeField]
        private UIThemeIcon _iconErrorActive = null;

        public UIThemeIcon IconErrorActive { get => _iconErrorActive; }

        [SerializeField]
        private UIThemeIcon _iconLogInactive = null;

        public UIThemeIcon IconLogInactive { get => _iconLogInactive; }

        [SerializeField]
        private UIThemeIcon _iconWarnningInactive = null;

        public UIThemeIcon IconWarnningInactive { get => _iconWarnningInactive; }

        [SerializeField]
        private UIThemeIcon _iconErrorInactive = null;

        public UIThemeIcon IconErrorInactive { get => _iconErrorInactive; }

        public Sprite GetActiveLogIcon(LogType logType)
        {
            switch (logType)
            {
                case LogType.Log:
                    return IconLogActive.Icon;

                case LogType.Warning:
                    return IconWarnningActive.Icon;

                case LogType.Error:
                default:
                    break;
            }

            return IconErrorActive.Icon;
        }

        public Sprite GetInactiveLogIcon(LogType logType)
        {
            switch (logType)
            {
                case LogType.Log:
                    return IconLogInactive.Icon;

                case LogType.Warning:
                    return IconWarnningInactive.Icon;

                case LogType.Error:
                default:
                    break;
            }

            return IconErrorInactive.Icon;
        }

        [Header("List Item Colors")]
        [SerializeField]
        private UIThemeColor _colListItemBG1 = null;

        public UIThemeColor ColorListItemBG1 { get => _colListItemBG1; }

        [SerializeField]
        private UIThemeColor _colListItemBG2 = null;

        public UIThemeColor ColorListItemBG2 { get => _colListItemBG2; }

        [SerializeField]
        private UIThemeColor _colListItemConditionText = null;

        public UIThemeColor ColorListItemConditionText { get => _colListItemConditionText; }

        [Header("Filter Button Colors")]
        [SerializeField]
        private UIThemeColor _colLogFilterBtnActiveText = null;

        public UIThemeColor ColorLogFilterBtnActiveText { get => _colLogFilterBtnActiveText; }

        [SerializeField]
        private UIThemeColor _colLogFilterBtnInactiveText = null;

        public UIThemeColor ColorLogFilterBtnInactiveText { get => _colLogFilterBtnInactiveText; }

        [SerializeField]
        private UIThemeColor _colLogFilterBtnActiveBG = null;

        public UIThemeColor ColorLogFilterBtnActiveBG { get => _colLogFilterBtnActiveBG; }

        [SerializeField]
        private UIThemeColor _colLogFilterBtnInactiveBG = null;

        public UIThemeColor ColorLogFilterBtnInactiveBG { get => _colLogFilterBtnInactiveBG; }
    }
}