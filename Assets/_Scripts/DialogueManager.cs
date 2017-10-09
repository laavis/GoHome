using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	
	//Stores sentences to Queue
	private Queue<string> sentences;

	void Start () {
		//Initialize Queue
		sentences = new Queue<string>();
	}
	public void StartDialogue(Dialogue dialogue){
		
		Debug.Log("Starting conversation with " + dialogue.name);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	public void DisplayNextSentence(){
		//end text if all the sentences have been displayed
		if(sentences.Count == 0){
			
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}
	IEnumerator TypeSentence(string sentence){
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray()){
			dialogueText.text += letter; 
			yield return null;
		}
	}
	public void EndDialogue(){
		Debug.Log("End of the text");
		GameManager.instance.ToggleTextBox();
	}
}
