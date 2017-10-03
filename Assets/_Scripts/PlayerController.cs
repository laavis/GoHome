using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	private Animator anim;
	private SpriteRenderer playerSpriteRend;

	private float speed = 30f;
	private Vector2 target;

	private Vector2 startPosRight;
	private Vector2 startPosLeft;

	private static bool playerExists;
	public bool isMoving = false;
	public bool levelWasLoaded = true;

	public Transform playerTransform;
	public LayerMask itemLayer;

	void Start(){
		startPosRight = new Vector2 (18.0f, -4.0f);
		startPosLeft = new Vector2 (-18.0f, -4.0f);
		
		target = transform.position;
		anim = GetComponent<Animator>();
		playerSpriteRend = GetComponent<SpriteRenderer>();

		// If the player exists, don't destroy the gameObject when the scene changes
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		}
	}

	void Update(){
		// If target position the left side of the player, flip the player so it will be facing towards left
		if (!GameManager.isPaused && Mathf.Abs(target.x - playerTransform.position.x) > 0.05f) {
			if(target.x < playerTransform.position.x){
				playerSpriteRend.flipX = true;	
			
			} else {
				playerSpriteRend.flipX = false;	
			} 
		}
		// Detect collision with item's collider
		Collider2D coll = Physics2D.OverlapCircle(playerTransform.transform.position, 2f, itemLayer);
		Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// If the player clicks the item or presses it (android) and the item is within range, 
		// pick up the item by calling CollectItem from ItemPickup.cs
		if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
			&& coll != null && Vector2.Distance(mouse, playerTransform.transform.position) < 7f) {
			coll.GetComponent<ItemPickup>().CollectItem();
		}
	}

	void FixedUpdate(){
		//Don't move if inventory or text box is active
		if (!GameManager.isPaused){
			Move();
		// If (in this case) inventory is opened, set the players destination target to it's current position
		// In other words, stop moving 
		}else if(isMoving == true && GameManager.isPaused){
			isMoving = false;
			target = playerTransform.transform.position;
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
			// Character is moving
			isMoving = true;
		
			#if UNITY_EDITOR
			// Get the destination target by clicking somewhere in screen
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			// Does the same as line above but on android
			target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			#endif

			target.y = transform.position.y;
			
			//If the player has reached the target position, stop moving. 
			}else if(target.x == playerTransform.position.x){
				isMoving = false;
			}
			//Move the player to the target position
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, 2f);
	}
	public void SetStartingPointRight(){
		// Reset the player's position to coordinates given in startPos
		playerTransform.transform.position = startPosRight;
		target = playerTransform.transform.position;
	}
	public void SetStartingPointLeft(){
		// Reset the player's position to coordinates given in startPos
		playerTransform.transform.position = startPosLeft;
		target = playerTransform.transform.position;
	}
}

    
