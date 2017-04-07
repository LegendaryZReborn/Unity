using UnityEngine;
using System.Collections;

public class EAttack : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D elecBall;
	private GameObject temp;
	private Rigidbody2D elecBallCopy;
	private Animator animn;
	private float dis = 0f;
	private float animTimer = 0.3f, atked = 0; 
	private Vector2 insPosition;
	private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
		animn = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody2D> (); 
	

		if(player)
		{
			dis = Vector2.Distance (player.gameObject.transform.position, rbody.position);
		}
			
	}
	
	// Update is called once per frame
	void Update () { 
		
	
		if(player) 
		{
			dis = Vector2.Distance (player.gameObject.transform.position, rbody.position);
		}


		if (dis <= 1.05f && animn.GetBool ("isWalking") == false) { 
			animn.SetBool ("isAttacking", true);


			if (atked == 1) {
				if (animn.GetFloat ("input_y") == 1) {
					insPosition = rbody.position + new Vector2 (0f, 0.25f);     
				} else if (animn.GetFloat ("input_y") == -1) {
					insPosition = rbody.position + new Vector2 (0f, -0.25f);     
				} else if (animn.GetFloat ("input_x") == 1) {
					insPosition = rbody.position + new Vector2 (0.25f, 0f); 
				} else if (animn.GetFloat ("input_x") == -1) {
					insPosition = rbody.position + new Vector2 (-0.25f, 0f);    
				}
				//Create electro ball
				temp = (GameObject)Instantiate (elecBall.gameObject, insPosition, Quaternion.identity);  
				elecBallCopy = temp.gameObject.GetComponent<Rigidbody2D> ();
			 
				//Physics2D.IgnoreCollision(GetComponent<Collider2D>(), temp.GetComponent<Collider2D>());

				//Launch Ball


				if (animn.GetFloat ("input_y") == 1) {
					elecBallCopy.velocity = new Vector2 (0f, 2f);
				} else if (animn.GetFloat ("input_y") == -1) { 
					elecBallCopy.velocity = new Vector2 (0f, -2f);
				} else if (animn.GetFloat ("input_x") == 1) {
					elecBallCopy.velocity = new Vector2 (2f, 0f);
				} else if (animn.GetFloat ("input_x") == -1) {
					elecBallCopy.velocity = new Vector2 (-2f, 0f);   
				} 

				if (temp) {
					Destroy (temp, 1);
				}
				atked = 0;
			}
		

			if (animTimer >= 0f) {   
				animTimer -= Time.deltaTime;     
			} 
			else 
			{
				animn.SetBool ("isAttacking", false);
				animTimer = 0.3f;
				atked = 1;
			}

		}
		else 
		{
			animn.SetBool ("isAttacking", false); 
		}
	}

	void FixedUpdate()
	{
		Physics2D.IgnoreLayerCollision(10, 11);
	}


}
