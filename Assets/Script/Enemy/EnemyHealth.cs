using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : Destructable
{
    [SerializeField] int scoreValue = 10;
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip deathClip;

    private bool isSinking;
    public bool IsSinking
    {
        get
        {
            return isSinking;
        }
    }
    private AudioSource enemyAudio;
    private Animator enemyAnimator;

    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        enemyAnimator = GetComponent<Animator>();
    }

    public override void Die()
    {
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        enemyAnimator.SetTrigger("DieTrigger");

        ScoreController.score += scoreValue;

        base.Die();
    }

    public override void TakeDamage(float amount)
    {
        if (enemyAudio.clip != hurtClip)
            enemyAudio.clip = hurtClip;
        enemyAudio.Play();

        base.TakeDamage(amount);
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2f);
    }
}
