using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
 	public AudioClip jumpSound;
	
	// These variables are for adjusting in the inspector how the object behaves 
	public float maxSpeed = 7;
	public float force = 8;
	public float jumpSpeed = 5;
	public float airControll = 0.3f;
	public float controll;
	public Vector3 jumpNormal;
	public float walkFriction = 1.5f; 
	float distToGround;
	 
	// These variables are there for use by the script and don't need to be edited
	public int state = 0;
	public bool grounded = false;
	public float jumpLimit = 0;
	
	public Vector3 stickPosition;
	public SpringJoint spring;
	 
	// Don't let the Physics Engine rotate this physics object so it doesn't fall over when running
	void Awake ()
	{ 
		rigidbody.freezeRotation = true;
	}
	void Start()
	{
		spring = GetComponent<SpringJoint>();
		distToGround = collider.bounds.extents.y;
	}
	 
	void OnCollisionEnter (Collision collision)
	{

	}
	
	void OnCollisionStay(Collision collision) 
	{
        foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
			if(contact.normal.y <= 0.6){
				//grounded = false;
			}else{
				//grounded = true;
			}
        }
    }
	
	bool IsGrounded() 
	{
 		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, 1<<9);
		Debug.DrawRay(transform.position, -Vector3.up * 5, Color.red);
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
	
	void Update(){
		grounded = IsGrounded();
		if (stickStart) {
			stickPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);		
			spring.connectedBody.transform.position = stickPosition;
		}
		if (!stickStay) {
			spring.connectedBody.transform.position = transform.position;
		}

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
			//rigidbody.AddForce (transform.rotation * Vector3.forward * vertical);
			rigidbody.AddForce (transform.rotation * Vector3.right * horizontal);
		}
		
		if (rigidbody.velocity.magnitude < maxSpeed && !grounded ) {
			rigidbody.AddForce (transform.rotation * Vector3.right * horizontal * controll);
			//rigidbody.AddForce (transform.rotation * Vector3.right * horizontal * controll);
		}
		
		if (jump && grounded) {
			audio.clip = jumpSound;
			audio.Play();
			rigidbody.velocity = rigidbody.velocity + (Vector3.up * jumpSpeed);
			
		}
	
	}
}
