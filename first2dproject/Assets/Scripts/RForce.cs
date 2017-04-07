using UnityEngine;
using System.Collections;

public class RForce : MonoBehaviour {

	/*private GameObject wielder;
	private Animator anim;
	private Railgun rscript;
	private GameObject end;
	private Vector3 locale;
	private float f, dY, dX, axis = 1f;
	private Collision2D coll;
	private bool addforce = false;
	private ArrayList currentCol = new ArrayList ();
	private GameObject temp = null, eTemp = null, fTemp;

	
	// Use this for initialization
	void Start () { 
		wielder = GameObject.Find ("Player");
		rscript = GetComponentInParent<Railgun> ();
		anim = wielder.GetComponent<Animator> ();
	}

	
	*/

	// Update is called once per frame
	void Start()
	{
	}

	void Update () {
	/*	if(Input.GetKey(KeyCode.R))
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

		if (end != null)
		{		
			//needs to move with beam
			f = GetComponent<Renderer>().bounds.size.x + 0.1f;
			end.transform.localPosition = new Vector3(transform.localPosition.x + f, transform.localPosition.y, transform.localPosition.z) ;
		}*/
	}

	public Transform RPosition
	{
		get 
		{
			return this.transform;
		}
	}
/*	void FixedUpdate()
	{
		if (addforce) {
			for (int ad = 0; ad < currentCol.Count; ad++) 
			{
				fTemp = currentCol [ad] as GameObject;

				if(dX == 1f){
					fTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50f, 0f), ForceMode2D.Force);
				}
				else if(dX == -1f){
					fTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-50f, 0f), ForceMode2D.Force);
				}
				else if(dY == 1f){
					fTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 50f), ForceMode2D.Force);
				}
				else if(dY == -1f){
					fTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -50f), ForceMode2D.Force);
				}


				if (axis == 1f) {
					//lock to beams x axis
					fTemp.GetComponent<Rigidbody2D> ().MovePosition(new Vector2(transform.position.x, fTemp.GetComponent<Transform>().position.y));
				} 
				else 
				{ 
					//lock to beams y axis
					fTemp.GetComponent<Rigidbody2D> ().MovePosition(new Vector2(fTemp.GetComponent<Transform>().position.x, transform.position.y));
				}
				 

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
	/*
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			currentCol.Add (coll.gameObject);
		}
			
	}
	void OnTriggerStay2D(Collider2D collider) 
	{
		if (collider.gameObject.tag == "Enemy")
		{
			addforce = true;   
		}
	} 

	void OnTriggerExit2D(Collider2D collider) 
	{

		if (collider.gameObject.tag == "Enemy")
		{
			eTemp = currentCol [currentCol.IndexOf(collider.gameObject)] as GameObject;
			eTemp.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			eTemp = null; 
			 
			currentCol.Remove(collider.gameObject);

			if(currentCol.Count == 0)
				addforce = false;
		
		}
	}  
	*/

}
  