using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

	Camera cam;
	
	float distance;
	
	public virtual float zoom {
		get {
			return Input.GetAxis ("Mouse ScrollWheel");
		} 
	}
	
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (zoom != 0) {
			Debug.Log(zoom);
		}
	}
}
