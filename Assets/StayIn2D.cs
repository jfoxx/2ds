﻿using UnityEngine;
using System.Collections;

public class StayIn2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z != 0) {
			transform.position = new Vector3(transform.position.x,transform.position.y, 0);
		}
	}
}
