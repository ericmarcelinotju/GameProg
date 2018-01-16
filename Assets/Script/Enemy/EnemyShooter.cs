using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    [SerializeField] EnemyProjectile projectile;
    [SerializeField] float fireSpeed = 5f;

    [HideInInspector]
    public Transform muzzle;

    float timer;

	void Awake () {
        muzzle = transform.Find("Snout");
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(muzzle);
        timer += Time.deltaTime;

        if(timer >= fireSpeed)
        {
            timer = 0f;
            Instantiate(projectile.gameObject, muzzle.position, muzzle.rotation);
        }
	}
}
