using UnityEngine;
using System.Collections;

public class Event_AllowStart : BaseEvent
{
    public readonly bool m_allowStart;


    /// <summary>
    /// Event data: Starts and stops the game
    /// </summary>
    public Event_AllowStart(bool allowStart)
    {
        m_allowStart = allowStart;
    }


}