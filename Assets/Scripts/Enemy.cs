using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;
    private bool isAlive = true;
    private int damage = 1;

    private float timeBtwAttack;
    private float startTimeBtwAttack = 1f;
    private float lastAttackTime;

    public Animator anim;
    private Health player;

    private void Awake()
    {
        currentHP = maxHP;
        isAlive = true;

        anim = GetComponent<Animator>();
        player = GetComponent<Health>(); 
    }

    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        timeBtwAttack = startTimeBtwAttack;

        anim.SetTrigger("Hit");
        CheckIsAlive();

    }

    private void CheckIsAlive()
    {
        if (currentHP <= 0) 
        {
            isAlive = false;
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Health>();
            if (player != null)
            {
                if (timeBtwAttack <= 0)
                {
                    anim.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timeBtwAttack <= 0)
        {
            anim.SetTrigger("Attack");
            lastAttackTime = Time.time;
            timeBtwAttack = startTimeBtwAttack;
        }
    }

    private void Die()
    {
        anim.SetBool("Dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    public void OnEnemyAttack()
    {
        if (player != null)
        {
            player.takeDamage(damage);
        }
    }
}
