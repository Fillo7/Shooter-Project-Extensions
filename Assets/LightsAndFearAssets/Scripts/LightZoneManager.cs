using UnityEngine;

public class LightZoneManager : MonoBehaviour
{
    public PlayerHealthLF playerHealth;
    public GameObject lightZone;
    public float spawnTime = 15.0f;
    public Transform[] spawnPoints;

    private GameObject currentLightZone = null;
    private int spawnPointIndex = 0;

    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, spawnTime);
    }

    private void Spawn()
    {
        DespawnCurrent();

        if (playerHealth.IsDead())
        {
            return;
        }

        spawnPointIndex = RandomExcept(0, spawnPoints.Length, spawnPointIndex);
        currentLightZone = Instantiate(lightZone, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    private void DespawnCurrent()
    {
        if (currentLightZone == null)
        {
            return;
        }

        Destroy(currentLightZone);
        playerHealth.SetInLight(false);
    }

    private int RandomExcept(int min, int max, int except)
    {
        int random = Random.Range(min, max);
        if (random == except)
        {
            random = (random + 1) % max;
        }
        
        return random;
    }
}
