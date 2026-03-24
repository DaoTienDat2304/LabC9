using UnityEngine;
using UnityEngine.SceneManagement;

// Lab 2 – Singleton + DontDestroyOnLoad (chỉ một instance sống qua các scene).
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameConfig gameConfig;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("[Lab2] GameManager đang sống qua scene bằng DontDestroyOnLoad.");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Game")
            return;

        // Lab 3
        HighScorePrefs.TrySave(SceneData.ScoreToCarry);
        HighScorePrefs.Get();

        // Lab 4 + Lab 6
        var data = new PlayerData
        {
            playerName = "Player1",
            level = 1,
            score = SceneData.ScoreToCarry
        };
        FileSaveJson.Save(data);
        FileSaveJson.LoadOrNew();

        // Lab 5
        if (gameConfig != null)
            gameConfig.DebugLog();
        else
            Debug.Log("[Lab5] Chưa gán GameConfig vào GameManager.");
    }
}
