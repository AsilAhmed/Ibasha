using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    static public Vector3 respawn_lvl1, respawn_lvl2, respawn_lvl3;
    static public int lifecount = 3;
    static public  Text LifeCount;
    static public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        respawn_lvl1 = new Vector3(-2, -1, 0);
        respawn_lvl2 = new Vector3(18, -1, -12);
        respawn_lvl3 = new Vector3(38, -1, 0);
        LifeCount = GameObject.FindGameObjectWithTag("LifeCount").GetComponent<Text>();
    }

    // Update is called once per frame
     static public void  RespawnOnCurrLvl()
    {
        lifecount--;        // Deducting Life on each respawn

        if (lifecount == 0)
        {
            GameOver = true;

        }
        else {

            Hero_health.currhealth = 100;
            LifeCount.text = lifecount.ToString() + "up";
        }
        
    }
}
