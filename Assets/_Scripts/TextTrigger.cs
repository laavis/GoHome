﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour {

	public Monologue monologue;

	public void TriggerText(){
		FindObjectOfType<TextManager>().StartMonologue(monologue);
	}
}