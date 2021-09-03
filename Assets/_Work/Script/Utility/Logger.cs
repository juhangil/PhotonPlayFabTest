using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
    public static void Log(object obj, string comment)
    {
        if (!GlobalSettings.DebugMode)
            return;

        var log = obj?.ToString() ?? null;
        Debug.Log($"{comment}: {log}");
    }

    public static void DataLog(object obj, string comment)
    {
        if(!GlobalSettings.DebugMode)
            return;

        var log = JsonSerializer.ToJson(obj);
        Debug.Log($"{comment}: {log}");
    }
}