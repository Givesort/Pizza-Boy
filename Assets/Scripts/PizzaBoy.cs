using UnityEngine;

public class PizzaBoy : MonoBehaviour
{

    public Camera cam;
    public Transform tossPoint;
    public GameObject pizzaPrefab;
    public GameState gameState;

    public float tossForce;

    private Vector2 worldPos;

    private void Update()
    {
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && worldPos.y < -1.5 && gameState.pizzaCount > 0)
        {
            Toss();
        }
    }

    private void Toss()
    {
        gameState.pizzaCount -= 1;
        var pizza = Instantiate(pizzaPrefab, tossPoint);
        var rb = pizza.GetComponent<Rigidbody2D>();

        var tossDirection = worldPos - new Vector2(tossPoint.position.x, tossPoint.position.y);
        rb.AddForce(tossDirection.normalized * tossForce, ForceMode2D.Impulse);
    }
}
