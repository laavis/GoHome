using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {
	public GameObject guiObject;
	//public GameObject guiObjectBack;
	//public string LoadLevel;
	//private bool insideTrigger = false;

	// Use this for initialization
	void Start () {
		guiObject.SetActive (false);
		Vector2 pos = transform.position;
		//guiObjectBack.SetActive (false);
	}

	void Update(){
		if(Input.GetMouseButtonDown(0) && guiObject.activeInHierarchy == true && transform.position.x > 5 /*insideTrigger*/){
			//Debug.Log("Load next scene");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if(Input.GetMouseButtonDown(0) && guiObject.activeInHierarchy == true && transform.position.x < 5 /*insideTrigger*/){
			//Debug.Log("Load next scene");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive (true);
			//guiObjectBack.SetActive (true);
			//insideTrigger = true;
			//Debug.Log("inideTrigger: " + insideTrigger);
			
		}
	}
	void OnTriggerExit2D()
	{
		guiObject.SetActive (false);
		//guiObjectBack.SetActive (false);
		//insideTrigger = false;
		//Debug.Log("inideTrigger: " + insideTrigger);
	}

}
