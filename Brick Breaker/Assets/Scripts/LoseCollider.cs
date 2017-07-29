using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

		if(balls.Length < 1)
			levelManager.LoadLevel("Lose_Screen");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		
		Destroy(collider.gameObject); 

	}

}
 