using UnityEngine;

public class EnemyManagerLF : MonoBehaviour
{
    public PlayerHealthLF playerHealth;     // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3.0f;          // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0 || playerHealth.currentFear >= 40)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
