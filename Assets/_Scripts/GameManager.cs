using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public static bool isPaused = false;

	//public GameObject inventory;
	public GameObject textBox;

	public bool isInventoryOpen = false;
	public bool isTextBoxOpen = false;

	void Awake () {
		instance = this;
	}

	// Use this for initializa'tion
	void Start () {
		//inventory.SetActive(isInventoryOpen);
		textBox.SetActive(isTextBoxOpen);

	}
	
	// Update is called once per frame
	void Update () {
		isPaused = (isInventoryOpen || isTextBoxOpen) || false;
		
	}

	/*public void ToggleInventory() {
		isInventoryOpen = !isInventoryOpen;
		inventory.SetActive(isInventoryOpen);
	}*/

	public void ToggleTextBox(){
		isTextBoxOpen = !isTextBoxOpen;
		textBox.SetActive(isTextBoxOpen);
	}

}
