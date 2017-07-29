using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private static bool isInitialBall;
	private SoundPlayer sound;
	private const float constantSpeed = 8f;
	private Rigidbody2D rb; 

	private bool hasStarted;

	private Vector2 inDirection;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		sound = GameObject.Find("SoundPlayer").GetComponent<SoundPlayer>();
		GameObject[]  g = GameObject.FindGameObjectsWithTag("Ball");

		if(g.Length > 1)
		{
			isInitialBall = false;	// True for if its the ball at launch
			hasStarted = true;
		}
		else
		{
			isInitialBall = true;
			hasStarted = false;
		}

		rb = GetComponent<Rigidbody2D>();

	}
	 
	// Update is called once per frame
	void Update () {

		if(rb.velocity == Vector2.zero && hasStarted)
			rb.velocity = new Vector2 (2f, 10f);

		inDirection = rb.velocity;
	
		if (!hasStarted && isInitialBall) {
			//lock ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				isInitialBall = false;
				rb.velocity = new Vector2 (2f, 10f);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 inNormal = collision.contacts[0].normal;;
		if(collision.gameObject.name != "Paddle")
		{
			inNormal = collision.contacts[0].normal;
			Vector2 newDirection = Vector2.Reflect(inDirection, inNormal);
			rb.velocity = newDirection.normalized * constantSpeed;
		}
		else
		{
			//Turn contact point between the ball and the paddle into local cordinates
			//Use the contact point to determint the angle the normal should be rotated
			//left or right and by how much up to a specified angle
			Vector2 point = collision.gameObject.transform.InverseTransformPoint(collision.contacts[0].point);
			float paddleLen = collision.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2;
			float angleLeft = Mathf.Lerp(0, 70, Mathf.Abs(point.x)/paddleLen);
			float angleRight = Mathf.Lerp(0, -70, Mathf.Abs(point.x)/paddleLen);
			Quaternion r;

			if(point.x >= 0)
			{
				r = Quaternion.Euler(0, 0, angleRight);
			}
			else
			{
				r = Quaternion.Euler(0, 0, angleLeft);
			}



			//Use Quaternion to rotate normal about z axis by degrees based 
			//on contact point on paddle
			//Make sure not to rotate the normal if the ball hits the very edges of the paddle
			if(Mathf.Abs(point.x) < paddleLen)
				inNormal = r * inNormal ;

			//Bounce the ball off of the paddle using the normal
			rb.velocity = inNormal.normalized * constantSpeed;

		}
			
	}
		
	void OnCollisionExit2D(Collision2D collision)
	{
		if(hasStarted)
			sound.playBounce();
	}
		
}
