using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	
	public int amount = 1;
	
 	void OnTriggerEnter(Collider other) 
	{
		if(other.transform.CompareTag("Player"))
		{
			other.transform.SendMessage("collect", amount, SendMessageOptions.DontRequireReceiver);
    	    Destroy(gameObject);
		}
	}
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
}
