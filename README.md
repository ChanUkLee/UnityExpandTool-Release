# UnityExpandTool-Release

This is preview version.
Just test with 2020.3.1f.


## Usage

![prefab_location](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/how_to_work.png)

or

```
using UnityExpandTool;

public class UnityExpandTool_Sample : MonoBehaviour
{
    private void Open()
    {
        ExpandTool.Open();
    }
}
```

## Log

![log screenshot](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/logviewer.png)

![log_detail screenshot](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/logviewer_detail.png)

## Command

![command screenshot](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/command.png)

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

![system screenshot](https://github.com/ChanUkLee/UnityExpandTool/blob/main/Images/infos.png)

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
