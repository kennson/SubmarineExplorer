using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	public float attackDelay = 3f;
	public Projectile projectile;
	
	void Start () {
		
		if (attackDelay > 0) {
			StartCoroutine(OnAttack());		
		}
	}
	
	IEnumerator OnAttack(){
		yield return new WaitForSeconds(attackDelay);
		Fire ();
		StartCoroutine (OnAttack ());
	}
	
	void Fire(){
		OnShoot ();
	}
	
	void OnShoot(){
		if (projectile) {
			Projectile clone = Instantiate(projectile, transform.position, Quaternion.identity) as Projectile;		
		}
	}
}
