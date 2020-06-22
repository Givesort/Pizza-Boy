using UnityEngine;
using UnityEngine.SceneManagement;

public class Pedestrian : MonoBehaviour
{
    public Animator animator;
    public float speed;

    public Vector3 direction { set; get; }

    public GameState gameState;

    private bool hasPizza;

    private void Start()
    {
        hasPizza = false;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If pedestrian reaches its goal without a pizza, then game over
        if (collision.name.Contains("Goal"))
        {
            if (hasPizza)
            {
                gameState.currentScore += 1;
            }
            else
            {
                gameState.gameOver = true;
                Invoke("GoToStartScreen", 3);
            }
        }
        else if (collision.name.Contains("Pizza") && !collision.name.Contains("Oven") && !hasPizza)
        {
            hasPizza = true;
            animator.SetTrigger("CatchPizza");
            Destroy(collision.gameObject);
        }
    }

    private void GoToStartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }
}
