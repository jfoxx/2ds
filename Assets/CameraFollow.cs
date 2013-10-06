using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	Vector3 targetPosition;
	
	void Start () {
		targetPosition = transform.position;
	}
	
	void FixedUpdate () {
		if (target != null) {
			
			targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 1, -13);
			transform.LookAt(target.transform);
				//transform.LookAt(player);
		}else{
			Debug.Log("Player is null in LookAt");
		}
		if(targetPosition != transform.position){
			transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
		}
		
	}
}
