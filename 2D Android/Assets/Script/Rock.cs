using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
				var explode = target.GetComponent<Explosion>() as Explosion;
				explode.OnExplode();
		} 
	}
}
