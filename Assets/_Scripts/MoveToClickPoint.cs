using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToClickPoint : MonoBehaviour {
	Animator anim;
	private SpriteRenderer playerSpriteRend;
	public Transform player;
	private static bool playerExists;
	private float speed = 10f;
	private Vector2 target;

	public bool isMoving = false;	

	void Start(){
		target = transform.position;
		anim = GetComponent<Animator>();
		playerSpriteRend = GetComponent<SpriteRenderer>();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){
		//Don't move if inventory or text box is active
		if (!GameManager.isPaused){
			Move();
		} 

		//If target position the left side of the player, flip the player so it will be facing towards left
		if(target.x < player.position.x){
			playerSpriteRend.flipX = true;	
		
		}else if(target.x > player.position.x){
			playerSpriteRend.flipX = false;	
		}

		//Play walk animation until the player is reached the target position
		if(isMoving == true && !GameManager.isPaused){
			anim.Play("Walk");
		}else{
			anim.Play("Idle");
		}
	}

	void Move(){
			if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
			
			isMoving = true;
		
			#if UNITY_EDITOR
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			#endif

			target.y = transform.position.y;
			
			//If the player has reached the target position, stop moving. 
			}else if(target.x == player.position.x){
				isMoving = false;
			}
			//Move the player to the target position
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
}

    
