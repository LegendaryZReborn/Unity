using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInputs : MonoBehaviour {

	public GameObject inventory;

	private Inventory invScript;
	private bool isOpen;
	// Use this for initialization
	void Start () {
		isOpen = false;
		invScript = Inventory.instance;
		inventory.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) && !isOpen){
			Invoke("openInventory", 0f);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && isOpen){
			Invoke("closeInventory", 0f);
		}
	}

	void openInventory(){
		inventory.SetActive(true);
		isOpen = true;
	}

	void closeInventory(){
		inventory.SetActive(false);
		isOpen = false;
	}
}
