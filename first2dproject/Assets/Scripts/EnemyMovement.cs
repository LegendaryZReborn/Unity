using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D rbody;
	private Rigidbody2D player;
	private Animator anim;
	private float faceUpDown = 0f, faceLeftRight = 0f;
	private float distanceFromYD, distanceFromXL, distanceFromYU, distanceFromXR, distanceFromP;
	private Vector2 iPU, iPD, iPR, iPL;
	private bool collided = false, stop = false, walking = false, hit = false;
	private GameObject eDomain;
	private EnemyTriggerZone zoneScript;
	private Hurt hurtE;

	void Start () 
	{ 
		rbody = GetComponent<Rigidbody2D>();  
		player = GameObject.Find ("Player").GetComponent<Rigidbody2D>();
		eDomain = GameObject.Find ("EDomain");
		zoneScript = eDomain.GetComponent<EnemyTriggerZone> ();
		hurtE = GetComponent<Hurt> ();
		updateDistances ();  



	} 

	void Awake()
	{
		anim = GetComponent<Animator>(); 

		anim.SetFloat ("input_x", 0f);
		anim.SetFloat ("input_y", -1f);


	}
	 
	// Update is called once per frame
	void Update ()  
	{
		collisionWatcher ();

		hit = hurtE.Hit ();
		if (collided && !hit) {
			
			findPlayer (); 
			updateDistances ();
			stopToAttack ();

		} 
		else
		{
			anim.SetBool ("isWalking", false);
		}

		  
	}
	 
	void FixedUpdate()
	{
		hit = hurtE.Hit ();
		if (collided && !hit) 
		{
			moveToPlayer (); 
		} 
	
	} 
	 
	 


	public void  findPlayer()
	{ 


		if (rbody.position.y < player.position.y)
		{
			
			 faceUpDown = 1f; 
		}
		else 
		{
			faceUpDown = -1f;
		}

		if (rbody.position.x < player.position.x)
		{
			faceLeftRight = 1f;

		}
		else
		{
			faceLeftRight = -1f; 

		}

	
	}

	void updateDistances()
	{

		iPU = player.position + new Vector2 (0f, -1f);
		iPR = player.position + new Vector2 (-1f, 0f);
		iPD = player.position + new Vector2 (0f, 1f);
		iPL = player.position + new Vector2 (1f, 0f);

		Debug.Log(Vector2.Distance(iPU, player.position));
		distanceFromYD = Vector2.Distance (rbody.position, iPU);
		distanceFromXL = Vector2.Distance (rbody.position, iPR);
		distanceFromYU = Vector2.Distance (rbody.position, iPD);
		distanceFromXR = Vector2.Distance (rbody.position, iPL);
		distanceFromP = Vector2.Distance (rbody.position, player.position);

	}
	 
	public void moveToPlayer()
	{
		if (!stop) {
			if (faceUpDown == 1 && faceLeftRight == 1) {
				if (distanceFromYD <= distanceFromXL) {

					anim.SetFloat ("input_x", 0f);
					anim.SetFloat ("input_y", faceUpDown);
					anim.SetBool ("isWalking", true);
					rbody.MovePosition (Vector2.MoveTowards(rbody.position, iPU, 0.02f));

				} else {

					Debug.Log ("RIGHT HERE");
					rbody.MovePosition (Vector2.MoveTowards(rbody.position, iPR, 0.02f));
					anim.SetFloat ("input_x", faceLeftRight);
					anim.SetFloat ("input_y", 0f);
					anim.SetBool ("isWalking", true);
				}
			}
			else if (faceUpDown == 1 && faceLeftRight == -1)
			{
				if (distanceFromYD <= distanceFromXR) {

					anim.SetFloat ("input_x", 0f);
					anim.SetFloat ("input_y", faceUpDown);
					anim.SetBool ("isWalking", true);
					rbody.MovePosition (Vector2.MoveTowards(rbody.position, iPU, 0.02f));

				} else {
					rbody.MovePosition (Vector2.MoveTowards(rbody.position,iPL, 0.02f));
					anim.SetFloat ("input_x", faceLeftRight);
					anim.SetFloat ("input_y", 0f);
					anim.SetBool ("isWalking", true);
				}
			}
			else if (faceUpDown == -1 && faceLeftRight == 1)
			{
				if (distanceFromYU <= distanceFromXL) {

					anim.SetFloat ("input_x", 0f);
					anim.SetFloat ("input_y", faceUpDown);
					anim.SetBool ("isWalking", true);
					rbody.MovePosition(Vector2.MoveTowards(rbody.position,iPD, 0.02f));

				} else {
					rbody.MovePosition (Vector2.MoveTowards(rbody.position,iPR, 0.02f));
					anim.SetFloat ("input_x", faceLeftRight);
					anim.SetFloat ("input_y", 0f);
					anim.SetBool ("isWalking", true);
				}
			}
			else if (faceUpDown == -1 && faceLeftRight == -1)
			{
				if (distanceFromYU <= distanceFromXR) {

					anim.SetFloat ("input_x", 0f);
					anim.SetFloat ("input_y", faceUpDown);
					anim.SetBool ("isWalking", true);
					rbody.MovePosition (Vector2.MoveTowards(rbody.position, iPD, 0.02f));

				} else {
					rbody.MovePosition (Vector2.MoveTowards(rbody.position, iPL, 0.02f));
					anim.SetFloat ("input_x", faceLeftRight);
					anim.SetFloat ("input_y", 0f);
					anim.SetBool ("isWalking", true);
				}
			}
		}
	}

	void stopToAttack()
	{
		if (distanceFromYD <= 0.05f || distanceFromYU <= 0.05f || distanceFromXL <= 0.05f || distanceFromXR <= 0.05f) {
			stop = true;
			anim.SetBool ("isWalking", false);


		}
		else
		{
			stop = false;  
		}

	}


	//is there anything in the enemy zone? If so ,walk.
	void collisionWatcher()
	{
		collided = zoneScript.collidedReturn ();
		walking = zoneScript.walkingReturn ();

	}
		
	void OnTriggerStay2D(Collider2D collider) 
	{
		if (collider.gameObject.transform.parent.tag == "Railgun")
		{
			
			GetComponent<SpriteRenderer> ().color = new Color (0.82f, 0.34f, 0.34f, 1f);
		  
		}
	} 

	void OnTriggerExit2D(Collider2D collider) 
	{

		if (collider.gameObject.transform.parent.tag == "Railgun")
		{

			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);

		}
	}  

	 
}
  