using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	GameObject player;
	public float health;
	public int score;
	
	void Start () 
	{
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Health healthScript = player.GetComponent<Health>();
		Score scoreScript = player.GetComponent<Score>();
		health = healthScript.health;
		score = scoreScript.score;
	}
	
	void OnGUI()
	{
		GUILayout.Label("Health " + health );
		GUILayout.Label("Score " + score );
	}
}
