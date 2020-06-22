using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameState gameState;

    public TextMeshProUGUI pizzaCountText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    // Update is called once per frame

    private void Start()
    {
        gameOverText.enabled = false;
    }
    private void Update()
    {
        pizzaCountText.text = "Pizza Count: " + gameState.pizzaCount.ToString();
        scoreText.text = "Score: " + gameState.currentScore.ToString();
        
        if (gameState.gameOver)
        {
            gameOverText.enabled = true;
        }
        else
        {
            gameOverText.enabled = false;
        }
    }
}
