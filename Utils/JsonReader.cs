using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class JsonReader
{
    private JObject? _jsonObject;

    public JsonReader(string fileName)
    {
        LoadJson(GetJsonFilePath(fileName));
    }

    private string GetJsonFilePath(string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string jsonFilePath = Path.Combine(currentDirectory, fileName);
        return jsonFilePath;
    }

    private void LoadJson(string filePath)
    {
        using (StreamReader file = File.OpenText(filePath))
        {
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                _jsonObject = (JObject)JToken.ReadFrom(reader);
            }
        }
    }

    public string? GetValueByKey(string key)
    {
        if (_jsonObject != null)
        {
            return _jsonObject[key]?.ToString();
        }
        return null;
    }
}
