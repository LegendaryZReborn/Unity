using UnityEngine;
using System.Collections;

public class Movement_control : MonoBehaviour {

	private Rigidbody2D rbody;
	private Collider2D player;
	private Animator anim;
	public GameObject Electroball;
	private GameObject cloneElectroball;
	private Vector2 permDirect;
	private Vector3 inPos;
	private float animCoolDown = 0f;
	private int aDirect = 0;
	void Start () 
	{ 
		rbody = GetComponent<Rigidbody2D>(); 
		player = GetComponent<Collider2D> ();
		permDirect = new Vector2 (0f, 0f);  



	}

	void Awake(){
		anim = GetComponent<Animator>(); 
		anim.SetFloat ("input_y", -1);
	}
	
	// Update is called once per frame    
	void Update () 
	{
		if (animCoolDown <= 0f) {
			anim.SetBool ("isAttacking", false);

			Vector2 movement = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		
			Vector2 direction = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			if (direction != Vector2.zero) {
				permDirect = new Vector2 (direction.x, direction.y);
			}

			//releases an attack on key press M
			Attack (movement, permDirect);


		} else { 
			animCoolDown -= Time.deltaTime;
		
		} 
	
	}
	  
	  
	void Attack(Vector2 movement, Vector2 direction)
	{
		if (Input.GetKeyDown (KeyCode.M)) 
		{ 

			if (anim.GetBool ("isWalking") == true) {
				anim.SetBool ("isWalking", false);
			} 


			anim.SetFloat ("input_x", permDirect.x);
			anim.SetFloat ("input_y", permDirect.y);
			anim.SetBool ("isAttacking", true);

			inPos = this.transform.position + (this.transform.right * 0.12f);

			if (anim.GetFloat  ("input_x") == 0f && anim.GetFloat ("input_y") == 0f) {
				cloneElectroball = Instantiate (Electroball,this.transform.position, Quaternion.identity) as GameObject;
				cloneElectroball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));

			}   

			else if (anim.GetFloat ("input_y") == 1f) {
				cloneElectroball = Instantiate (Electroball, this.transform.position, Quaternion.identity) as GameObject;
				cloneElectroball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
				aDirect = 1;
			} else if (anim.GetFloat ("input_y") == -1f) {
				cloneElectroball = Instantiate (Electroball, this.transform.position, Quaternion.identity) as GameObject;
				cloneElectroball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -200f));
				aDirect = -1;
			} 

			else if (anim.GetFloat ("input_x") == 1f) {
				cloneElectroball = Instantiate (Electroball, inPos, Quaternion.identity) as GameObject;
				cloneElectroball.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (200f, 0f));
				aDirect = 2;

			} else if (anim.GetFloat ("input_x") == -1f) {
				cloneElectroball = Instantiate (Electroball, this.transform.position, Quaternion.identity) as GameObject;
				cloneElectroball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 0f));
				aDirect = -2;
			} 

			Physics2D.IgnoreCollision (player, cloneElectroball.GetComponent<Collider2D> ());
			animCoolDown = 0.5f; 
			Destroy (cloneElectroball.gameObject, 1.05f); 



		}
		else 
		{
			if (movement != Vector2.zero) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", movement.x);
				anim.SetFloat ("input_y", movement.y);

				rbody.MovePosition (rbody.position + (movement * Time.deltaTime * 2)); 
			} else {
				anim.SetBool ("isWalking", false);

			}

		}

	}


	public int attackTravelDirect()
	{
		//1s are for up/down; 2s are for left/right
		//a negative value means its going down or left
		return aDirect;
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") 
		{
			collision.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		}

	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") 
		{
			collision.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
		 
	}
		
} 
        