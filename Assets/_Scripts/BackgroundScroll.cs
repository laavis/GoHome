 using UnityEngine;
 
 public class BackgroundScroll : MonoBehaviour {
	 
    public float speed = 0.5f;

    Transform bg;
    void Start() {
        bg = gameObject.transform;
    }
    void Update() {
        float scrollSpeed = bg.position.y + speed * Time.deltaTime;
        bg.position = new Vector3(bg.position.x, scrollSpeed, bg.position.z);
    }
 }
