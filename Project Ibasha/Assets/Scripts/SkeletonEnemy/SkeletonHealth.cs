using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour
{

    static Animator Skeletonanim;
    static  public float currhealth;
    float maxhealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxhealth;
        Skeletonanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currhealth < 5)
        {
            Skeletonanim.SetTrigger("IsDead");
            StartCoroutine(SkeletonDie(2));
            
        }
    }

     static public void TakeDamage(int damage) {
        
        currhealth -= damage;
    }

    IEnumerator SkeletonDie(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }


}
