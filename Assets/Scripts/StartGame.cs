using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameState gameState;

    private Button startButton;

    private void Start()
    {
        gameState.Reset();
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(LoadPlayScene);
    }

    private void LoadPlayScene()
    {
        startButton.onClick.RemoveAllListeners();
        SceneManager.LoadScene("PlayScene");
    }
}
