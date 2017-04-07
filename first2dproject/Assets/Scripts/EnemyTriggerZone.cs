using UnityEngine;
using System.Collections;

public class EnemyTriggerZone : MonoBehaviour {

	private bool collided = false;
	private bool walking = false;
	private bool trappedByAtk = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		trappedByAtk = GetComponentInParent<RForceE> ().RailgunHit;
		if (trappedByAtk)
		{
			collided = false;
			walking = false;
		}
	}

	public bool collidedReturn()
	{
		return collided;
	}

	public bool walkingReturn()
	{
		return walking;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (!trappedByAtk) {
			if (other.gameObject.name == "Player") {
				collided = true;
				walking = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player")
		{
			collided = false;
			walking = false;
		
		}
	}
}
