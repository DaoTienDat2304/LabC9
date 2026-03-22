using UnityEngine;
using UnityEngine.SceneManagement;

// Gắn vào Canvas/Empty trên scene Menu. Nút Play gọi OnButtonPlay().
public class MenuController : MonoBehaviour
{
    [SerializeField] string gameSceneName = "Game";
    [SerializeField] int scoreToPass = 100;

    public void OnButtonPlay()
    {
        SceneData.ScoreToCarry = scoreToPass;
        SceneManager.LoadScene(gameSceneName);
    }
}
