using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

    List<GameObject> nodes;
    GameObject currPivot;

    int currIndex = 0;

	void Start () {
        nodes = new List<GameObject>();
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; //will return an array of all GameObjects in the scene
        foreach (GameObject go in gos)
        {
            if (go.layer == 12)
            {
                nodes.Add(go);
            }
        }

        currPivot = nodes[currIndex];
    }
	
	
	void Update () {
        if (transform.position == currPivot.transform.position) {
            if (currIndex >= nodes.Count)
                currIndex = 0;
            else
                currIndex++;
            currPivot = nodes[currIndex];
        }
        transform.position = Vector3.Slerp(transform.position, currPivot.transform.position , 2f * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, currPivot.transform.rotation, 2f * Time.deltaTime);
	}
}
