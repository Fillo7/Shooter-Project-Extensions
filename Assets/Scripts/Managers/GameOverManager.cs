using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;   // Reference to the player's health.

    private Animator anim;              // Reference to the animator component.

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
