using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
	public Item item;

	void Start() {
        if(Inventory.instance.inventoryItems.Contains(item)){
			Destroy(gameObject);
		}	
    }

	public void CollectItem() {
		Inventory.instance.Add(item);
		Destroy(gameObject);
	}
}
