using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	[SerializeField] Shooter shooter;

    public void Shoot (bool isFiring) {
		if(isFiring){
            shooter.Fire();
		}
	}
}
