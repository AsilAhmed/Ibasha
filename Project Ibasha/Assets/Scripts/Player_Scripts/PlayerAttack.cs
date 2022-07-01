using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    public Transform AttackPoint;
    public float AttackRange = .2f;
    public LayerMask EnemyLayer; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.PlaySound("PlayerAttack");
            SimpleAttack();
        }
    }

    void SimpleAttack()
    {
        anim.SetTrigger("SimpleAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);

        foreach (Collider2D Enemy in hitEnemies)
        {
            SkeletonHealth.TakeDamage(40);
        }

    
    }


    // This Function is used to Draw on screen the Sphere on Attack point
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;


        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange); 
    }
}
