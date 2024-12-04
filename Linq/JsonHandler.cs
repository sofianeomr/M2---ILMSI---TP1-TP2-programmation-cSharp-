using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class JsonHandler
{
    public static void ExportToJson(List<ArticleTypé> articles, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(articles, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }

    public static List<ArticleTypé> ImportFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<ArticleTypé>>(jsonString);
    }
}
