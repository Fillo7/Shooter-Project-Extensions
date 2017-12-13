using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;

    Animator anim;
    AudioSource doctorAudio;
    bool isSinking;
    bool dead = true;
    CapsuleCollider capsuleCollider;

    void Awake()
    {
        dead = false;
        anim = GetComponent<Animator>();
        doctorAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        if (dead)
        {
            return;
        }
            

        doctorAudio.Play();

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
			dead = true;
            Death();
        }
    }

    void Death()
    {
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");

        doctorAudio.clip = deathClip;
        doctorAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2f);
    }

    public bool docIsDead()
    {
        return dead;
    }

}
