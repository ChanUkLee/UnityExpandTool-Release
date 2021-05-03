using UnityEngine;
using UnityExpandTool;

public class ExampleScene : MonoBehaviour
{
    private int _logIndex = 0;

    private void Awake()
    {
        //LoadTest();

        ExpandTool.Open();

        ExpandTool.AppendFunc("New Log", () =>
        {
            Debug.Log($"New Log #{_logIndex++}");
        });

        ExpandTool.AppendFunc("New Warn", () =>
        {
            Debug.LogWarning($"New Warn #{_logIndex++}");
        });

        ExpandTool.AppendFunc("New Error", () =>
        {
            Debug.LogError($"New Error #{_logIndex++}");
        });

        ExpandTool.AppendExtraInfo("Environment", "Server", "QA");

        ExpandTool.AppendFunc("Static Encrypt Test", () =>
        {
            var origin = "암호화 테스트 입니다";

            var encrypt = Encrypt.StaticEncode(System.Text.Encoding.UTF8.GetBytes(origin));
            var decrypt = System.Text.Encoding.Default.GetString(Encrypt.StaticDecode(encrypt));

            Debug.Log($"{origin}/{decrypt}");
        });
    }

    /// <summary>
    /// http://www.softwaretestingstuff.com/2011/09/performance-testing-vs-load-testing-vs.html
    /// </summary>
    private void LoadTest()
    {
        for (int i = 0; i < 100000; i++)
        {
            Debug.Log($"New Log #{i}");
        }
    }
}
