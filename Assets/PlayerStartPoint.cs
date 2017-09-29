using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {
	private PlayerController thePlayer;
	public Vector2 startDirection;
	public string pointName;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		if (thePlayer.startPoint == pointName) {
			thePlayer.transform.position = transform.position;
			thePlayer.lastMove = startDirection;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
