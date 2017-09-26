using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public Text playerText;
	//Stores sentences to Queue
	private Queue<string> sentences;

	void Start () {
		//Initialize Queue
		sentences = new Queue<string>();
	}
	public void StartMonologue(Monologue monologue){

		Debug.Log("Starting conversation with");

		sentences.Clear();

		foreach(string sentence in monologue.sentences){
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	public void DisplayNextSentence(){
		//end text if all the sentences have been displayed
		if(sentences.Count == 0){
			
			EndMonologue();
			return;
		}
		string sentence = sentences.Dequeue();
		playerText.text = sentence;
	}
	void EndMonologue(){
		Debug.Log("End of the text");
	}
}
