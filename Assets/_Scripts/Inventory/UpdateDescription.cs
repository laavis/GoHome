using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDescription : MonoBehaviour {

	private Text description;

	// Use this for initialization
	void Start () {
		description = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateDescriptionText(int index){
		description.text = Inventory.instance.inventoryItems[index].description;
	}
}
