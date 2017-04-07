using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleD : MonoBehaviour {
	
	public GameObject emptyCircle;
	public GameObject redCircle, blueCircle , lgCircle, purpleCircle, orangeCircle ;

	private GameObject CemptyCir;
	private ArrayList circles = new ArrayList(301);
	private float offsetx = 22.5f, offsety = -64f;
	private bool drawn = false;
	private int colorC = 0, colorCB = 6, redInput = 0, blueInput= 0, lightGreen = 0, purple = 0, orange = 0;
	private GameObject temp;
	private Vector3 tempPos;

	// Use this for initialization
	void Start () {

		this.transform.position = new Vector3 (0f, 0f, 0f);  
	}
	
	// Update is called once per frame
	void Update () { 

		if (!drawn) {

			DrawCircles ();
			drawn = true;
		}

	}

	void DrawCircles()
	{
		// Circles
		for (int c = 0; c < 25; c++) {

			for (int r = 0; r < 12; r++) {
				CemptyCir = Instantiate (emptyCircle);
				CemptyCir.transform.parent = this.transform;
				CemptyCir.transform.localPosition = new Vector3(offsetx, offsety, 0f);
				circles.Add (CemptyCir);

				if (r != 5) {
					offsety -= 30f;
				} else {

					offsety -= 120f;
				}

			}

			offsetx += 30f;


			offsety = -64f;   
		}

	
	}

	void ColorCircles()
	{

		//top

		if (colorC < 294) {
			for (int r = 0; r < redInput; r++) {
				if (colorC < 294) {
					temp = circles [colorC] as GameObject;
					tempPos = temp.transform.position;
					Destroy (temp);
					circles [colorC] = Instantiate (redCircle, tempPos, Quaternion.identity);

					colorC++;

					if (colorC % 6 == 0 ) {
						colorC += 6; 
					
					}
				}

			}
				

			for (int b = 0; b < blueInput; b++) {

				if (colorC < 294) {
					temp = circles [colorC] as GameObject;
					tempPos = temp.transform.position;
					Destroy (temp);
					circles [colorC] = Instantiate (blueCircle, tempPos, Quaternion.identity);
					colorC++;

					if (colorC % 6 == 0)
						colorC += 6;
				}
			}

			for (int lg = 0; lg < lightGreen; lg++) {

				if (colorC < 294) {
					temp = circles [colorC] as GameObject;
					tempPos = temp.transform.position;
					Destroy (temp);
					circles [colorC] = Instantiate (lgCircle, tempPos, Quaternion.identity);
					colorC++;

					if (colorC % 6 == 0)
						colorC += 6;
				}
			}

			for (int p = 0; p < purple; p++) {

				if (colorC < 294) {
					temp = circles [colorC] as GameObject;
					tempPos = temp.transform.position;
					Destroy (temp);
					circles [colorC] = Instantiate (purpleCircle, tempPos, Quaternion.identity);
					colorC++;

					if (colorC % 6 == 0)
						colorC += 6;
				}
			}
		

			for (int o = 0; o < orange; o++) {
				if (colorC < 294) {
					temp = circles [colorC] as GameObject;
					tempPos = temp.transform.position;
					Destroy (temp);
					circles [colorC] = Instantiate (orangeCircle, tempPos, Quaternion.identity);
					colorC++;

					if (colorC % 6 == 0)
						colorC += 6;
				}
			}

			Debug.Log ("C " + colorC);
		} else {
			



	
			if (colorCB < 300) {
				//bottom
				for (int r = 0; r < redInput; r++) {
					if (colorCB < 300) {
						temp = circles [colorCB] as GameObject; 
						tempPos = temp.transform.position;
						Destroy (temp);
						circles [colorCB] = Instantiate (redCircle, tempPos, Quaternion.identity);
						colorCB++;

						if (colorCB % 6 == 0) {
					  
							colorCB += 6;

						}
					}
				}

				for (int b = 0; b < blueInput; b++) {
					if (colorCB < 300) {
						temp = circles [colorCB] as GameObject;
						tempPos = temp.transform.position;
						Destroy (temp);
						circles [colorCB] = Instantiate (blueCircle, tempPos, Quaternion.identity);
						colorCB++;

						if (colorCB % 6 == 0)
							colorCB += 6;
					}
				}

				for (int lg = 0; lg < lightGreen; lg++) {

					if (colorCB < 300) {
						temp = circles [colorCB] as GameObject;
						tempPos = temp.transform.position;
						Destroy (temp);
						circles [colorCB] = Instantiate (lgCircle, tempPos, Quaternion.identity);
						colorCB++;

						if (colorCB % 6 == 0)
							colorCB += 6;
					}
				}

				for (int p = 0; p < purple; p++) {
					if (colorCB < 300) {
				
						temp = circles [colorCB] as GameObject;
						tempPos = temp.transform.position;
						Destroy (temp);
						circles [colorCB] = Instantiate (purpleCircle, tempPos, Quaternion.identity);
						colorCB++;

						if (colorCB % 6 == 0)
							colorCB += 6;
					}
				}


				for (int o = 0; o < orange; o++) {

					if (colorCB < 300) {
						temp = circles [colorCB] as GameObject;
						tempPos = temp.transform.position;
						Destroy (temp);
						circles [colorCB] = Instantiate (orangeCircle, tempPos, Quaternion.identity);
						colorCB++;

						if (colorCB % 6 == 0)
							colorCB += 6;
					}
				}
			}
			Debug.Log ("CB " + colorCB);
		}


		//reset back to 0
		resetColorNum ();
	}


	public void UseInput()
	{
		string rtext, btext, lgtext, ptext, otext;
		InputField IR, IB, ILG, IP, IO;

		IR = GameObject.Find ("InputFieldR").GetComponent<InputField> (); 
		IB = GameObject.Find ("InputFieldB").GetComponent<InputField> ();
		ILG = GameObject.Find ("InputFieldLG").GetComponent<InputField> (); 
		IP = GameObject.Find ("InputFieldP").GetComponent<InputField> ();
		IO = GameObject.Find ("InputFieldO").GetComponent<InputField> ();

		rtext = IR.text; 
		btext = IB.text; 
		lgtext = ILG.text; 
		ptext = IP.text; 
		otext = IO.text; 

		if (int.TryParse (rtext, out redInput)) 
		{
			Debug.Log ("True");
		}

		if (int.TryParse (btext, out blueInput)) 
		{
			Debug.Log ("True");
		}

		if (int.TryParse (lgtext, out lightGreen)) 
		{
			Debug.Log ("True");
		}

		if (int.TryParse (ptext, out purple)) 
		{
			Debug.Log ("True");
		}

		if (int.TryParse (otext, out orange)) 
		{
			Debug.Log ("True");
		}

		IR.text = "";
		IB.text = "";
		ILG.text = "";
		IP.text = "";
		IO.text = "";

		ColorCircles ();
	}

	public void clearAll()
	{
		for(int cl = 0; cl < 300; cl++)
		{
				temp = circles[cl] as GameObject;
				tempPos = temp.transform.position;
				Destroy(temp);

				circles[cl] = Instantiate(emptyCircle, tempPos, Quaternion.identity);
		}

		colorC = 0;
		colorCB = 6;
	}

	void resetColorNum()
	{
		redInput = 0;
		blueInput = 0; 
		lightGreen = 0;
		purple = 0; 
		orange = 0;
	}
}
   