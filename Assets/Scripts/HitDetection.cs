using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour {

	public Text hitText;
	public Color hitTextColor;

	private Color clearColor;

	void Awake () {

		// Set the "clear color" to be the same as the hitTextColor but with alpha of 0
		clearColor = new Color(hitTextColor.r, hitTextColor.g, hitTextColor.b, 0.0F);
		hitText.color = clearColor;

	}


	void OnTriggerEnter(Collider other) {

		// When a hit is detected, show the text...
		hitText.color = hitTextColor;

		// ...and send an event that stops the game.
		EventManager.Instance.QueueEvent (new Event_GameState (false));
	}


	void Update() {

		// Fade out the text
		if (hitText.color != clearColor) {
			hitText.color = Color.Lerp(hitText.color, clearColor, Time.deltaTime * 3f);
		}

	}

}
