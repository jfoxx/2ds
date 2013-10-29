using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	
	Vector3 target;
	public float raycastDist = 10;
	public RaycastHit hit;
	public Transform playerObject;
	public float distanceFromPlayer;
	void Start () {
		
	}
	
	
	void Update () 
	{	
		float camX = Input.mousePosition.x;
		float camY = Input.mousePosition.y;
		float camZ = Input.mousePosition.z;
		
		distanceFromPlayer = Vector3.Distance( Camera.main.transform.position, playerObject.transform.position);
		Vector3 target = Camera.main.ScreenToWorldPoint (new Vector3 (camX, camY, distanceFromPlayer) );
		Vector3 mytarget = new Vector3(target.x, target.y, 0);
		transform.LookAt(mytarget);

	}
	
	void OnGUI()
	{
		
	}
	
}

