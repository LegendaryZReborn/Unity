using UnityEngine;
using System.Collections;

public class Hurt : MonoBehaviour {

	private float knockBackCool = 0f;
	private float knockBackTime = 0f, flashTime = 0.18f;
	private int directionV = 0;
	private bool isKnockBack = false, hit = false, red = false;
	private Rigidbody2D otherO;
	private Animator animn;

	// Use this for initialization 
	void Start () { 
		otherO = GetComponent<Rigidbody2D> (); 
		animn = GetComponent <Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isKnockBack == true)
		{
			//0.2s
			if (knockBackCool > 0f) {
				knockBackCool -= Time.deltaTime;
				 
			}
			else
			{
				isKnockBack = false;
				hit = false;

			}
			 
			if (knockBackTime > 0f)
			{
				knockBackTime -= Time.deltaTime * 4f;


			} 
			else 
			{
				otherO.velocity = Vector2.zero; 

			}
		}
		 
		hurtFlash ();
	}

	public bool Hit()  
	{
		return hit;
	}

	void attackDirection(Collider2D other)
	{
		Vector2 vel = other.attachedRigidbody.velocity;
		

		if(vel.y > 0f)
		{
			directionV = 2;
		}
		else if(vel.y < 0f)
		{
			directionV = 3;
		}
		else if(vel.x > 0)
		{
			directionV = 1;
		}
		else if(vel.x < 0)
		{
			directionV = 0;
		}

	}

	void applyKnockBack ()
	{

		//left
		if (directionV == 0) 
		{
			//facing right so knockback left
			otherO.velocity = new Vector2 (-4f, 0f);
			Debug.Log ("velocity applied"); 
		}
		//right
		else if (directionV == 1) 
		{
			otherO.velocity = new Vector2 (4f, 0f);
			Debug.Log ("velocity applied"); 
		}
		//up
		else if (directionV == 2) 
		{
			otherO.velocity = new Vector2 (0f, 4f);
			Debug.Log ("velocity applied"); 
		}
		//down
		else if (directionV == 3) 
		{
			otherO.velocity = new Vector2 (0f, -4f);
			Debug.Log ("velocity applied"); 

		}
		 
	}

	void hurtFlash()
	{ 
		

		if (hit) {
			otherO.GetComponent<SpriteRenderer> ().color = new Color (208f / 255f, 87f / 255f, 87f / 255f, 255f / 255f);
			red = true;
			  
			 
			if (flashTime > 0f) {
				flashTime -= Time.deltaTime;
			} else {
				if (red) {
					otherO.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
					red = false;
				} else {
					otherO.GetComponent<SpriteRenderer> ().color = new Color (208f / 255f, 87f / 255f, 87f / 255f, 255f / 255f);
					red = true;
				}
				flashTime = 0.18f;
			}

		}
		else
		{
			flashTime = 0.18f;
		}


		if(red && !hit)
		{
			otherO.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);


		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 
		if (other.gameObject.tag == "Electric Ball" && isKnockBack == false) {
			

			knockBackCool = 0.4f; 
			knockBackTime = 0.4f; 
			isKnockBack = true;
			hit = true;

			attackDirection (other);
			applyKnockBack ();

			Destroy (other.gameObject);
			 
		} 

	}


}
 