using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour, IEventListener {

	// Allow adjustment of GameObjects (the projectiles) and the fire rate (stored in seconds) through the editor
	public List<GameObject> projectiles = new List<GameObject>();
	public float fireRate = 2F;
	public float velocity = 450F;

	private float nextFire = 5F;
	private int randomObjectIndex;
	private Vector3 newRandomPosition;
	private bool gameIsRunning = false;


	void Awake() {

		// Attach event listeners
		EventManager.Instance.AttachListener (this, "Event_GameState", this.HandleGameState);

		newRandomPosition = transform.position;

	}

	// Use FixedUpdate because there are physics calculations here
	void FixedUpdate() {

		// If the current time is greater than the next fire time and the game is running...
		if (Time.time > nextFire && gameIsRunning) {

			// ...then throw another projectile...
			FireProjectile();

			// ...and randomize the position of the spawner.
			newRandomPosition = new Vector3(Random.Range(-1F, 1F), Random.Range(-0.5F, 0.5F), transform.position.z);

		}


		// ...move the spawner to the new random position.
		transform.position = Vector3.Lerp(transform.position, newRandomPosition, 2F * Time.deltaTime);

	}


	void FireProjectile() {

		// Next fire is the current time plus the fire rate (in seconds)
		nextFire = Time.time + fireRate;

		// Pick a random projectile from the list and create it
		randomObjectIndex = Random.Range(0, projectiles.Count);
		GameObject projectile = Instantiate(projectiles[randomObjectIndex], transform.position, transform.rotation) as GameObject;

		// Add some force and some spin to the projectile
		projectile.rigidbody.AddForce(transform.up * velocity);
		projectile.rigidbody.AddRelativeTorque(Random.Range(500, 1000),
		                                       Random.Range(500, 1000),
		                                       Random.Range(500, 1000));

		// Destroy the game object at the same rate as the fire rate
		Destroy(projectile, fireRate);

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
