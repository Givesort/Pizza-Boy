using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOven : MonoBehaviour
{
    public GameState gameState;
    public Animator animator;

    public float cooldown;
    
    private float timer;
    private bool pizzaReady;

    private void Update()
    {
        if (!pizzaReady)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                pizzaReady = true;
                animator.SetBool("PizzaReady", pizzaReady);
            }
        }
    }

    private void OnMouseDown()
    {
        if (pizzaReady)
        {
            gameState.pizzaCount += 1;
            pizzaReady = false;
            animator.SetBool("PizzaReady", pizzaReady);
        }
    }
}
