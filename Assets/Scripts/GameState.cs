using UnityEngine;

[CreateAssetMenu(fileName = "GameState")]
public class GameState : ScriptableObject
{

    private int score;
    
    public int highScore { get; set; }
    public int currentScore
    {
        get { return score;  }
        set
        {
            score = value;
            if (score > highScore)
            {
                PlayerPrefs.SetInt("highScore", score);
                highScore = score;
            }
        }
    }
    public int pizzaCount { get; set; }

    public bool gameOver;

    private void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        currentScore = 0;
        pizzaCount = 0;
        gameOver = false;
    }

    public void Reset()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        currentScore = 0;
        pizzaCount = 0;
        gameOver = false;
    }
}
