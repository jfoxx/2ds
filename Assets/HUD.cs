using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	GameObject player;
	public float health;
	public int score;
	Health healthScript;
	Score scoreScript;
	
	public Texture crosshair;
	
	void Start () 
	{
		player = GameObject.Find("Player");
		healthScript = player.GetComponent<Health>();
		scoreScript = player.GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		health = healthScript.health;
		score = scoreScript.score;
	}
	
	void OnGUI()
	{
		GUILayout.Label("Health " + health);
		GUILayout.Label("Score " + score );
	}
	
}
