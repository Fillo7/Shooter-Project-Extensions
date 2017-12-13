using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	public AudioClip explosionClip;  
	AudioSource audioSource; 
	// Use this for initialization
	void Awake () {

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = explosionClip;
		audioSource.Play();
		Destroy(gameObject, explosionClip.length);
		        
	}
	
}
