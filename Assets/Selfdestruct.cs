using UnityEngine;
using System.Collections;

public class Selfdestruct : MonoBehaviour {
	
	public float timer = 10;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
		if (timer <= 0 ) {
			destroy ();
		}
	}
	
	void destroy(){
		Destroy(gameObject);
	}
}
