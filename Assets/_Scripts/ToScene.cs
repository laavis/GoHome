using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {
	public GameObject guiObjectFor;
	//public GameObject guiObjectBack;
	//public string LoadLevel;
	//private bool insideTrigger = false;

	// Use this for initialization
	void Start () {
		guiObjectFor.SetActive (false);
		//guiObjectBack.SetActive (false);
	}

	void Update(){
		if(Input.GetMouseButtonDown(0) && guiObjectFor.activeInHierarchy == true /*insideTrigger*/){
			//Debug.Log("Load next scene");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		/*if(Input.GetMouseButtonDown(0) && guiObjectBack.activeInHierarchy == true insideTrigger){
			//Debug.Log("Load next scene");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		*/
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			guiObjectFor.SetActive (true);
			//guiObjectBack.SetActive (true);
			//insideTrigger = true;
			//Debug.Log("inideTrigger: " + insideTrigger);
			
		}
	}
	void OnTriggerExit2D()
	{
		guiObjectFor.SetActive (false);
		//guiObjectBack.SetActive (false);
		//insideTrigger = false;
		//Debug.Log("inideTrigger: " + insideTrigger);
	}

}
