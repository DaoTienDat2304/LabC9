using UnityEngine;

// Lab 5 – Chuột phải Project → Create → Lab → GameConfig để tạo asset.
[CreateAssetMenu(fileName = "GameConfig", menuName = "Lab/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int maxLives = 3;
    public float moveSpeed = 5f;
}
