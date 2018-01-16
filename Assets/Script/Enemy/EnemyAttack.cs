using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    [SerializeField] float timeBetweenAttacks = 0.5f;
    [SerializeField] int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    FlyingEnemy flyingEnemy;
    bool playerInRange;
    float timer;


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        flyingEnemy = GetComponent<FlyingEnemy>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = true;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = false;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.HitPointsRemaining > 0)
        {
            Attack();
        }
    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.HitPointsRemaining > 0)
        {
            playerHealth.TakeDamage(attackDamage, transform.position);

            if (flyingEnemy != null)
            {
                flyingEnemy.isAttacking = false;
                flyingEnemy.isRetreating = true;
            }
        }
    }
}
