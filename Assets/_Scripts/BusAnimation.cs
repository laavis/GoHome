using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAnimation : MonoBehaviour {

	public GameObject bus;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = bus.GetComponent<Animator> ();
		anim.Play("Bus");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
