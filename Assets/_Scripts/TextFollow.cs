using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour {

	public Image textBox;
	
	// Update is called once per frame
	void Update () {
		Vector2 textBoxPos = Camera.main.WorldToScreenPoint(this.transform.position);
		if (textBox != null) textBox.transform.position = textBoxPos;
	}
}
