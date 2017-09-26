using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToClickPoint : MonoBehaviour {

	private float speed = 5f;
	private Vector2 target;

	void Start(){
		target = transform.position;
	}

	void FixedUpdate(){
		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if(Input.GetMouseButtonDown(0) || Input.touchCount > 0 &&Input.GetTouch(0).phase == TouchPhase.Began) {

			#if UNITY_EDITOR
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			#endif

			target.y = transform.position.y;
		}
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
}
    
