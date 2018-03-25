using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightControl : MonoBehaviour {
	
	private Light spotLight;
	public LayerMask layerMask;

	void Start () {
		spotLight = GetComponent<Light>();
	}
	
	void Update () {
		followMouse();
	}

	void followMouse(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		float maximumHitDistance = 25.0f;

		if(Physics.Raycast(ray, out hit, maximumHitDistance, layerMask)){
			Vector3 target = hit.point;
			float yDistance = 2.0f;
			Vector3 updatedLightPosition = new Vector3(target.x, target.y + yDistance, target.z);		
			transform.position = updatedLightPosition;
			spotLight.enabled = true;
		}else{
			spotLight.enabled = false;
		}
	}
}
