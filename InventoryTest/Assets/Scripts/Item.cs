using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject{

	public Sprite image;
	public string description;
	new public string name;

	public Item(){
		image = null;
		description = "Default description";
		name = "New Item";
	}

	public Sprite ItemSprite{
		get{return image;}
		set{image = value;}
	}

	public string ItemName{
		get{return name;}
		set{name = value;}
	}

	public string ItemDescription{
		get{return description;}
		set{description = value;}
	}
}
