using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour, IEventListener {

	private bool gameIsRunning;

	void Update() {

		// Game start and restart logic goes here
		if (Input.GetKeyDown(KeyCode.Space) && !gameIsRunning) {
			gameIsRunning = true;
			EventManager.Instance.QueueEvent (new Event_GameState (gameIsRunning));
		}


		// Reset Oculus orientation
		if (Input.GetKeyDown(KeyCode.Space))
			OVRManager.display.RecenterPose();

	}


	/// <summary>
	/// Event handler: Gets the current game state.
	/// </summary>
	public bool HandleGameState(IEvent evt) {
		
		Event_GameState castEvent = evt as Event_GameState;
		
		// Set the current game state
		gameIsRunning = castEvent.m_gameState;
		
		// Returning false allows this event to propogate to other listeners
		return false;
		
	}

}
