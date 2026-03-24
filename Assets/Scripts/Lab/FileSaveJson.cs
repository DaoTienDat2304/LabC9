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
        Debug.Log($"[Lab4] ToJson:\n{json}");
        File.WriteAllText(SavePath, json);
        Debug.Log($"[Lab6] Saved file at: {SavePath}");
    }

    public static PlayerData LoadOrNew()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log($"[Lab6] File not found, create new data: {SavePath}");
            return new PlayerData();
        }

        string json = File.ReadAllText(SavePath);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log($"[Lab4] FromJson -> name={data.playerName}, level={data.level}, score={data.score}");
        Debug.Log($"[Lab6] Loaded file at: {SavePath}");
        return data;
    }

    public static string GetSavePathForDebug()
    {
        return SavePath;
    }
}
