 using UnityEngine;
 
 public class BackgroundScroll : MonoBehaviour {
	 
 public float speed;

 void Update () {
        ///
        /// Scroll the main menu background vertically at certain speed
        ///
        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
 }
