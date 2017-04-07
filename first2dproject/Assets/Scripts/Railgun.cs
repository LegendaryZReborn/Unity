using UnityEngine;
using System.Collections;

public class Railgun : MonoBehaviour {

	public GameObject laserStart;
	public GameObject laserMiddle;
	public GameObject laserEnd;

	private GameObject start;
	private GameObject middle;
	private GameObject end;
	private bool destroying = false, check = false;
	private Vector2 msize, playerU, playerD, playerL, playerR;
	private RForce rforce;
	private Vector3 tempR; 
	private GameObject player;
	private Animator anim;
	private float directx, directy, dirx, diry;
	public GameObject ElecAura;
	private GameObject elecAuraC;
	public RF

	void Start()
	{
		player = GameObject.Find ("Player");
		anim = player.GetComponent<Animator> ();
	}

	void Update()
	{
		if (!Input.GetKey (KeyCode.R)) 
		{
			dirx = anim.GetFloat ("input_x");
			diry = anim.GetFloat ("input_y");
		}

		if (Input.GetKey (KeyCode.R)  && !destroying ) {

			attackPosSet ();
			// Create the laser start from the prefab
			if (start == null && middle == null) {
				start = Instantiate (laserStart) as GameObject;
				start.transform.parent = this.transform; 
				start.transform.localPosition = Vector2.zero;

				rotateBeam (ref start);
			}

		

			// Laser middle
			if (middle == null) {
				middle = Instantiate (laserMiddle) as GameObject;
				middle.transform.parent = this.transform;
				middle.transform.localPosition = Vector2.zero;

				//set the collider
				msize = middle.GetComponent<SpriteRenderer> ().sprite.bounds.size;
				msize.y = msize.y / 2f;
				middle.transform.GetComponent<BoxCollider2D> ().size = msize;
				middle.transform.GetComponent<BoxCollider2D> ().offset = new Vector2 (msize.x/2f, 0f);

				rotateBeam (ref middle);

			}

		/*	tempR = middle.transform.rotation.eulerAngles;
			tempR.z = -90.0f;
			middle.transform.rotation = Quaternion.Euler (tempR);*/



			middle.transform.localScale += new Vector3 (0.1f, 0f, 0f); 
			msize = middle.GetComponent<SpriteRenderer> ().sprite.bounds.size;   
			msize.y = msize.y / 2f; 

			//adjusting the collider size and offset 
			middle.transform.GetComponent<BoxCollider2D> ().size = msize;
			middle.transform.GetComponent<BoxCollider2D> ().offset = new Vector2 (msize.x/2f, 0f);  
			 
			directx = anim.GetFloat("input_x");
			directy = anim.GetFloat ("input_y");
		} 
		else 
		{ 
			anim.SetBool ("isAttacking", false);

			if (elecAuraC != null)
				Destroy (elecAuraC);
			
			player.GetComponent<Movement_control> ().enabled = true;



			if (start != null) 
			{
				Destroy (start);
			} 

			if (middle != null) {

				if (directy == 1f) {
					middle.transform.localPosition += new Vector3 (0f, 0.1f, 0f);

				} else if (directy == -1f) {
					middle.transform.localPosition += new Vector3 (0f, -0.1f, 0f);

				} 
				else if (directx  == -1f) 
				{
					middle.transform.localPosition += new Vector3 (-0.1f, 0f, 0f);
				}
				else if(directx == 1f)
				{
					middle.transform.localPosition += new Vector3 (0.1f, 0f, 0f);
				}

			}   
			 
			if (middle != null)
			{
				Destroy (middle, 1f);
				destroying = true;
				check = true;

			}
				
			if(middle == null)  
				destroying = false;



				


		}

	}

	void rotateBeam(ref GameObject beamPart)
	{

		if (diry == 1f) {
			tempR = beamPart.transform.rotation.eulerAngles;
			tempR.z = 90.0f;
			beamPart.transform.rotation = Quaternion.Euler (tempR);

		} else if (diry == -1f) {
			
			tempR = beamPart.transform.rotation.eulerAngles;
			tempR.z = -90.0f;
			beamPart.transform.rotation = Quaternion.Euler (tempR);

		} 
		else if (dirx == -1f) 
		{
			tempR = beamPart.transform.rotation.eulerAngles;
			tempR.z = 180.0f;
			beamPart.transform.rotation = Quaternion.Euler (tempR);
			 
		}
		else if(dirx == 1f)
		{
			tempR = beamPart.transform.rotation.eulerAngles;
			tempR.z = 0f;
			beamPart.transform.rotation = Quaternion.Euler (tempR);


		}
	}

	void attackPosSet()
	{
		anim.SetBool ("isAttacking", true);
		anim.SetBool ("isWalking", false);

		player.GetComponent<Movement_control> ().enabled = false;

		if (elecAuraC == null)
		{
			elecAuraC = Instantiate (ElecAura, player.transform.position, Quaternion.identity) as GameObject;
		}

		playerU = new Vector2 (player.transform.position.x, player.transform.position.y + 0.3f);
		playerD = new Vector2 (player.transform.position.x, player.transform.position.y - 0.2f);
		playerL = new Vector2 (player.transform.position.x - 0.2f, player.transform.position.y);
		playerR = new Vector2 (player.transform.position.x + 0.2f, player.transform.position.y);

		if (diry == 1f) 
		{
			transform.position = playerU;
		} 
		else if (diry == -1f) 
		{
			transform.position = playerD;
		} 
		else if (dirx == 1f) 
		{
			transform.position = playerR;
		} 
		else if (dirx == -1f)
		{
			transform.position = playerL;
		}
	}

	public GameObject rEnd()
	{
		return end;
	}




}   