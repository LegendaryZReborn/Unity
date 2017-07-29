using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public GameObject ballPrefab;
	public GameObject burstParticle;
	private float constantSpeed = 10f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void mulitplyBall()
	{
		GameObject[] g = GameObject.FindGameObjectsWithTag("Ball");
		int numBalls = g.Length;

		if(numBalls < 3)
		{
			Vector2 pos = new Vector2(g[0].transform.position.x, 
				g[0].transform.position.y);

			List<GameObject> balls = new List<GameObject>();
			GameObject b;

			//Create up to 2 more balls and link them to the prefabs
			while(numBalls < 3)
			{
				b = Instantiate (ballPrefab) as GameObject;
				balls.Add(b);
				numBalls++;
			}

			Vector2 direction;
			int [] valid = {-1, 1};

			//Set the positions and apply the velocites to the duplicates
			switch(balls.Count)
			{
				case 1:
				//Set position and direction-speed 
					balls[0].transform.position = pos;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[0].GetComponent<Rigidbody2D>().velocity = constantSpeed * direction.normalized;
					break;
				case 2: 
				//Set position and direction-speed 
					balls[0].transform.position = pos;
					balls[1].transform.position = pos;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[0].GetComponent<Rigidbody2D>().velocity = constantSpeed * direction.normalized;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[1].GetComponent<Rigidbody2D>().velocity = constantSpeed *  direction.normalized;

					break;

				case 3: 

					//Set position and direction-speed 
					balls[0].transform.position = pos;
					balls[1].transform.position = pos;
					balls[2].transform.position = pos;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[0].GetComponent<Rigidbody2D>().velocity = constantSpeed *  direction.normalized;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[1].GetComponent<Rigidbody2D>().velocity = constantSpeed *  direction.normalized;

					direction = new Vector2 (valid[Random.Range(0, 2)], valid[Random.Range(0, 2)]);
					balls[2].GetComponent<Rigidbody2D>().velocity = constantSpeed *  direction.normalized;
					break;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.name == "Paddle")
		{
			mulitplyBall();
			queueExplosion();

		}
		else if(collider.tag == "L_Wall")
		{
			Vector2 inD = this.GetComponent<Rigidbody2D>().velocity;
			Vector2 inNorm = new Vector2(1f, 0f);
			this.GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(inD, inNorm);

		}
		else if (collider.tag == "R_Wall")
		{
			Vector2 inD = this.GetComponent<Rigidbody2D>().velocity;
			Vector2 inNorm = new Vector2(-1f, 0f);
			this.GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(inD, inNorm);
		}


	}

	void queueExplosion()
	{
		
		GameObject burst;

		burst = Instantiate(burstParticle) as GameObject;
		burst.transform.position = this.gameObject.transform.position;
		Destroy(burst, 1.2f);
	}
}
