using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDescription : MonoBehaviour {

	Text[] textFields;

	void Start () {
		textFields = gameObject.GetComponentsInChildren<Text>();
	}

	public void UpdateDescriptionText(int index){
		if(index < Inventory.instance.inventoryItems.Count){
			textFields[0].text = Inventory.instance.inventoryItems[index].name;
			textFields[1].text = Inventory.instance.inventoryItems[index].description;
		}
	}
}
