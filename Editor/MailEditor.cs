using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;

namespace UnityExpandTool
{
    [CustomEditor(typeof(Mail))]
    public class MailEditor : Editor
    {
        private Mail _target = null;

        private string _senderName = string.Empty;
        private string _senderEmail = string.Empty;
        private string _password = string.Empty;
        private string _domain = string.Empty;
        private int _port = 0;

        public void OnEnable()
        {
            _target = target as Mail;

            _senderName = _target.SenderName;
            _senderEmail = _target.SenderMail;
            _password = _target.Password;
            _domain = _target.Domain;
            _port = _target.Port;
        }

        public override void OnInspectorGUI()
        {
            //EditorGUI.BeginChangeCheck();

            _senderName = EditorGUILayout.TextField("SenderName", _senderName);
            _senderEmail = EditorGUILayout.TextField("SenderEmail", _senderEmail);
            _password = EditorGUILayout.PasswordField("Password", _password);
            _domain = EditorGUILayout.TextField("Domain", _domain);
            _port = (int)EditorGUILayout.IntField("Port", _port);

            //GUI.enabled = EditorGUI.EndChangeCheck();
            GUI.enabled = IsChanged();
            if (GUILayout.Button("Apply"))
            {
                if (!IsValidyDomain(_domain))
                {
                    EditorUtility.DisplayDialog("Invalid domain", "Domain must contains smtp.", "OK");
                    return;
                }

                if (!IsValidEmail(_senderEmail))
                {
                    EditorUtility.DisplayDialog("Invalid email", "Check email address", "OK");
                    return;
                }

                _target.SenderName = _senderName;
                _target.SenderMail = _senderEmail;
                _target.Password = _password;
                _target.Domain = _domain;
                _target.Port = _port;

                EditorUtility.SetDirty(_target);
            }
        }

        /// <summary>
        /// 바뀐 값이 있는지 확
        /// </summary>
        /// <returns></returns>
        private bool IsChanged()
        {
            return _senderName != _target.SenderName
                || _senderEmail != _target.SenderMail
                || _password != _target.Password
                || _domain != _target.Domain
                || _port != _target.Port;
        }

        /// <summary>
        /// 옳바른 도메인 형식인지 확인
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        private bool IsValidyDomain(string domain)
        {
            if (domain.Contains("smtp."))
                return true;

            return false;
        }

        /// <summary>
        /// 올바른 메일 형식인지 확인
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
