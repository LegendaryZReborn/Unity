using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230
public class ThirdPersonFollow : MonoBehaviour {

	public Transform target;
	public float damping;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		Vector3 desiredPosition = target.transform.position - (rotation * offset);
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
		this.transform.position = position;

		transform.LookAt(target.transform);
	}
}
