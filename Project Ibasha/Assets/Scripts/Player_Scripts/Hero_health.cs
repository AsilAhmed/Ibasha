﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hero_health : MonoBehaviour
{
    // Start is called before the first frame update
    static public float currhealth;
    float maxhealth = 100f;
    static public Animator Playeranim;
    Image healthbar;
    
    
    
    // This variable will hold the value of heart_pickup, which will be max 2 times and then we will destroy that heart object

    int health_count;            
    void Start()
    {
        currhealth = maxhealth;
        healthbar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<Image>();
        Playeranim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Obstacle" && currhealth > 0)
        {
            currhealth -= 5;                    //spring damage is 5
            
            healthbar.fillAmount = currhealth / maxhealth;

            Playeranim.SetTrigger("isHurt");
            SoundManager.PlaySound("hurt");
        }
        else if (collision.gameObject.tag == "Health_Tag" && currhealth < 100)
        {
            currhealth += 5;                   // health increment 
            health_count++;
            healthbar.fillAmount = currhealth / maxhealth;

            SoundManager.PlaySound("HPickup");

            if (health_count == 2)
            {
                Destroy(collision.gameObject);
                health_count = 0;
            }

        }
    }

}
