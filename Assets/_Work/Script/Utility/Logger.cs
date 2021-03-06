using UnityEngine;

public static class Logger
{
    public static void Log(object obj, string comment)
    {
        if (!GlobalSettings.DEBUG_MODE)
            return;

        var log = obj?.ToString() ?? null;
        Debug.Log($"{comment}: {log}");
    }

    public static void DataLog(object obj, string comment)
    {
        if(!GlobalSettings.DEBUG_MODE)
            return;

        var log = JsonSerializer.ToJson(obj);
        Debug.Log($"{comment}: {log}");
    }
}