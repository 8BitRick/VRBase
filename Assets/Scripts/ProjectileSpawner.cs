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

	// Use FixedUpdate because there are physics calculations here
	void FixedUpdate() {

		// If the current time is greater than the next fire time, then throw another projectile at the player
		if (Time.time > nextFire)
			FireProjectile();

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

	}
	
}
