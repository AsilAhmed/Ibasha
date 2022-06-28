﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioSource SRC;
    //static AudioClip jump,dead, healthpickup, coinpickup,hurt,run;
    static AudioClip jump,  fall, run;

    void Start()
    {
        SRC = GetComponent<AudioSource>();
        jump = Resources.Load<AudioClip>("jump");
        //healthpickup = Resources.Load<AudioClip>("health_pickup");
        //coinpickup = Resources.Load<AudioClip>("coin_pickup");
        //hurt = Resources.Load<AudioClip>("hurt");
        run = Resources.Load<AudioClip>("running on leaves");
        fall = Resources.Load<AudioClip>("falling");
        //dead = Resources.Load<AudioClip>("dead");
    }

    // Update is called once per frame
    static public void PlaySound(string clipname) 
    {
        //switch (clipname)
        //{
        //    case "jump":
        //        src.playoneshot(jump);
        //        break;

        //    case "hpickup":
        //        src.playoneshot(healthpickup);
        //        break;
        //    case "cpickup":
        //        src.playoneshot(coinpickup);
        //        break;

        //    case "hurt":
        //        src.playoneshot(hurt);
        //        break;
        //    case "run":
        //        src.playoneshot(run);
        //        break;
        //    case "dead":
        //        src.playoneshot(dead);
        //        break;
        //}

        switch (clipname)
        {
            case "jump":
                SRC.PlayOneShot(jump);
                break;

            
            case "fall":
                SRC.PlayOneShot(fall);
                break;

            
            case "run":
                SRC.PlayOneShot(run);
                break;
            
        }
    }
}