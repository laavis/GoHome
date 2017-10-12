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
		///
		/// Checks if the player has all items required to move tote next scene.
		///
		bool isReady = true;
		foreach (Item item in requiredItems) {
			if (!GameManager.instance.inventoryData.Contains(item)) {
				isReady = false;
				break;
			}
		}
		///
		/// If the player has all the items needed to proceed to the next scene, change scene
		///
		if (isReady) {
			///
			/// When moving forward (to the right), build the next scene in the build index
			///
			if (direction == Direction.forwards) {

				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointLeft();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			///
			/// One of the two exceptions. Skips one scene (the club)n if player is going to the bus stop
			///
			} else if( direction == Direction.busStop) {
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointLeft();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
			///
			/// Another one of the two exceptions. Skips one scene (the club)n if player is going to the city
			///
			} else if( direction == Direction.city) {
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointRight();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

			} else {
				///
				/// When moving backwards (to the left), build the next scene in the build index
				///
				GameManager.instance.player.GetComponent<PlayerController>().SetStartingPointRight();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			}
		} else {
			///
			/// If the player has not all of the required items to move to the next scene, display dialog that states the player can't proceed
			/// before he has all of the items needed
			///
			notReadyDialog.TriggerDialogue();
		}
	}
}
