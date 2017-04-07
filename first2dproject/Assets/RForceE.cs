using UnityEngine;
using System.Collections;

public class RForceE : MonoBehaviour {

	private bool addforce = false;
	private GameObject wielder;
	private Animator anim;
	private GameObject end;
	private Vector3 locale;
	private float f, dY, dX, axis = 1f;
	private Collision2D coll;
	private GameObject temp = null, eTemp = null, fTemp;
	private GameObject railgun;

	// Use this for initialization
	void Start () { 
		wielder = GameObject.Find ("Player");
		anim = wielder.GetComponent<Animator> ();
		railgun = GameObject.Find ("Railgun");
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R))
		{
			dY = anim.GetFloat ("input_y");
			dX = anim.GetFloat ("input_x");

			if ((dY == 1f && dX == 0f) || (dY == -1f && dX == 0f)) {
				axis = 1f;
			}
			else if ((dY == 0f && dX == 1f) || (dY == 0f && dX == -1f))
			{
				axis = 0f;
			}


		}

	/*	if (end != null)
		{		
			//needs to move with beam
			f = GetComponent<Renderer>().bounds.size.x + 0.1f;
			end.transform.localPosition = new Vector3(transform.localPosition.x + f, transform.localPosition.y, transform.localPosition.z) ;
		}*/
	}


	void FixedUpdate()
	{
		if (addforce) {
			
				if(dX == 1f){
				this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50f, 0f), ForceMode2D.Force);
				}
				else if(dX == -1f){
				this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-50f, 0f), ForceMode2D.Force);
				}
				else if(dY == 1f){
					this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 50f), ForceMode2D.Force);
				}
				else if(dY == -1f){
					this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -50f), ForceMode2D.Force);
				}


		
				if (axis == 1f) {
					
					//lock to beams x axis
				this.GetComponent<Rigidbody2D> ().MovePosition (new Vector2 (railgun.transform.position.x, this.GetComponent<Transform> ().position.y));
				} else { 

					//lock to beams y axis
				this.GetComponent<Rigidbody2D> ().MovePosition (new Vector2 (this.GetComponent<Transform> ().position.x, railgun.transform.position.y));
				}

			}


	}

	/*void OnCollisionStay2D(Collision2D collider) 
	{    
		
		if (end == null) { 
			end = Instantiate (rscript.laserEnd) as GameObject;
			end.transform.parent = transform.parent; 
			locale = transform.parent.InverseTransformPoint (collider.transform.position);
			end.transform.localPosition = new Vector3(locale.x, transform.localPosition.y, transform.localPosition.z) ;
		
		} 

	} 

	void OnCollisionExit2D(Collision2D collider) 
	{
		
		if (end != null) 
		{
			Debug.Log ("Destroyed");
			Destroy (end);
		}
	}*/

		void OnTriggerEnter2D(Collider2D collider) 
	{
		if (collider.gameObject.tag == "RailgunM")
		{
			anim.SetBool ("isWalking", false);
			addforce = true;   

		}
	} 

	void OnTriggerExit2D(Collider2D collider) 
	{

		if (collider.gameObject.tag == "RailgunM")
		{
			addforce = false;
			this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			anim.SetBool ("isWalking", true);



		}
	}  

	public bool RailgunHit
	{
		get
		{
			return addforce;
		}

	}
}
