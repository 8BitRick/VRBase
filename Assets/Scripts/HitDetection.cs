using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour {

	public Text hitText;
	public Color hitTextColor;
	private Color clearColor;

	void Awake () {
		clearColor = new Color(hitTextColor.r, hitTextColor.g, hitTextColor.b, 0.0F);
		hitText.color = clearColor;
	}


	void OnTriggerEnter(Collider other) {

		hitText.color = hitTextColor;
	}

	void Update() {

		if (hitText.color != clearColor) {
			hitText.color = Color.Lerp(hitText.color, clearColor, Time.deltaTime * 3f);
		}

	}

}
