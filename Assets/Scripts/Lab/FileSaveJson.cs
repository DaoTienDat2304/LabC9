using System.IO;
using UnityEngine;

// Lab 6 – Ghi/đọc file JSON dưới Application.persistentDataPath.
public static class FileSaveJson
{
    const string FileName = "playerdata.json";

    static string SavePath => Path.Combine(Application.persistentDataPath, FileName);

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
    }

    public static PlayerData LoadOrNew()
    {
        if (!File.Exists(SavePath))
            return new PlayerData();

        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public static string GetSavePathForDebug()
    {
        return SavePath;
    }
}
