using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour {

	public Vector3 offset;

	void Update () {
		this.transform.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position) + offset;
	}
}
