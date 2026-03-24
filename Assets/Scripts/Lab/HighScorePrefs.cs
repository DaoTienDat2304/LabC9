using UnityEngine;

// Lab 3 – PlayerPrefs lưu HighScore.
public static class HighScorePrefs
{
    const string Key = "HighScore";

    public static int Get()
    {
        int value = PlayerPrefs.GetInt(Key, 0);
        Debug.Log($"[Lab3] Get HighScore = {value}");
        return value;
    }

    public static void TrySave(int score)
    {
        int current = PlayerPrefs.GetInt(Key, 0);
        if (score > current)
        {
            PlayerPrefs.SetInt(Key, score);
            PlayerPrefs.Save();
            Debug.Log($"[Lab3] Save HighScore: {current} -> {score}");
        }
        else
        {
            Debug.Log($"[Lab3] Keep HighScore: {current} (new score={score})");
        }
    }
}
