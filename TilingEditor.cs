using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof(Tiling))]
public class TilingEditor : Editor {
	private Transform trans;
	private Vector2 mousePosition;
	private GameObject obj;
	private float tileWidth;
	private float tileHeight;
	private ArrayList objs = new ArrayList();
	private GameObject parent;
	private GameObject target1;

	void OnEnable()
	{
		parent = GameObject.Find("Bricks");

	}

	void OnSceneGUI()
	{
		target1 = Selection.activeGameObject as GameObject;
		
		if(target1) 
		{
			if(Event.current.button == 1)
			{
				mousePosition =  Event.current.mousePosition;
				mousePosition.y = Camera.current.pixelHeight - mousePosition.y ;
				mousePosition = Camera.current.ScreenPointToRay(mousePosition).origin;

				tileWidth = target1.GetComponent<Renderer>().bounds.size.x;
				tileHeight = target1.GetComponent<Renderer>().bounds.size.y;

				string prefabPath = "Assets/Prefab/" + target1.name + ".prefab";
				GameObject prefab = AssetDatabase.LoadAssetAtPath(prefabPath, 
					typeof(GameObject)) as GameObject;

				obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
//				Debug.Log(prefabPath);
//				//Connect it to the prefab
//				PrefabUtility.ConnectGameObjectToPrefab(obj, prefab);

				obj.transform.parent = parent.transform;

				//Snap the object to the position of the mouse according to tile width and height
				obj.transform.position = new Vector3(Mathf.Round(mousePosition.x/tileWidth) * tileWidth, 
					Mathf.Round(mousePosition.y/tileHeight) * tileHeight, 0f);
				
				//search positions
				GameObject g;
				bool found = false;
				for(int i = 0; i < objs.Count && !found; i++)
				{
					g = objs[i] as GameObject;
					if (g.transform.position == obj.transform.position)
					{
						DestroyImmediate(obj);
						found = true;
					}
				}

				if(!found)
					objs.Add(obj);
			}
		}
	}
}
