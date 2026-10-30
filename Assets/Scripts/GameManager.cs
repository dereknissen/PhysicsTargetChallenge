using UnityEngine;
using TMPro;

public enum GameState
{
    Playing,
    Won,
    Lost
}

public class GameManager : MonoBehaviour
{

    public GameState currentState = GameState.Playing;
    public TMP_Text scoreText;
    public static GameManager Instance;
    public int score = 0;
    public int targetScore = 3;
    void Awake()
    {
        Instance = this;
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
        Debug.Log("Score: " + score);
        if (score >= targetScore)
        {
            currentState = GameState.Won;
            Debug.Log("You Win!");
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public int ammo = 10;
    public bool CanShoot()
    {
        return currentState ==
        GameState.Playing && ammo > 0;
    }
    public void UseAmmo()
    {
        ammo--;
        if (ammo == 0 && score < targetScore)
        {
            currentState = GameState.Lost;
            Debug.Log("Game Over!");
        }
    }


}