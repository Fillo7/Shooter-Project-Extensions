using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject doctor;
    public Transform[] spawnPoints;
	public float spawnTime;

    void Start()
    {
		InvokeRepeating("DocSpawn", spawnTime, spawnTime);
        
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(doctor, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        
    }

	void DocSpawn()
	{
		if (GameObject.FindGameObjectWithTag("Doctor") == null)
		{
			Spawn ();
		}
	}

}
