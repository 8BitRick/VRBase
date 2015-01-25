using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrowdController : MonoBehaviour, IEventListener {

	public GameObject reporterPrefab;
	public List<AudioClip> crowdSounds = new List<AudioClip>();

	private List<GameObject> crowd = new List<GameObject>();
	private Animator anim;
	private float xSpacing = 1.089F;
	private float zSpacing = 1.381F;

	private float pickCrowdRate = 2F;
	private float pickCrowdMember = 5F;
	private bool gameIsRunning;
	private int crowdSoundIndex;
	private int currentCrowdMemberIndex;
	private int previousCrowdMemberIndex = 100;
	int talkHash = Animator.StringToHash("Talk");

	// Use this for initialization
	void Awake () {

		// Attach event listeners
		EventManager.Instance.AttachListener (this, "Event_GameState", this.HandleGameState);

		// Generate the proceedural crowd
		for (int z = 0; z < 4; z++) {
			for (int x = 0; x < 7; x++) {
				GameObject crowdMember = Instantiate(reporterPrefab, reporterPrefab.transform.position, reporterPrefab.transform.rotation) as GameObject;
				crowdMember.transform.position = new Vector3(crowdMember.transform.position.x - xSpacing * x,
				                                             crowdMember.transform.position.y,
				                                             crowdMember.transform.position.z + zSpacing * z);

				// Add each crowd member to the crowd list
				crowd.Add(crowdMember);

			}
		}

	}
	
	// Update is called once per frame
	void Update () {

		// If the current time is greater than the next fire time and the game is running...
		if (Time.time > pickCrowdMember && gameIsRunning) {

			// Reset the timer until the next crowd member is chosen
			pickCrowdMember = Time.time + pickCrowdRate;

			// Stop the previous crowd member from talking
			if (previousCrowdMemberIndex != 100) {
				anim = crowd[previousCrowdMemberIndex].GetComponent<Animator>();
				anim.SetTrigger(talkHash);
			}

			// Pick a new crowd member
			currentCrowdMemberIndex = Random.Range(0, crowd.Count);

			// Play the crowd member animation
			anim = crowd[currentCrowdMemberIndex].GetComponent<Animator>();
			anim.SetTrigger(talkHash);

			crowdSoundIndex = Random.Range(0, crowdSounds.Count);

			// Play crowd member sound
			AudioSource.PlayClipAtPoint(crowdSounds[crowdSoundIndex], crowd[currentCrowdMemberIndex].transform.position);

			previousCrowdMemberIndex = currentCrowdMemberIndex;
			
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

}
