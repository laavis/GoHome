using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAnimation : Clickable {
	public GameObject bus;
	Animator anim;

	// Use this for initialization
	public override void OnClick () {
		anim = bus.GetComponent<Animator> ();
		anim.Play("Bus");
		GameManager.instance.isWaitingForBus = true;
		GameManager.instance.player.GetComponent<PlayerController>().Remove(2.2f);
		StartCoroutine(GameManager.instance.ToggleEndSreen());
	}
}
