using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {
	public GameObject guiObject;
	public string LoadLevel;

	// Use this for initialization
	void Start () {
		guiObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") 
		{
			
			guiObject.SetActive (true);

			if (guiObject.activeInHierarchy == true && Input.GetMouseButtonDown (0)) {
				Debug.Log ("pressed mouse button, load scene");
				SceneManager.LoadScene (LoadLevel);
				Debug.Log ("scene loaded");
			}
		}
	}
	void OnTriggerExit()
	{
		guiObject.SetActive (false);
	}

}
