using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorHeal : MonoBehaviour {

    public float timeBetweenHeals = 0.5f;
    public int heals = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    DoctorHealth docHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        docHealth = GetComponent<DoctorHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenHeals && playerInRange && docHealth.currentHealth > 0)
        {
            Heal();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Heal()
    {
        timer = 0f;
        if (playerHealth.currentHealth != 0)
        {
            playerHealth.Heal(heals);
        }
        
    }
}
