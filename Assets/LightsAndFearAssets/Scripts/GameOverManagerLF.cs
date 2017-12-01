using UnityEngine;

public class GameOverManagerLF : MonoBehaviour
{
    public PlayerHealthLF playerHealth; // Reference to the player's health.

    private Animator anim;              // Reference to the animator component.

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0 || playerHealth.currentFear >= 40)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
