using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour, IEventListener {

	private bool gameIsRunning;
    public bool allowStart = false;
    public PlayMakerFSM gameFlowFSM;

    public void StartGame(bool canStart)
    {
        EventManager.Instance.QueueEvent(new Event_AllowStart(true));
    }
	

	void Awake() {

		// Attach event listeners
		EventManager.Instance.AttachListener (this, "Event_GameState", this.HandleGameState);
        EventManager.Instance.AttachListener(this, "Event_AllowStart", this.HandleAllowStart);

	}

	void Update() {

		// Game start and restart logic goes here
        if (Input.GetKeyDown(KeyCode.Space) && !gameIsRunning && allowStart)
        {
			gameIsRunning = true;
            allowStart = false;
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

        if (!gameIsRunning)
        {
            gameFlowFSM.FsmVariables.GetFsmBool("GameOver").Value = true;
        }
		
		// Returning false allows this event to propogate to other listeners
		return false;
		
	}

    /// <summary>
    /// Event handler: Gets the allow Start.
    /// </summary>
    public bool HandleAllowStart(IEvent evt)
    {
        Event_AllowStart castEvent = evt as Event_AllowStart;

        // Set the current game state
        allowStart = castEvent.m_allowStart;

        // Returning false allows this event to propogate to other listeners
        return false;
    }

}
