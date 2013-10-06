using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	
	List < Checkpoint > checkpontsRached = new List <Checkpoint> ( );
	public int currentLevel;
	
	void Start ( ) 
	{
		currentLevel = Application.loadedLevel;
	}
	
	void Update ( ) 
	{
	
	}
	
	void checkpointReached( )
	{
		Application.LoadLevel( currentLevel + 1 );
		//show win screen and next and stuff
	}
}
