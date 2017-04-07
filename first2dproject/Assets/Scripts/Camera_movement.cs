using UnityEngine;
using System.Collections;

public class Camera_movement : MonoBehaviour {


	public Transform target;
	//public Transform target2;
	//private Transform temp;
//	public GameObject playerO;
	//public GameObject playerO2;
	//private Movement_control inControl;
	public float camera_Speed = 0.01f;
	private float rotationspeed = 0.05f;
	private float rotationx, rotationy;
	private Vector3 rotation; 
	private bool done = false;
	// Use this for initialization
	void Start () {

		if (target) {
			Camera.main.transform.position = target.position;
		}

		rotation = Camera.main.transform.position;
	//inControl = playerO2.GetComponent<Movement_control> ();
		//inControl.enabled = false;

	} 
	
	// Update is called once per frame
	void Update () {

		Camera.main.orthographicSize = (Screen.height / 100f) / 2f;
		 

		if (Input.GetKey (KeyCode.C)) {

			if (done == false) {
				Camera.main.transform.position = target.position - new Vector3 (0f, 0f, 10f);
				done = true;
			}

			if (Input.GetKey (KeyCode.Keypad2)) {

				rotationy = rotationspeed * 1;
				rotation = new Vector3 (0f, rotationy, 0f);

				Camera.main.transform.position += rotation; 
			} else if (Input.GetKey (KeyCode.Keypad8)) {

				rotationy = rotationspeed * 1;
				rotation = new Vector3 (0f, rotationy, 0f);

				Camera.main.transform.position += rotation; 

			} else if (Input.GetKey (KeyCode.Keypad4)) {

				rotationx = rotationspeed * -1;
				rotation = new Vector3 (rotationx, 0f, 0f);

				Camera.main.transform.position += rotation; 


			} else if (Input.GetKey (KeyCode.Keypad6)) {

				rotationx = rotationspeed * 1;

				rotation = new Vector3 (rotationx, 0f, 0f);

				Camera.main.transform.position += rotation; 

			} 
		

			 

		}
		else if (Input.GetKeyUp (KeyCode.C))
		{
			Camera.main.transform.position = target.position - new Vector3 (0f, 0f, 10f);
		}
		else
		{		
			done = false;
			if (target) {

				Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, target.position, camera_Speed) - new Vector3(0f, 0f, 10f);
			}
		}
		//if (Input.GetKeyDown(KeyCode.Space)) {

		//	temp = target;
		//	target = target2; 
		//	target2 = temp;

		//	inControl = playerO.GetComponent<Movement_control> ();

		//	if (inControl.enabled == false) {
		//		inControl.enabled = true;
		//	} else {
		//		inControl.enabled = false;
		//	}
		//	inControl = playerO2.GetComponent<Movement_control> ();


		//	if (inControl.enabled == false) {
		//		inControl.enabled = true;
		//	} else {
		//		inControl.enabled = false;
		//	}


	//	}
	
	}
}
	
