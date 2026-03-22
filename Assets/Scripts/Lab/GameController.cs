using UnityEngine;

// Gắn vào scene Game: in Console để thấy Lab 1–6 hoạt động.
public class GameController : MonoBehaviour
{
    [SerializeField] GameConfig config;

    void Start()
    {
        Debug.Log($"[Lab1] SceneData.ScoreToCarry = {SceneData.ScoreToCarry}");

        if (GameManager.Instance != null)
            Debug.Log("[Lab2] Có GameManager (DontDestroyOnLoad).");

        Debug.Log($"[Lab3] HighScore (trước): {HighScorePrefs.Get()}");
        HighScorePrefs.TrySave(SceneData.ScoreToCarry);
        Debug.Log($"[Lab3] HighScore (sau): {HighScorePrefs.Get()}");

        var p = new PlayerData
        {
            playerName = "Player1",
            level = 1,
            score = SceneData.ScoreToCarry
        };
        string json = JsonUtility.ToJson(p, true);
        Debug.Log($"[Lab4] JSON:\n{json}");
        JsonUtility.FromJson<PlayerData>(json);

        if (config != null)
            Debug.Log($"[Lab5] GameConfig → maxLives={config.maxLives}, moveSpeed={config.moveSpeed}");
        else
            Debug.Log("[Lab5] Chưa gán GameConfig trong Inspector.");

        FileSaveJson.Save(p);
        var loaded = FileSaveJson.LoadOrNew();
        Debug.Log($"[Lab6] Đọc file: {loaded.playerName}, score={loaded.score}");
        Debug.Log($"[Lab6] Đường dẫn: {FileSaveJson.GetSavePathForDebug()}");
    }
}
