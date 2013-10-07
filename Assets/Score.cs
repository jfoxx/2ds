using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 0;
	
	public AudioClip blip;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void collect(int amount){
		score += amount;
		if (blip != null) {
			audio.clip = blip;
			audio.Play();
		}
	}
}
