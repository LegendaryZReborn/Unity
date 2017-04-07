using UnityEngine;
using System.Collections;

public class pickUpRotate : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {
        transform.Rotate (new Vector3 (30, 15, 45) * Time.deltaTime);
	}
}
