using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour {




	void Update() {

		// Game start and restart logic goes here

		// Reset Oculus orientation
		if (Input.GetKeyDown(KeyCode.Space))
			OVRManager.display.RecenterPose();

	}

}
