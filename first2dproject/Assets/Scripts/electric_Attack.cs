using UnityEngine;
using System.Collections;

public class electric_Attack : MonoBehaviour {


	private Animator anim;
	private Vector2 permDirect;
	// Use this for initialization
	void Start () {
		 
		anim = GetComponent<Animator> ();
		permDirect = new Vector2 (0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			
			Vector2 direction = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			permDirect = new Vector2 (direction.x, direction.y);
			direction = Vector2.zero;

			if (direction == Vector2.zero) {
				
				anim.SetFloat ("input_x", permDirect.x);
				anim.SetFloat ("input_y", permDirect.y);
				anim.SetBool ("isAttacking", true);
			} 

		} else {
			
			anim.SetBool ("isAttacking", false);
		}
	}
}
