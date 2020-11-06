using System;
using System.Management;

public static void SetBrightnessLaptop(int brightness)
{
    using var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
    {
        Scope = new ManagementScope(@"\\.\root\wmi")
    };
    using var instances = mclass.GetInstances();
    var args = new object[] { 1, brightness };
    foreach (ManagementObject instance in instances)
    {
        instance.InvokeMethod("WmiSetBrightness", args);
    }
}