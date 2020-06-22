using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUIController : MonoBehaviour
{
    public GameState gameState;
    public TextMeshProUGUI highScoreText;

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + gameState.highScore.ToString();
    }
}
