using UnityEngine;
using System.Collections;

public class MousePicker : MonoBehaviour {
    public GameObject originObj;
    public GameObject pickingObj;
    public float mousePitch;
    public float mouseYaw;
    public float scaleDist = 5.0f;
    public float mouseYawScale = 1.0f;
    public float mousePitchScale = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (originObj != null && pickingObj != null)
        {
            Vector3 deltaMousePos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

            mousePitch += deltaMousePos.y * mousePitchScale;
            mouseYaw += deltaMousePos.x * mouseYawScale;

            mousePitch = Mathf.Clamp(mousePitch, -89.0f, 89.0f);
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(-mousePitch, mouseYaw, 0.0f);
            pickingObj.transform.position = originObj.transform.position + (rot * Vector3.forward) * scaleDist;
        }
	}
}
