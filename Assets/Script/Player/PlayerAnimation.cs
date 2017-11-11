using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;

	void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        animator.SetBool("IsWalking", GameManager.Instance.InputController.isMoving);
        if (!Player.Instance.PlayerHealth.isAlive)
            animator.SetTrigger("Die");
    }
}
