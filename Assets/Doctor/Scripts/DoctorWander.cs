using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorWander : MonoBehaviour {

	public int newTarget;
	public float timer;
	public float speed;
	public NavMeshAgent nav;
	public Vector3 target;
	DoctorHealth docHealth;

	void Awake()
	{
		nav = gameObject.GetComponent<NavMeshAgent> ();
		NewTarget ();
		docHealth = GetComponent<DoctorHealth>();

	}

	void Update()
	{
		timer += Time.deltaTime;
		nav.speed = speed;

		if (timer >= newTarget && (docHealth.docIsDead() == false))
		{
			NewTarget ();
			timer = 0;
		}

		if (gameObject.transform.position.x - target.x <= 1f && gameObject.transform.position.y - target.y <= 1f)
		{
			NewTarget ();
			timer = 0;
		}
	}

	void NewTarget()
	{
		float xPos = Random.Range (-30, 30);
		float zPos = Random.Range (-30, 30);
		target = new Vector3 (xPos, gameObject.transform.position.y, zPos);

		nav.SetDestination (target);
	}
}
