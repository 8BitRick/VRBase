using UnityEngine;
using System.Collections;

public class Event_PlayerHit : BaseEvent {
	
	
	public readonly bool m_playerHit;
	
	
	/// <summary>
	/// Event data: Sends a message determining if the player has been hit or not
	/// </summary>
	public Event_PlayerHit(bool playerHit) {
		m_playerHit = playerHit;
	}
	
	
}