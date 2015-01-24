using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour {

	// Allow adjustment of GameObjects (the projectiles) and the fire rate (stored in seconds) through the editor
	public List<GameObject> projectiles = new List<GameObject>();
	public float fireRate = 2F;
	public float velocity = 450F;

	private float nextFire = 0.0F;
	private int randomObjectIndex;
	private Vector3 newRandomPosition;


	// Use FixedUpdate because there are physics calculations here
	void FixedUpdate() {

		// If the current time is greater than the next fire time...
		if (Time.time > nextFire) {
			// ...then throw another projectile...
			FireProjectile();

			// ...and randomize the position of the spawner.
			newRandomPosition = new Vector3(Random.Range(-2F, 2F), Random.Range(-2F, 2F), 0);
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

	
}
