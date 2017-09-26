using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public static bool isPaused = false;

	public GameObject inventory;

	public bool isInventoryOpen = false;

	// Use this for initializa'tion
	void Start () {
		inventory.SetActive(isInventoryOpen);
	}
	
	// Update is called once per frame
	void Update () {
		isPaused = (isInventoryOpen) || false;
	}

	public void ToggleInventory() {
		isInventoryOpen = !isInventoryOpen;
		inventory.SetActive(isInventoryOpen);
	}

}
