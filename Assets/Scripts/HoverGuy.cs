using UnityEngine;
using System.Collections;

public class HoverGuy : MonoBehaviour {
    public GameObject originObj1;
    public GameObject originObj2;
    public float mousePitch = 20.0f;
    public float mouseYaw = 0.0f;
    public float scaleDist = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject originObj = originObj1;
        if (originObj == null)
            originObj = originObj2;
        if (originObj == null)
            return;

        mouseYaw = Time.time * 90.0f;

        mousePitch = Mathf.Clamp(mousePitch, -89.0f, 89.0f);
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(-mousePitch, mouseYaw, 0.0f);
        this.transform.position = originObj.transform.position + (rot * Vector3.forward) * scaleDist;
	}
}
