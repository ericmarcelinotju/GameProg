using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour {

    [SerializeField] float time = 10f;

	void Start () {
        transform.rotation = Quaternion.Euler(time, 60.0f, 0.0f);
    }
}
