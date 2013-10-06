using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	public CheckPointType type;
	GameObject gameManager;
	
	void Start ( )
	{
		gameManager = GameObject.Find( "GameManager" );
	}
	
	void OnTriggerEnter ( Collider other ) 
	{
		if( other.transform.CompareTag( "Player" ) )
		{
			gameManager.SendMessage ( "checkpointReached", ( int ) type, SendMessageOptions.DontRequireReceiver );
		}
	}
	
}

