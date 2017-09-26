using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public Transform itemsList;

	Inventory inventory;

	InventorySlot[] slots;

	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsList.GetComponentsInChildren<InventorySlot>();

		UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateUI(){
		Debug.Log("UPDATING UI");

		for(int i = 0; i < slots.Length; i++){
			
			if(i < inventory.inventoryItems.Count){
				slots[i].AddItem(inventory.inventoryItems[i]);
			}

		}
	}
}
