using HydroTrack.Models;
using System.Text.Json;

public static class TelemetryIO
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static void WriteToFile(string filePath, TelemetryData data)
    {
        var json = JsonSerializer.Serialize(data, _options);

        using var writer = new StreamWriter(filePath, false); 
        writer.Write(json);
    }


    public static TelemetryData? ReadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            return null;

        using var reader = new StreamReader(filePath);
        string json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<TelemetryData>(json, _options);
    }

}
