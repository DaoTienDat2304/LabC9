using UnityEngine;

// Lab 3 – PlayerPrefs lưu HighScore.
public static class HighScorePrefs
{
    const string Key = "HighScore";

    public static int Get()
    {
        return PlayerPrefs.GetInt(Key, 0);
    }

    public static void TrySave(int score)
    {
        if (score > Get())
        {
            PlayerPrefs.SetInt(Key, score);
            PlayerPrefs.Save();
        }
    }
}
