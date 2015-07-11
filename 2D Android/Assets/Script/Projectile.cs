using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D target){
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			var explode = target.GetComponent<Explosion> () as Explosion;
			explode.OnExplode ();
		}
	}
}
