using UnityEngine;
using System.Collections;

public class PlayerSub : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3,5);
	private bool standing;
	public float subSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	
	private Animator animator;
	private PlayerSubController controller;
	
	void Start(){
		animator = GetComponent<Animator> ();
		controller = GetComponent<PlayerSubController> ();
	}

	void OnCollisionEnter2D(Collision2D target){
		if (!standing) {
			var absVelX = Mathf.Abs(rigidbody2D.velocity.x);
			var absVelY = Mathf.Abs(rigidbody2D.velocity.y);
		}
	}
	
	void Update () {
		var forceX = 0f;
		var forceY = 0f;
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
		
		if (absVelY < .2f) {
			standing = true;	
		} else {
			standing = false;
		}

		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}	
		} 
		
		if (controller.moving.y > 0) {
			
			if (absVelY < maxVelocity.y)
				forceY = subSpeed * controller.moving.y;
		} 
		
		rigidbody2D.AddForce(new Vector2(forceX,forceY));
	}
}
