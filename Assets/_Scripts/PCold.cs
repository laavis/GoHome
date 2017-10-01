using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCold : MonoBehaviour {

	public float maxSpeed = 10f;

	bool facingRight = true;
	Animator anim;
	Rigidbody2D rb2d;
	private static bool playerExists;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float move = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));
		rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
