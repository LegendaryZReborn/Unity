using UnityEngine;
using System.Collections;

public class CameraB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.orthographicSize = (Screen.height/ 1.5f) ;
	}
}
  