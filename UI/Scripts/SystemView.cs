using UnityEngine;

namespace UnityExpandTool
{
    [DisallowMultipleComponent]
    public class SystemView : RootView
    {
        private bool _extraAlwaysTop = true;

        public bool ExtraAlwaysTop { get => _extraAlwaysTop; set => _extraAlwaysTop = value; }

        private void Start()
        {
            Append("Game", "Product Name", ProjectInfo.ProductName);
            Append("Game", "Identifier", ProjectInfo.Identifier);
            Append("Game", "Version", ProjectInfo.Version);
            Append("Game", "Unity Version", ProjectInfo.UnityVersion);

            Append("Device", "Device Name", DeviceInfo.DeviceName);
            Append("Device", "Device Model", DeviceInfo.DeviceModel);
            Append("Device", "Device Type", DeviceInfo.DeviceType);
            Append("Device", "Battery Status", DeviceInfo.BatteryStatus);
            Append("Device", "Battery Level", DeviceInfo.BatteryLevel);

            Append("System", "Operating System", DeviceInfo.OperatingSystem);
            Append("System", "Operating System Family", DeviceInfo.OperatingSystemFamily);
            Append("System", "System Language", DeviceInfo.SystemLanguage);
            Append("System", "System Memory Size", DeviceInfo.SystemMemorySize);
            Append("System", "Processor Type", DeviceInfo.ProcessorType);
            Append("System", "Processor Count", DeviceInfo.ProcessorCount);

            Append("Screen", "Screen Resolution", DeviceInfo.ScreenResolution);
            Append("Screen", "Screen Orientation", DeviceInfo.ScreenOrientation);
            Append("Screen", "AspectRatio", DeviceInfo.AspectRatio);
            Append("Screen", "Screen DPI", DeviceInfo.ScreenDPI);

            Append("Graphics", "Graphics Device Name", DeviceInfo.GraphicsDeviceName);
            Append("Graphics", "Graphics Device Type", DeviceInfo.GraphicsDeviceType);
            Append("Graphics", "Graphics Device Vendor", DeviceInfo.GraphicsDeviceVendor);
            Append("Graphics", "Graphics Memory Size", DeviceInfo.GraphicsMemorySize);
            Append("Graphics", "Graphics Shader Level", DeviceInfo.GraphicsShaderLevel);
            Append("Graphics", "Graphics Multi Threaded", DeviceInfo.GraphicsMultiThreaded);

            Append("Features", "Vibration", DeviceInfo.SupportsVibration);
            Append("Features", "Shadows", DeviceInfo.SupportsShadows);
            Append("Features", "Instancing", DeviceInfo.SupportsInstancing);
            Append("Features", "LocationService", DeviceInfo.SupportsLocationService);
            Append("Features", "Accelerometer", DeviceInfo.SupportsAccelerometer);
            Append("Features", "Gyroscope", DeviceInfo.SupportsGyroscope);
            Append("Features", "Audio", DeviceInfo.SupportsAudio);
        }

        public void AppendExtra(string name, string key, string value)
        {
            Append(name, key, value);

            if (_extraAlwaysTop)
                _groups[name].transform.SetSiblingIndex(0);
        }
    }
}
