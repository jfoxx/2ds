using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	List < Checkpoint > checkpontsRached = new List < Checkpoint > ( );
	GameObject player;
	public int currentLevel;
	
	void Start ( ) 
	{
		currentLevel = Application.loadedLevel;
		player = GameObject.Find("Player");
	}
	
	void Update ( ) 
	{
		if (player == null) {
			
		}
	}
	
	void checkpointReached( int type )
	{
		if ( ( CheckPointType ) type == CheckPointType.Start ) {
			CP_Start ( );
		}
		if ( ( CheckPointType ) type == CheckPointType.Checkpoint ) {
			CP_Checkpoint ( );
		}
		if ( ( CheckPointType ) type == CheckPointType.Finish ) {
			CP_Finish ( );
		}
	}
	
	void CP_Finish ( )
	{
		//show win screen and next and stuff
		Application.LoadLevel( currentLevel + 1);
	}
	
	void CP_Start ( )
	{
		
	}
	
	void CP_Checkpoint ( )
	{
		
	}
}
