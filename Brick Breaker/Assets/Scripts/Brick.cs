using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int numBricks = 0;
	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private SpriteRenderer rendererC;
	private float brickI = 0.2f;
	private bool hit;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		hit = false;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		numBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		print (numBricks);
		rendererC = GetComponent<SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (numBricks <= 0) {
			SimulateWin ();
		}

		if (hit == true && brickI > 0f) {
			brickI -= Time.deltaTime;
		}
		else {
			hit = false;
		}

	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (!hit) {
			hit = true;
			timesHit += 1;

			if (timesHit >= maxHits) {
				Destroy (gameObject, Time.deltaTime);
				numBricks -= 1;
			}

			if (maxHits == 3) {
					
				if (timesHit == 1) {
					print (timesHit);
					//rendererC.color = new Color(0.33f , 3f, 0f, 1f); 
					rendererC.color = new Color32 (83 , 255, 0, 255); 

				} else if (timesHit == 2) {
					rendererC.color =  new Color32 (251, 255, 0, 255);

				}
			}
			 
			else if (maxHits == 2) {
				rendererC.color = new Color32 (251, 255, 0, 255);
			}
		}

	}


	void SimulateWin()
	{
		levelManager.LoadNextLevel ();
		Debug.Log ("LOAD NEXT LEVEL");
	}
}
