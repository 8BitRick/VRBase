using UnityEngine;
using System.Collections;

public class Event_GameState : BaseEvent {
	
	
	public readonly bool m_gameState;
	
	
	/// <summary>
	/// Event data: Starts and stops the game
	/// </summary>
	public Event_GameState(bool gameState) {
		m_gameState = gameState;
	}
	
	
}