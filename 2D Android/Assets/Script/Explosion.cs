using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class Explosion : MonoBehaviour {

	public SubParts subParts;
	public int totalParts = 8;
	private const int counterReset = 3;
	public static int counterForAds = counterReset;

	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("37032", false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode();		
		}
	}
	
	public void OnExplode(){
		Destroy (gameObject);
		
		var t = transform;
		
		for (int i = 0; i < totalParts; i++) {
			t.TransformPoint(0, -100,0);
			SubParts clone = Instantiate(subParts, t.position, Quaternion.identity) as SubParts;
			clone.rigidbody2D.AddForce(Vector3.right*Random.Range(-50,50));
			clone.rigidbody2D.AddForce(Vector3.up * Random.Range(100,400));
		}

		counterForAds--;

		if (counterForAds <= 0) {
			resetCounter();
			Advertisement.Show(null, new ShowOptions{
				pause = true,
				resultCallback = result => {

				}
			});
		}

		GameObject go = new GameObject ("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue> ();
		script.scene = Application.loadedLevelName;
		go.AddComponent<DisplayRestartText> ();
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode();		
		}
	}

	public static void resetCounter() {
		counterForAds = counterReset;
	}
}
