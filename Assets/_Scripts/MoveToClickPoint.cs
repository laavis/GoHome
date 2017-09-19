using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClickPoint : MonoBehaviour {

		//flag to check if player has clicked
		//set to true on click and back to false when player reaches its destination
		private bool _flag = false;

		//destination point
		private Vector2 _endPoint;

		//player speed
		public float speed = 50.0f;
		
		//horizontal position of the player
		private float xAxis;

		void Start(){
			//save starting position to xAxis
			xAxis = gameObject.transform.position.x;
		}

		void Update(){

			//check if screen is clicked
			if(Input.GetMouseButtonDown(0)){
				Debug.Log("mouse button pressed");
				//declara a variable of RaycastHit struct
				RaycastHit hit;
				Debug.Log("raycast : hit");
				//create a ray on the clicked position
				Ray ray;
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Debug.Log("camera position");

				if(Physics.Raycast(ray, out hit)) {
					_flag = true;
					_endPoint = hit.point;
					
					_endPoint.x = xAxis;
					Debug.Log(_endPoint);
				}
			}
			if(_flag && !Mathf.Approximately(gameObject.transform.position.magnitude, _endPoint.magnitude)){
				gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, _endPoint, 1/(speed * (Vector2.Distance(gameObject.transform.position, _endPoint))));
			
			}else if(_flag && Mathf.Approximately(gameObject.transform.position.magnitude, _endPoint.magnitude)) {
   					_flag = false;
   					Debug.Log("I am here");
 		}
	}
}
    
