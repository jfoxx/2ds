﻿using UnityEngine;
using System.Collections;

public class debug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
