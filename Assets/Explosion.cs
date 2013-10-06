using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	public float explosionRadius = 5.0f;
	public float explosionPower = 10.0f;
	public float explosionDamage = 100.0f;
	public float explosionTime = 1.0f;
	
	
	void Start () {
		Vector3 explosionPosition = transform.position;
		Collider[] colliders  = Physics.OverlapSphere (explosionPosition, explosionRadius);
		
		foreach (Collider hit in colliders) 
		{
			Vector3 closestPoint = hit.ClosestPointOnBounds(explosionPosition);
        	float distance = Vector3.Distance(closestPoint, explosionPosition);

        	float hitPoints = 1.0f - Mathf.Clamp01(distance / explosionRadius);
        	hitPoints *= explosionDamage;

        	hit.SendMessageUpwards("applyDamage", hitPoints, SendMessageOptions.DontRequireReceiver);
			
			if(hit.rigidbody != null)
			{
				hit.rigidbody.AddExplosionForce(hitPoints * 400, explosionPosition, explosionRadius);
				
			}
		}
	}
}
 
