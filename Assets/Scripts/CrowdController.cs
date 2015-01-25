using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrowdController : MonoBehaviour {

	public GameObject reporterPrefab;

	private List<GameObject> crowd = new List<GameObject>();
	private Animator anim;
	private float xSpacing = 1.089F;
	private float zSpacing = 1.381F;

	// Use this for initialization
	void Awake () {

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

	}
}
