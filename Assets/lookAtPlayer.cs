using UnityEngine;
using System.Collections;

public class lookAtPlayer : MonoBehaviour {

	public GameObject player;
	
	void Start () {
		player = GameObject.Find("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform);
	}
}
