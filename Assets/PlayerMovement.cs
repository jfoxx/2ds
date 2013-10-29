using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
 	public AudioClip jumpSound;
	
	public Transform stickyRestingObject;
	public Transform stickyPointPrefab;
	Transform stickyPrefabInsctance;
	
	public float maxSpeed = 7;
	public float force = 8;
	public float jumpSpeed = 5;
	public float airControll = 0.3f;
	public float controll;
	public Vector3 jumpNormal;
	public float walkFriction = 1.5f; 
	float distToGround;
	public Aim aim;
	public GameObject gunAxis; 
	 
	public int state = 0;
	public bool grounded = false;
	public float jumpLimit = 0;
	
	public Vector3 stickPosition;
	public SpringJoint spring;
	public float stickyTime = 3;
	public float stickyTimer;
	
	
	public bool stickySet = false;
	 
	void Awake ()
	{ 
		rigidbody.freezeRotation = true;
	}
	
	void Start()
	{
		gunAxis = GameObject.Find("GunAxis");

		aim = gunAxis.GetComponent<Aim>();
		
		spring = GetComponent<SpringJoint>();
		distToGround = collider.bounds.extents.y;
		stickyTimer = stickyTime;
		spring.connectedBody = stickyRestingObject.rigidbody;
	}
	 
	bool IsGrounded() 
	{
 		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, 1<<9);
		Debug.DrawRay(transform.position, Vector3.up * 25, Color.red);
	}
 
	public virtual bool jump {
		get {
			return Input.GetButton ("Fire2");
		}
	}
	 
	public virtual float horizontal {
		get {
			return Input.GetAxisRaw ("Horizontal") * force;
		} 
	}

	public virtual float vertical {
		get {
			return Input.GetAxis ("Vertical") * force;
		} 
	}
	
	public virtual bool stickStart {
		get {
			return Input.GetKeyDown (KeyCode.LeftControl);
		} 
	}
	
	public virtual bool stickStay {
		get {
			return Input.GetKey (KeyCode.LeftControl);
		} 
	}
	
	public virtual bool stickExit {
		get {
			return Input.GetKeyUp (KeyCode.LeftControl);
		} 
	}
	
	void Update()
	{
		grounded = IsGrounded();
		
		if (stickStart) 
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, gunAxis.transform.TransformDirection(Vector3.forward),out hit, 1000))
			{
				if (hit.transform.CompareTag("Sticky")) 
				{
					stickPosition = hit.point;
					stickyPrefabInsctance = Instantiate(stickyPointPrefab, hit.point, Quaternion.identity) as Transform;
					stickySet = true;
					
					
				}
				
			}
		}
		
		if (stickExit || stickyTimer <= 0) {
			stickySet = false;
			stickyTimer = stickyTime;
			if (stickyPrefabInsctance != null) {
				Destroy(stickyPrefabInsctance.gameObject);
			}
			
		}
		
		if (stickStay && stickySet) {
			stickyTimer -= Time.deltaTime;
			Debug.DrawLine(transform.position, spring.connectedBody.transform.position, Color.red);
			//spring.connectedBody.transform.position = transform.position;
			
		}
		
		if (!stickySet) 
		{
			//stickPosition = transform.position;
			stickPosition = transform.position;
			
		}
		spring.connectedBody.transform.position = stickPosition;

	}
	
	void FixedUpdate ()
	{
	 	if(!grounded){
			controll = airControll;
		}else{
			controll = 1;
		}
		
		if (transform.position.z!= 0) {
			transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		}
		
		if(horizontal == 0 && grounded)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x / walkFriction, rigidbody.velocity.y, 0);
		}
		
		// If the object is grounded and isn't moving at the max speed or higher apply force to move it
		if (rigidbody.velocity.magnitude < maxSpeed && grounded ) {
			rigidbody.AddForce (transform.rotation * Vector3.right * horizontal);
		}
		
		if (rigidbody.velocity.magnitude < maxSpeed && !grounded ) {
			rigidbody.AddForce (transform.rotation * Vector3.right * horizontal * controll);
			
		}
		
		if (jump && grounded) {
			audio.clip = jumpSound;
			audio.Play();
			rigidbody.velocity = rigidbody.velocity + (Vector3.up * jumpSpeed);
			
		}
	
	}
}
