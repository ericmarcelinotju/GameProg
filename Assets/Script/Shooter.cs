using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField]float fireRate;
	[SerializeField]Transform projectile;
    [SerializeField] AudioClip gunClip;

    [HideInInspector]
	public Transform muzzle;

    private Reloader reloader;

	float nextFireAllowed;
	protected bool canFire;
	
	void Awake () {
		muzzle = transform.Find("Muzzle");
        //reloader = GetComponent<Reloader>();
	}

	public virtual void Fire(){
		canFire = false;

		if(Time.time < nextFireAllowed)
			return;

        //if(reloader != null)
        //{
        //    if (reloader.IsReloading)
        //        return;
        //    if (reloader.RoundsRemainingInClip == 0)
        //        return;

        //    reloader.TakeFromClip(1);
        //}

		nextFireAllowed = Time.time + fireRate;

		Instantiate(projectile, muzzle.position, muzzle.rotation);

        if (Player.Instance.PlayerAudio.clip != gunClip)
            Player.Instance.PlayerAudio.clip = gunClip;
        Player.Instance.PlayerAudio.Play();

        canFire = true;
	}
}
