using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : Destructable
{
    [SerializeField] int scoreValue = 10;
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip deathClip;

    private ParticleSystem hitParticles;

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
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }

    public override void Die()
    {
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        if(enemyAnimator != null)
            enemyAnimator.SetTrigger("DieTrigger");

        ScoreController.score += scoreValue;

        base.Die();
    }

    public override void TakeDamage(float amount, Vector3 hitPosition)
    {
        if (isAlive)
        {
            if (enemyAudio.clip != hurtClip)
                enemyAudio.clip = hurtClip;
            enemyAudio.Play();

            hitParticles.transform.position = new Vector3(hitPosition.x, hitParticles.transform.position.y, hitPosition.z);
            hitParticles.transform.rotation = Quaternion.LookRotation(hitPosition);
            hitParticles.Play();
        }

        base.TakeDamage(amount, hitPosition);
    }

    public void StartSinking()
    {
        if(GetComponent<NavMeshAgent>() != null)
            GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2f);
    }
}
