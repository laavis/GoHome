 using UnityEngine;
 using System.Collections;
 
 public class BackgroundScroll : MonoBehaviour {
	 
     public float scrollSpeed = 0.5F;
     public Renderer rend;
     void Start() {
         rend = GetComponent<Renderer>();
     }
     void Update() {
         float offset = Time.time * scrollSpeed;
         rend.material.SetTextureOffset("MainMenu_bg", new Vector2(offset, 0));
     }
 }
