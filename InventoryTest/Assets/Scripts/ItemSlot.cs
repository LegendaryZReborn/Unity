using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour{

	private Image slotImage;
	private Item item;
	private Inventory inventory;

	void Awake(){
		slotImage = GetComponent<Image>();
	}

	void Start(){
		inventory = Inventory.instance;
	}

	public void setSlot(Item otherItem){
		if(otherItem){
			slotImage.sprite = otherItem.ItemSprite;
			item = otherItem; 
		}
	}

	public Item SlotItem{
		get{return item;}
	}

	public void isSelected(){
		inventory.SelectedItem =  item;
	}

}
