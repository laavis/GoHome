using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	
	public static bool isPaused = false;
	public GameObject inventory;
	public GameObject textBox;

	public bool isInventoryOpen = false;
	public bool isTextBoxOpen = false;

	public GameObject loadNextSceneText;
	public GameObject loadPreviousSceneText;

	// Inventory data
	[Header("Items in inventory")]
	public List<Item> inventoryData;


	void Awake () {
		// GameManager is Singleton (i.e. only one GameManager instance at any given time)
		if(instance != null){
			// There is already an instance of the GameManager
			// Destroy this before it causes trouble
			Destroy(this.gameObject);
			return;
		}
		//If the instance is null, this is The GameManager so let's not destroy it between scenes
		instance = this;
		GameObject.DontDestroyOnLoad(this.gameObject);

	}
	
	// Use this for initializa'tion
	void Start () {
		// Inventory and TextBox are disabled (not visible) by default
		inventory.SetActive(isInventoryOpen);
		textBox.SetActive(isTextBoxOpen);
		
	}
	
	// Update is called once per frame
	void Update () {
		//If either Inventory or TextBox is active, game should be paused
		//This variable is checked in PlayerController.cs
		isPaused = (isInventoryOpen || isTextBoxOpen) || false;	
	}

	public void ToggleInventory() {
		isInventoryOpen = !isInventoryOpen;
		inventory.SetActive(isInventoryOpen);
	}

	public void ToggleTextBox(){
		isTextBoxOpen = !isTextBoxOpen;
		textBox.SetActive(isTextBoxOpen);
	}

	public void SaveData(){
		inventoryData = Inventory.instance.inventoryItems;
	}

	public void LoadData(){
		Inventory.instance.inventoryItems = inventoryData;
	}

}
