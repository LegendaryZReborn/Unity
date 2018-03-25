using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	private Inventory inventory;
	private ItemSlot selectedItemSlotS;

	public ItemSlot [] slots;
	public Item defaultItem;

	// Use this for initialization
	void Start () {
		GameObject selectedSlot = GameObject.Find("SlotImg");

		if(selectedSlot){
			selectedItemSlotS = selectedSlot.GetComponent<ItemSlot>();
		}

		inventory = Inventory.instance;
		slots = GetComponentsInChildren<ItemSlot>();
		inventory.onInventoryChangeCallBack += updateInvUI;
		inventory.onSelectionChangeCallBack += changeSelected;
	
		inventory.addItem(defaultItem);
	}

	private void updateInvUI(){
		for(int i = 0; i < slots.Length; ++i){
			if(i < inventory.ItemCount)
				slots[i].setSlot(inventory.getItem(i));
		}


	}

	private void changeSelected(){
		Debug.Log(inventory.SelectedItem);
		selectedItemSlotS.setSlot(inventory.SelectedItem);
	}
}
