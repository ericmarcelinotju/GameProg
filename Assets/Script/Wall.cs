﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Destructable {

    [SerializeField] float inSeconds;

	public override void Die()
    {
        base.Die();
        //Destroy(gameObject);
        GameManager.Instance.Respawner.Despawn(gameObject, inSeconds);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        print("Remaining: " + HitPointsRemaining);
    }
}
