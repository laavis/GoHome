using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hosts the all information needed about the text
[System.Serializable]
public class Dialogue {
	
	public string name;
	//TextArea defines the size of the input box in the editor
	//sentences that will be loaded into the Queue
	[TextArea(3, 10)]
	public string[] sentences;
	

}

