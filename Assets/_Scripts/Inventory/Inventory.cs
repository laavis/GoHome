using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//--------------------------------------------------------------
	//Singleton method
	public static Inventory instance;

	void Awake(){
		if(instance == null){
			instance = this;
			// This is already handled in the GameManager.cs
			// Canvas which contains the Inventory is a child of the GameManager, 
			// so DontDestroyOnLoad doesn't need to be called in this script.
			//GameObject.DontDestroyOnLoad(this.gameObject);

		} else if(instance != this){
			Debug.Log("More than one insance of Inventory found!");
			
		}
	}
	//--------------------------------------------------------------

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	//public GameObject inventoryGameObject;
	public int space = 12;
	public List<Item> inventoryItems = new List<Item> ();
	
	void Start(){
		inventoryItems = Data.instance.inventoryData;
		//inventoryGameObject.SetActive(false);
	}
	
	public void Add(Item item){
		inventoryItems.Add(item);
		
		if(onItemChangedCallback != null)
			onItemChangedCallback.Invoke();

		if(onItemChangedCallback == null)
			Debug.Log("onItemChangedCallback = null");
	}

}
