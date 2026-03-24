using UnityEngine;
using UnityEngine.SceneManagement;

// Gắn vào Canvas/Empty trên scene Menu. Nút Play gọi OnButtonPlay().
public class MenuController : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] string gameSceneName = "Game";
    [SerializeField] int scoreToPass = 100; // fallback khi chưa gán GameConfig
    [SerializeField] int scorePerClick = 10; // fallback khi chưa gán GameConfig
    [SerializeField] int currentScore;
    [SerializeField] string playerName = "Player1";

    public void OnButtonPlay()
    {
        int perClick = gameConfig != null ? gameConfig.scorePerClick : scorePerClick;
        int needToPass = gameConfig != null ? gameConfig.scoreToPass : scoreToPass;

        currentScore += perClick;
        Debug.Log($"[Menu] +{perClick} điểm. CurrentScore = {currentScore}");

        // Lab 3: mỗi lần bấm đều thử lưu HighScore.
        HighScorePrefs.TrySave(currentScore);
        HighScorePrefs.Get();

        // Lab 4/6: mỗi lần bấm đều lưu JSON ra file.
        var data = new PlayerData
        {
            playerName = playerName,
            level = 1,
            score = currentScore
        };
        FileSaveJson.Save(data);

        if (currentScore < needToPass)
        {
            Debug.Log($"[Menu] Chưa đủ {needToPass} điểm để qua màn.");
            return;
        }

        SceneData.ScoreToCarry = currentScore;
        Debug.Log($"[Lab1] Set SceneData.ScoreToCarry = {SceneData.ScoreToCarry}");
        SceneManager.LoadScene(gameSceneName);
    }
}
