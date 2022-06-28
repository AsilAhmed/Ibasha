﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hero_health : MonoBehaviour
{
    // Start is called before the first frame update
    public float currhealth;
    float maxhealth = 100f;
    Animator anim;
    Image healthbar;
    
    
    // This variable will hold the value of heart_pickup, which will be max 2 times and then we will destroy that heart object

    int health_count;            
    void Start()
    {
        currhealth = maxhealth;
        healthbar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<Image>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currhealth <1)
        {
            anim.SetTrigger("dead");
            SoundManager.PlaySound("dead");
        }

        if (collision.gameObject.tag == "spring_tag" && currhealth > 0)
        {
            currhealth -= 5;                    //spring damage is 5
            
            healthbar.fillAmount = currhealth / maxhealth;

            anim.SetTrigger("hurt");
            SoundManager.PlaySound("hurt");
        }
        else if (collision.gameObject.tag == "zombie_tag" && currhealth > 0)
        {
            currhealth -= 10;                   // zombie damage is 10 

            healthbar.fillAmount = currhealth / maxhealth;
            anim.SetTrigger("hurt");
            SoundManager.PlaySound("hurt");

        }
        else if (collision.gameObject.tag == "health_tag" && currhealth < 100)
        {
            currhealth += 5;                   // health increment 
            health_count++;
            healthbar.fillAmount = currhealth / maxhealth;
            
            SoundManager.PlaySound("Hpickup");

            if (health_count == 2)
            {
                Destroy(collision.gameObject);
                health_count = 0;
            }
            
        }
    }

}