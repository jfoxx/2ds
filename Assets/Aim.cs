using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	
	Vector3 target;
	public float raycastDist = 10;
	public RaycastHit hit;
	public Transform playerObject;
	public float distanceFromPlayer;
	public float sensitivity = 6f;
	public bool mouseAim = false;
	public float mouseMovementIdleTime = 1;
	public float mouseTimer;
	
	public virtual float vertical {
		get {
			return Input.GetAxis ("Vertical");
		} 
	}
	
	public virtual float horizontal {
		get {
			return Input.GetAxisRaw ("Horizontal");
		} 
	}
	
	public virtual bool mouseMovement {
		get {
			return Input.GetAxis ("Mouse X") > 0 || Input.GetAxis ("Mouse Y") > 0;
		} 
	}
	void Start () {
		
	}

	void Update () 
	{	
		if (mouseMovement) {
			mouseTimer = mouseMovementIdleTime;
		}else{
			mouseTimer -= Time.deltaTime;
		}
		
		mouseAim = mouseTimer > 0;
		
		if (mouseAim) 
		{
			float camX = Input.mousePosition.x;
			float camY = Input.mousePosition.y;
			float camZ = Input.mousePosition.z;
			
			distanceFromPlayer = Vector3.Distance( Camera.main.transform.position, playerObject.transform.position);
			Vector3 target = Camera.main.ScreenToWorldPoint (new Vector3 (camX, camY, distanceFromPlayer) );
			Vector3 mytarget = new Vector3(target.x, target.y, 0);
			transform.LookAt(mytarget);
		}
		else
		{
			if(vertical != 0)
			{	
				if (transform.localEulerAngles.z > 0) {
					transform.Rotate(vertical * sensitivity * 30 * Time.deltaTime, 0, 0);
				}else{
					transform.Rotate(vertical * -sensitivity * 30 * Time.deltaTime, 0, 0);
									}
				
				Debug.Log(transform.rotation.x);
			}
			if(horizontal < 0)
			{
				transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 270, 0);
			}
			if(horizontal > 0)
			{
				transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 90, 0);
			}
			
			
		}
	
	}
	
	void OnGUI()
	{
		
	}
	
}

