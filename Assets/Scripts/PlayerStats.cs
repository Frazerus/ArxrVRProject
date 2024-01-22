using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int CurrentScore { get; set; }

    private void Start()
    {
        CurrentScore = 0;
        GameEventSystem.current.OnDropItem += AddScore;
    }

    private void AddScore(int toAdd)
    {
        CurrentScore += toAdd;
    }
}