using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Transform bullet;
	public float fireRate = 0.6f;
	float timer;
	// Use this for initialization
	void Start () {
		timer = fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
		
		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			if (timer <= 0) {
				shoot(bullet);
				timer = fireRate;
			}
		}
	}
	
	void shoot(Transform myBullet){
		if (myBullet != null) {
			audio.PlayOneShot(audio.clip);
			Instantiate(myBullet, transform.position, transform.rotation);
		}
	}
}
