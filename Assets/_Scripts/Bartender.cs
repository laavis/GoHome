using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : Clickable {
	public DialogueTrigger speakDialog;

	public GameObject wallet;
	public GameObject phone;
	
	public void Start() {
		///
		/// Checks if the player has taked the items given
		/// Keep items visible as until the player collects them
		///
		if (GameManager.instance.hasTalkedToBartender && !GameManager.instance.inventoryData.Contains(wallet.GetComponent<ItemPickup>().item)) {
			wallet.SetActive(true);
			phone.SetActive(true);
		} else {
			wallet.SetActive(false);
			phone.SetActive(false);
		}
	}
	///
	/// Triggers bartenders dialog when the player speaks to him for the first time
	/// When speaking to the bartender at the first time, he spawns two items on the table
	///
	public override void OnClick() {
		if (!GameManager.instance.hasTalkedToBartender) {
			speakDialog.TriggerDialogue();
			GameManager.instance.hasTalkedToBartender = true;

			wallet.SetActive(true);
			phone.SetActive(true);
		}
	}
}

