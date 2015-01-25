using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReporterScript : MonoBehaviour {

	public List<Material> texture = new List<Material>();
	public GameObject body;
	public GameObject head;

	// Use this for initialization
	void Awake () {

		//Pick a random texture
		int random = Random.Range (0, texture.Count);

		body.renderer.material = texture[random];
		head.renderer.material = texture[random];




	}
}
