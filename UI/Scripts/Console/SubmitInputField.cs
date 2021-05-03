using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UnityExpandTool
{
    public class SubmitInputField : InputField
    {
        [Serializable]
        public class KeyboardDoneEvent : UnityEvent { }

        [SerializeField]
        private KeyboardDoneEvent m_keyboardDone = new KeyboardDoneEvent();

        public KeyboardDoneEvent onKeyboardDone
        {
            get { return m_keyboardDone; }
            set { m_keyboardDone = value; }
        }

        protected override void Start()
        {
            base.Start();

            
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            onEndEdit.AddListener(OnSubmit);
        }

        protected override void OnDisable()
        {
            onEndEdit.RemoveListener(OnSubmit);

            base.OnDisable();
        }

        void OnSubmit(string text)
        {
            m_keyboardDone.Invoke();

            /*
            if (Application.isMobilePlatform)
            {
                if (m_Keyboard != null && m_Keyboard.status == TouchScreenKeyboard.Status.Done)
                {
                    m_keyboardDone.Invoke();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    
                    m_keyboardDone.Invoke();
                }
            }
            */
        }
    }
}