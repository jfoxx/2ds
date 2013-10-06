using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	public float speed;
	
	void Start () {
		rigidbody.AddForce(transform.TransformDirection(Vector3.forward * speed),ForceMode.Impulse);
	}
	
	void Update () {
	}
}
