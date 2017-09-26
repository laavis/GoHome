using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	public static Data instance;

	public List<Item> inventoryData;

	void Awake() {
		if(instance == null){
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}
	}

	public void SaveData(){
		inventoryData = Inventory.instance.inventoryItems;
	}

	public void LoadData(){
		Inventory.instance.inventoryItems = inventoryData;
	}

}
