using UnityEngine;
using System.Collections;

public class ClickBehavior : MonoBehaviour {
	private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		rend.color = Color.clear;
		Debug.Log ("HERE");
	}

	void OnMouseExit()
	{
		rend.color = Color.white;
	}
}
