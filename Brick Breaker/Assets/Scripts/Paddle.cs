using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private float mousePosInBlocks;
	private Vector3 paddlePos;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		paddlePos = new Vector3 (0.0f, this.transform.position.y, 0.0f);

		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
