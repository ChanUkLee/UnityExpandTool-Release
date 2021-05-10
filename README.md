# UnityExpandTool-Release

This is preview version.
Just test with 2020.3.1f.


## Usage

Windows > UnityExpandTool > UnityExpandTool

will be create expandtool instance active scene

![prefab_location](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/windows_menu.png)

or

```
using UnityExpandTool;

public class UnityExpandTool_Sample : MonoBehaviour
{
    private void Open()
    {
        ExpandTool.Build();
    }
}
```

## Log

![log screenshot](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/logviewer.png)

![log_detail screenshot](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/logviewer_detail.png)

You can share log by email. But you need setting sender and receiver.

Setting sender

Windows > UnityExpandTool > Mail Setting

![log_detail screenshot](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/settings_mail.png)

Setting receiver

```
using UnityExpandTool;

public class UnityExpandTool_Log_Sample : MonoBehaviour
{
    private void ShareInit()
    {
        ExpandTool.TargetMail = "sample@gmail.com";
    }
}
```

## Command

![command screenshot](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/command.png)

You can use command like this.

```
using UnityExpandTool;

public class UnityExpandTool_Command_Sample : MonoBehaviour
{
    private void AppendFunc()
    {
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
    }
}
```

## System

![system screenshot](https://github.com/ChanUkLee/ReadMe-Image/blob/master/UnityExpandTool/infos.png)

You can use custom info like this.

```
using UnityExpandTool;

public class UnityExpandTool_System_Sample : MonoBehaviour
{
    private void AppendInfo()
    {
        ExpandTool.AppendExtraInfo("Environment", "Server", "QA");
    }
}
```

## Example Scene

![example_scene location](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/example.png)
