using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator attack;

    public Transform attackPoint;
    public LayerMask enemy;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public float attackRange = 0.5f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Attack()
    {
        attack.SetTrigger("Attack");

       Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
        
        foreach(Collider2D collider in hitEnemy)
        {
            collider.GetComponent<Enemy>().TakeDamage(Random.Range(0, 5));
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
