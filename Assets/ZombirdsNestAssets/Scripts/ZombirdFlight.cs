using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombirdFlight : MonoBehaviour {

	public GameObject[] waypoints;
	int num = 0;

	public float minDist; 
	public float speed;
	public int explosionDamage;
	public float explosionRadius;

	Vector3 kamikazeTarget;
	public float kamikazeAcceleration;
	bool kamikazeModeOn = false;

	GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider other)
	{
		if (!kamikazeModeOn)
		{
			if (other.gameObject == player)
			{
				kamikazeTarget = other.gameObject.transform.position;
				kamikazeModeOn = true;
			}
		}
	 }

	// Update is called once per frame
	void Update () {

		if (kamikazeModeOn)
		{
			float dist = Vector3.Distance(gameObject.transform.position, kamikazeTarget);

			if (dist > minDist) 
			{
				speed = speed * kamikazeAcceleration;
				Move(kamikazeTarget); 
			} 
			else 
			{
				Explode();
			}
		}
		else
		{

			float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);

			if (dist <= minDist) 
			{ 
				if (num + 1 == waypoints.Length) 
				{ 
					num = 0; 
				} else 
				{ 
					num++; 
				} 
                
			} 
            Move(waypoints[num].transform.position); 

		}
	}


	public void Move(Vector3 target) 
	{ 
		gameObject.transform.LookAt(target); 
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime; 
	}

	public void Explode()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies)
		{
			float dist = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
			if (dist < explosionRadius)
			{
				EnemyHealth enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
				enemyHealth.TakeDamage(explosionDamage, enemy.transform.position);
			}
		}

		float playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);
		if (playerDist < explosionRadius)
			{
				PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();
				playerHealth.TakeDamage(explosionDamage);
			}
        Destroy(gameObject);
	}

}


