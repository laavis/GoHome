using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction {
	forwards, backwards, busStop, city
}

public class GameSceneManager : Clickable {
	public Direction direction;
	public Item[] requiredItems;
	public DialogueTrigger notReadyDialog;

	public override void OnClick() {
		Debug.Log(gameObject.name);

		bool isReady = true;
		foreach (Item item in requiredItems) {
			if (!GameManager.instance.inventoryData.Contains(item)) {
				isReady = false;
				break;
			}
		}

		if (isReady) {
			if (direction == Direction.forwards) {
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointLeft();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

			} else if( direction == Direction.busStop) {
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointLeft();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

			} else if( direction == Direction.city) {
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointRight();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
			} else {

				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointRight();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			}
		} else {
			notReadyDialog.TriggerDialogue();
		}
	}
}
