using UnityEngine;

public class EnemyManagerLF : MonoBehaviour
{
    public PlayerHealthLF playerHealth;     // Reference to the player's heatlh.
    public GameObject[] enemies;            // An array of the enemy types that can be spawned.
    public float spawnTime = 3.0f;          // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points the enemies can spawn from.

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.IsDead())
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
