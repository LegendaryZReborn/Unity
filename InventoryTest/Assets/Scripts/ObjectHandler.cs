using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectHandler : MonoBehaviour {

	private Inventory inventory;
	private GameObject dynamic;
	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		dynamic = GameObject.Find("Dynamic");

		if(!dynamic){
			Debug.Log("Dynamic Game Object not found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			spawnObject();
		}

	}

	void spawnObject(){
		if(inventory.SelectedItem != null){
			string name = inventory.SelectedItem.ItemName;
			GameObject prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + name + ".prefab", typeof(GameObject)) as GameObject;

			if(prefab){
				GameObject spawnedObject = Instantiate(prefab, this.transform.position, this.transform.rotation) as GameObject;
				spawnedObject.transform.parent = dynamic.transform;	
				alignToGround(spawnedObject);
			}
		}
		else{
			Debug.Log("No Item Selected!");
		}
	}

	void alignToGround(GameObject g){
		RaycastHit hit;

		if(Physics.Raycast(g.transform.position, -Vector3.up, out hit)){
			Vector3 target = hit.point;
			Bounds bounds = g.GetComponent<MeshFilter>().mesh.bounds;
			target.y += bounds.extents.y;

			g.transform.position = target;
		}
	}
}
