using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public GameObject player;
	public Texture btnTexture;
	
	void OnGUI() {

		if (Life.air < 0) {
			GUI.RepeatButton (new Rect (0, 0, 0, 0), btnTexture);
		} else {
			if (GUI.RepeatButton (new Rect (Screen.width * 0.1f, Screen.height * 0.8f, 50, 50), btnTexture)) {
				player.transform.position += Vector3.left * Time.deltaTime;
				player.transform.rotation = Quaternion.Euler(0, 180, 0);
			}

			if (GUI.RepeatButton (new Rect (Screen.width * 0.2f, Screen.height * 0.8f, 50, 50), btnTexture)) {
				player.transform.position += Vector3.right * Time.deltaTime;
				player.transform.rotation = Quaternion.Euler(0, 0, 0);

			}

			if (GUI.RepeatButton (new Rect (Screen.width * 0.8f, Screen.height * 0.65f, 50, 50), btnTexture))
					player.transform.position += Vector3.up * Time.deltaTime;

			if (GUI.RepeatButton (new Rect (Screen.width * 0.8f, Screen.height * 0.8f, 50, 50), btnTexture))
				player.transform.position += Vector3.down * Time.deltaTime;

		}	
	}
}
