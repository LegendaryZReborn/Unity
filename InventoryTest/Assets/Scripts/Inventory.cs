using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {
	#region Singleton
	public static Inventory instance;

	void Awake(){
		if(instance != null){
			Debug.Log("More than one instance found!");
			return;
		}

		instance = this;
	}
	#endregion

	private const int MAX = 5;
	private Item selectedItem;
	private List<Item> items = new List<Item>();

	public delegate void onInventoryChange();
	public onInventoryChange onInventoryChangeCallBack;
	public delegate void onSelectionChange();
	public onSelectionChange onSelectionChangeCallBack;

	void Start(){
	}


	public void addItem(Item item){
		if(items.Count < MAX){
			items.Add(item);

			if(onInventoryChangeCallBack != null)
				onInventoryChangeCallBack.Invoke();
		}
		else{
			Debug.Log("Item could not be added. Not enough space!");
		}

	}

	public void removeItem(Item item){
		bool wasRemoved = items.Remove(item);

		if(wasRemoved){
			if(onInventoryChangeCallBack != null)
				onInventoryChangeCallBack.Invoke();
		}
		else{
			Debug.Log("Item could not be removed!");
		}
	}

	public Item getItem(int i){
		return items[i];
	}

	public int ItemCount{
		get{return items.Count;}
	}

	public Item SelectedItem{
		get{return selectedItem;}

		set{
			selectedItem = value;
			onSelectionChangeCallBack.Invoke();
		}
	}

}