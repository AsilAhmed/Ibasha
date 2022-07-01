using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public int TotalCash;
    Text MoneyText;
    void Start()
    {
        MoneyText = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();   
    }

    // Update is called once per frame
     


    public void Coins_Counter(int Score)
    {
        TotalCash += Score;
        MoneyText.text = "Cash: " + TotalCash.ToString() + "$";
        
;    }
}
