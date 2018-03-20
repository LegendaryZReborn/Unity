using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectHandler : MonoBehaviour {

	private Inventory inventory;
	private GameObject spawnedObject;
	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J)){
			spawnObject();
		}

		rotateObject();
	}

	void spawnObject(){
		if(inventory.SelectedItem != null){
			string name = inventory.SelectedItem.ItemName;

			if(spawnedObject != null){
				Destroy(spawnedObject);
			}

			GameObject prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + name + ".prefab", typeof(GameObject)) as GameObject;

			spawnedObject = Instantiate(prefab) as GameObject;
			spawnedObject.transform.parent = this.transform;
			spawnedObject.transform.localPosition = Vector3.zero;
		
		}
		else{
			Debug.Log("No Item Selected!");
		}
	}

	void rotateObject(){
		if(spawnedObject != null){
			Vector3 rotationAxis = new Vector3(1f, 0f, 1f);
			this.transform.RotateAround(this.transform.position, rotationAxis, 180f * Time.deltaTime);
		}
	}
}
