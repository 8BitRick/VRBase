using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour, IEventListener {

	public Text guiText;
	public Color guiTextColor;
	
	private Color clearColor;
	private bool gameIsRunning;
    private bool allowStart = false;

	void Awake () {
		
		// Set the "clear color" to be the same as the guiTextColor but with alpha of 0
		clearColor = new Color(guiTextColor.r, guiTextColor.g, guiTextColor.b, 0.0F);
		guiText.color = clearColor;
		
		// Attach event listeners
		EventManager.Instance.AttachListener (this, "Event_GameState", this.HandleGameState);
        EventManager.Instance.AttachListener(this, "Event_AllowStart", this.HandleAllowStart);
		
	}


	// Update is called once per frame
	void Update () {

		if (!gameIsRunning && allowStart) {
			guiText.color = guiTextColor;
			guiText.text = "Press Space \n to Start";
		} else {
			guiText.color = Color.Lerp(guiText.color, clearColor, Time.deltaTime * 2F);
		}

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
