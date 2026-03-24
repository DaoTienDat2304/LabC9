using UnityEngine;

// Lab 5 – Chuột phải Project → Create → Lab → GameConfig để tạo asset.
[CreateAssetMenu(fileName = "GameConfig", menuName = "Lab/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int maxLives = 3;
    public float moveSpeed = 5f;
    public int scoreToPass = 100;
    public int scorePerClick = 10;

    public void DebugLog()
    {
        Debug.Log($"[Lab5] GameConfig -> maxLives={maxLives}, moveSpeed={moveSpeed}, scoreToPass={scoreToPass}, scorePerClick={scorePerClick}");
    }
}
