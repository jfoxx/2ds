using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
 	void OnCollisionStay(Collision collisionInfo) {
        foreach (ContactPoint contact in collisionInfo.contacts) {
            contact.otherCollider.SendMessage("onKillZone", SendMessageOptions.DontRequireReceiver);
        }
    }
}
