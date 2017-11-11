using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public float Vertical;
	public float Horizontal;
	public Vector2 MouseInput;
	public bool Fire1;

    public bool isMoving
    {
        get
        {
            return Vertical != 0f || Horizontal != 0f || MouseInput != Vector2.zero;
        }
    }
	
	void Update () {
		Vertical = Input.GetAxis("Vertical");
		Horizontal = Input.GetAxis("Horizontal");
		MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		Fire1 = Input.GetButton("Fire1");
	}
}
