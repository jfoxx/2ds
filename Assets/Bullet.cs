using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public Transform explosion;
	public float soundPauseTime = 2;
	private float soundTimer = 0; 
	
	RaycastHit hit;
	void Start ()
	{
		
	}
	
	void Update () {
		Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 2));
		Debug.DrawRay(ray.origin, ray.direction);
		if(Physics.Raycast(ray, out hit)){
			//Destroy(gameObject);
		}
		
		if (Input.GetKeyUp(KeyCode.LeftControl)) {
			Destroy(gameObject);
		}
		
		if (soundTimer <= 0) {
			audio.Play();
			soundTimer = soundPauseTime;
		}
		if (soundTimer > 0) {
			soundTimer -= Time.deltaTime;
		}
		
	}
	
	void OnDestroy() {
        print("bullet was Destroyed destroyed");
		explode(transform.position);
    }
	
	void explode(Vector3 pos){
		if(explosion != null){
			Instantiate(explosion, pos, Quaternion.LookRotation(hit.normal));
		}
	}
	
}
