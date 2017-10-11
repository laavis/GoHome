using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	public List<Item> inventoryItems = new List<Item> ();

	[Header("Inventory UI")]
	public Transform itemsList;
	InventorySlot[] slots;
	

	void Awake() {
		if(instance == null) {
			instance = this;
			// This is already handled in the GameManager.cs
			// Canvas which contains the Inventory is a child of the GameManager, 
			// so DontDestroyOnLoad doesn't need to be called in this script.
			//GameObject.DontDestroyOnLoad(this.gameObject);

		} else if(instance != this) {
			//Debug.Log("More than one insance of Inventory found!");
			Destroy(gameObject);
		}

		inventoryItems = GameManager.instance.inventoryData;
	}

	void Start() {

		slots = itemsList.GetComponentsInChildren<InventorySlot>();
		UpdateUI();

	}

	public void Add(Item item) {
		Debug.Log(item.name);

		inventoryItems.Add(item);
		
		UpdateUI();
	}

	public void UpdateUI() {
		for(int i = 0; i < slots.Length; i++){
			
			if(i < inventoryItems.Count){
				slots[i].AddItem(inventoryItems[i]);
			}

		}
	}


	public void ResetUI() {
		if (slots == null) return;

		for(int i = 0; i < slots.Length; i++){
			slots[i].Reset();
		}

		GameManager.instance.inventory.GetComponentInChildren<UpdateDescription>().ResetDescriptionText();
	}
}
