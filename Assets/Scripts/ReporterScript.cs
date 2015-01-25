using UnityEngine;
using System.Collections;

public class ReporterScript : MonoBehaviour {

	Animator anim;
	int talkHash = Animator.StringToHash("Talk");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			anim.SetTrigger(talkHash);
		}
	}
}
