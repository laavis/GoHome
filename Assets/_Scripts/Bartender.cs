using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : Clickable {
	public DialogueTrigger speakDialog;

	public GameObject wallet;
	public GameObject phone;
	
	public void Start() {
		if (GameManager.instance.hasTalkedToBartender && !GameManager.instance.inventoryData.Contains(wallet.GetComponent<ItemPickup>().item)) {
			wallet.SetActive(true);
			phone.SetActive(true);
		} else {
			wallet.SetActive(false);
			phone.SetActive(false);
		}
	}

	public override void OnClick() {
		if (!GameManager.instance.hasTalkedToBartender) {
			speakDialog.TriggerDialogue();
			GameManager.instance.hasTalkedToBartender = true;

			wallet.SetActive(true);
			phone.SetActive(true);
		}
	}
}
