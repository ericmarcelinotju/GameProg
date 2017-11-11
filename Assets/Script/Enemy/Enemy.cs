using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    private Player player;
    private NavMeshAgent nav;
    private EnemyHealth enemyHealth;
    private Animator enemyAnimator;

	void Start () {
        player = Player.Instance;
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAnimator = GetComponent<Animator>();

    }
	
	void Update () {
        if (enemyHealth.IsSinking)
        {
            transform.Translate(-Vector3.up * 2.5f * Time.deltaTime);
        }
        if (enemyHealth.HitPointsRemaining > 0 && player.PlayerHealth.HitPointsRemaining > 0)
        {
            nav.SetDestination(player.transform.position);
        }
        else
        {
            nav.enabled = false;
            enemyAnimator.SetTrigger("PlayerDieTrigger");
        }
    }
}
