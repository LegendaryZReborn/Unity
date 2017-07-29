using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

	public static int numBricks = 0;
	public int maxHits;
	public GameObject powerUpSphere;
	public GameObject particles;
	private int baseBrickPoints;
	private int green, red;
	private int timesHit;
	private LevelManager levelManager;
	private SpriteRenderer rendererC;
	private GameObject score;
	private ScoreScript scoreS;

	// Use this for initialization
	void Start () {
		green = 2;
		red = 3;
		timesHit = 0;
		baseBrickPoints = 100;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		numBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		score = GameObject.Find("Score");
		scoreS = score.GetComponent<ScoreScript>();
		rendererC = GetComponent<SpriteRenderer> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Disable collider trigger set in tiling script
		GetComponent<Collider2D>().isTrigger = false;		

	}

	void OnCollisionExit2D(Collision2D collision)
	{
		//Check if the brick was hit by the ball and update the 
		//number of times hit. If the brick was hit its max
		//hit count, destroy it.
		if(collision.gameObject.tag == "Ball")
		{
			timesHit += 1;

			if (timesHit >= maxHits)
			{
				numBricks -= 1;
				GlobalData.Score += baseBrickPoints;
				spawnPowerUp();
				Destroy (gameObject);

				if (numBricks <= 0) {
					SimulateWin ();
				}
			}

			//Change the bricks color as it is hit to reflect
			//how many more times it needs to be hit
			if (maxHits == 3)
			{
				//change to green else yellow
				if (timesHit == 1) 
				{
					rendererC.color = new Color32 (83 , 255, 0, 255); 
					GlobalData.Score += (red * baseBrickPoints);
				} 
				else if (timesHit == 2)
				{
					rendererC.color =  new Color32 (251, 255, 0, 255);
					GlobalData.Score += (green * baseBrickPoints);
				}
			}
			 
			else if (maxHits == 2) 
			{
				//change to yellow
				rendererC.color = new Color32 (251, 255, 0, 255);
				GlobalData.Score += (green * baseBrickPoints);
			}
				
			scoreS.updateScore();
		}
	}

	void spawnPowerUp()
	{
		//Instatiate a power up sphere or not. Approx twenty percent chance
		int r = Random.Range(0, 5);
		GameObject p;

		if(r == 4|| r == 3)
		{
			p = Instantiate(particles) as GameObject;
			p.transform.position = new Vector3(gameObject.transform.position.x,
				gameObject.transform.position.y, -1f);
			p.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(1f, -1f), -1) * 5f;
		}
	}

	void SimulateWin()
	{
		levelManager.LoadNextLevel ();
	}
}
