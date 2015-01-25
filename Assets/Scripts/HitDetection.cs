using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour {

	// When a hit is detected...
	void OnTriggerEnter(Collider other) {

		// Send an event that stops the game.
		EventManager.Instance.QueueEvent (new Event_GameState (false));
        EventManager.Instance.QueueEvent(new Event_AllowStart(false));

	}

}
