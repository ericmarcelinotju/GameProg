using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;
    [SerializeField] Muzzle muzzle;

    float lookHeight;

    void Update()
    {
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //screenPosition.y = Screen.height - screenPosition.y;
        //Vector3 crosshairPos = transform.position;
        //crosshairPos.y = Camera.main.ScreenToWorldPoint(screenPosition).y - lookHeight;
        //muzzle.transform.LookAt(crosshairPos);
        //Debug.Log(crosshairPos);
    }

    public void LookHeight(float value)
    {
        lookHeight += value;

        if (lookHeight > maxAngle || lookHeight < minAngle)
        {
            lookHeight -= value;
        }
        else
        {
            muzzle.transform.Rotate(Vector3.left * value);
        }
    }

    void OnGUI()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }
}
