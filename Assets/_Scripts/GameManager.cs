using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	
	public static bool isPaused = false;
	public GameObject canvas;
	public GameObject inventory;
	public GameObject textBox;

	public GameObject playerPrefab;
	public GameObject player;

	public GameObject bus;

	public GameObject endScreen;

	public GameObject menu;

	public bool isInventoryOpen = false;
	public bool isTextBoxOpen = false;
	public bool isPauseMenuOpen = false;
	public bool isWaitingForBus = false;

	public bool hasTalkedToBartender = false;

	public GameObject loadNextSceneText;
	public GameObject loadPreviousSceneText;

	// Inventory data
	[Header("Items in inventory")]
	public List<Item> inventoryData;

	void Start () {
		Load();
	}

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
	
	// Update is called once per frame
	void Update () {
		//If either Inventory or TextBox is active, game should be paused
		//This variable is checked in PlayerController.cs
		isPaused = (isInventoryOpen || isTextBoxOpen || isWaitingForBus) || false;	
	}

	public void ToggleInventory() {
		isInventoryOpen = !isInventoryOpen;
		inventory.SetActive(isInventoryOpen);
	}

	public void ToggleTextBox(){
		isTextBoxOpen = !isTextBoxOpen;
		textBox.SetActive(isTextBoxOpen);
	}

	public void TogglePauseMenu(){
		isPauseMenuOpen = !isPauseMenuOpen;
		menu.SetActive(isPauseMenuOpen);
	}

	public IEnumerator ToggleEndSreen(){
		yield return new WaitForSeconds(5);
		endScreen.SetActive(true);	
	}

	public void SaveData(){
		inventoryData = Inventory.instance.inventoryItems;
	}

	public void LoadData(){
		Inventory.instance.inventoryItems = inventoryData;
	}

	public void Load() {
		canvas.SetActive(true);

		inventory.SetActive(isInventoryOpen);
		textBox.SetActive(isTextBoxOpen);
		menu.SetActive(isPauseMenuOpen);
		endScreen.SetActive(false);

		player = Instantiate(playerPrefab);

		LoadData();
		Inventory.instance.ResetUI();

		Debug.Log("LOAD");
	}

	public void Reset() {
		isInventoryOpen = false;
		isTextBoxOpen = false;
		isPauseMenuOpen = false;
		isWaitingForBus = false;

		hasTalkedToBartender = false;

		inventoryData.Clear();

		canvas.SetActive(false);

		if (player) player.GetComponent<PlayerController>().Remove();

		SceneManager.LoadScene("Main menu");
	}
}
