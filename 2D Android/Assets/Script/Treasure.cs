using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	public AudioClip treasureSound;
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			if(treasureSound)
				AudioSource.PlayClipAtPoint(treasureSound,transform.position);
			Life.air = 10;
			Destroy (gameObject);
		}
	}
}
