using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour {
	public GameObject guiObject;
	public GameObject Player;
	//public float pX;
	//public float pY;
	//public GameObject guiObjectBack;
	//public string LoadLevel;
	//private bool insideTrigger = false;
	// Use this for initialization
	void Start () {
		guiObject.SetActive (false);
		/*if (PlayerPrefs.GetInt ("Saved") == 1) {
			PlayerPrefs.GetFloat ("p_x");
			PlayerPrefs.GetFloat ("p_y");

			transform.position = new Vector2 (pX, pY);
			PlayerPrefs.SetInt ("Saved", 0);
			PlayerPrefs.Save ();
			Debug.Log ("position saved");
		}*/
		//Vector2 pos = transform.position;
		//guiObjectBack.SetActive (false);
	}

	void Update(){
		if(Input.GetMouseButtonDown(0) && guiObject.activeInHierarchy == true && transform.position.x > 5 /*insideTrigger*/){
			//Debug.Log("Load next scene");
			Data.instance.SaveData();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if(Input.GetMouseButtonDown(0) && guiObject.activeInHierarchy == true && transform.position.x < 5 /*insideTrigger*/){
			//Debug.Log("Load next scene");
			Data.instance.SaveData();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			gameObject.tag = "Player";
			transform.position = new Vector2 (4.0f, -1.85f);

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive (true);
			/*if (transform.position.x < 5) {
				other.transform.position = new Vector2 (4.0f, -1.85f);
			}*/
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
