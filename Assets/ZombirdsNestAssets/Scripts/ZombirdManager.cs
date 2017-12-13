using UnityEngine;

public class ZombirdManager : MonoBehaviour
{
    public PlayerHealth playerHealth;      		 // Reference to the player's heatlh.
    public GameObject enemy;               		 // The enemy prefab to be spawned.
    public float spawnTime = 3.0f;         		 // How long between each spawn.
    public Transform[] spawnPoints;         	 // An array of the spawn points this enemy can spawn from.
	//public bool isSpawned = false;          	 // Is a zombird spawned? If it is, we won't spawn another one.
	public string enemyName = "zombird1";	 	 // Name of the enemy that will be spawned. Use different for each spawnpoint if you want them each to spawn an enemy, and use the same when you want only one enemy to be spawned for all of them. 
	public GameObject[] waypoints;				 // Waypoints assigned to the spawned enemy;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }
		if (GameObject.Find(enemyName) != null)
		{
			return;
		}

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        var spawnedEnemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		spawnedEnemy.name = enemyName;
		ZombirdFlight script = spawnedEnemy.gameObject.GetComponent<ZombirdFlight>();
		script.waypoints = this.waypoints;
    }
}
