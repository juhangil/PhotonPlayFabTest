using PlayFab;

public static class JsonSerializer
{
    public static string ToJson(object obj)
    {
        var result = pluginInstance.SerializeObject(obj);
        return string.IsNullOrEmpty(result) ? null : result;
    }

    public static T ParseJson<T>(string json) where T : class
    {
        var result = pluginInstance.DeserializeObject<T>(json);
        return result;
    }

    private static ISerializerPlugin pluginInstance
    {
        get
        {
            serializerInstance ??= PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            return serializerInstance;
        }
    }

    private static ISerializerPlugin serializerInstance = null;
}