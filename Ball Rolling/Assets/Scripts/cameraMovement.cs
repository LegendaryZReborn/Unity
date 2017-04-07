using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    public GameObject ball;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - ball.transform.position;
	}
	
	// LateUpdate is called once per frame after it runs through all the code within
	void LateUpdate () {
        transform.position = ball.transform.position + offset; 
	}
}
