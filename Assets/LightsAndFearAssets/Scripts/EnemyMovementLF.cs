using UnityEngine;

public class EnemyMovementLF : MonoBehaviour
{
    Transform player;                   // Reference to the player's position.
    PlayerHealthLF playerHealth;        // Reference to the player's health.
    EnemyHealth enemyHealth;            // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;    // Reference to the nav mesh agent.

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealthLF>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
