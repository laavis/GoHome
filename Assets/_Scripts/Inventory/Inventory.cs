﻿using System.Collections;
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

		} else if(instance != this){
			Debug.Log("More than one insance of Inventory found!");
			
		}
	}
	//--------------------------------------------------------------

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public GameObject inventoryGameObject;
	public int space = 12;
	public List<Item> inventoryItems = new List<Item> ();

	public bool gameStart = true;
	
	void Start(){
		inventoryItems = Data.instance.inventoryData;
	}
	
	void LateUpdate(){
		if(gameStart && inventoryGameObject.activeSelf == true){
			inventoryGameObject.SetActive(false);
			gameStart = false;
		}
	}

	public void Add(Item item){
		inventoryItems.Add(item);
		
		if(onItemChangedCallback != null)
			onItemChangedCallback.Invoke();

		if(onItemChangedCallback == null)
			Debug.Log("onItemChangedCallback = null");
	}

}
