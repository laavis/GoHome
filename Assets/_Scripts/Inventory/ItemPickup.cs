﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

	public Item item;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Debug.Log("Collided with " + other.tag);
			Debug.Log("Picking up " + item.name);
			Debug.Log("Item description: " + item.description);
			Inventory.instance.Add(item);
			Destroy(gameObject);
		}
	}

}
