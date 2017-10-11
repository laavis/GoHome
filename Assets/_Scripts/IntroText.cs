using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour {

	public Text introText;

	[TextArea(10, 50)]
	public string sentencesIntro;

	public bool isFinished = false;
    void Start () {

        StartCoroutine(DisplayIntro());
    }

	private IEnumerator DisplayIntro(){
		foreach(char letter in sentencesIntro.ToCharArray()){
			introText.text += letter;
			yield return null;
		}
		isFinished = true;
	}


	public void StartGame ()
	{
		// Load GameManager
		if (GameManager.instance != null) GameManager.instance.Load();

		SceneManager.LoadScene("scene_1");
	}
}
