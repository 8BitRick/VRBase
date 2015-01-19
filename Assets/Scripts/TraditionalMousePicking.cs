using UnityEngine;
using System.Collections;

// Just keeping this for reference
// I do not plan on using this in VR because it just doesn't work well

public class TraditionalMousePicking : MonoBehaviour {
    public bool clicking = false;

	// Use this for initialization
	void Start () {
	
	}

    Ray GetMousePickRay()
    {
        Ray pickRay;

        // Check if traditional camera active
        if (Camera.main != null)
        {
            pickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        // Otherwise assume VR cameras
        else
        {
            OVRCameraRig rig = (OVRCameraRig)GameObject.FindObjectOfType(typeof(OVRCameraRig));
            Camera eye = rig.rightEyeAnchor.camera; // Because most people are right-eye dominant.
            Vector3 textureSize = new Vector3(eye.targetTexture.width, eye.targetTexture.height, 1f);
            Vector3 screenSize = new Vector3(Screen.width, Screen.height, 1f);
            Vector3 vrMousePosition = Input.mousePosition;
            vrMousePosition.Scale(textureSize);
            vrMousePosition.Scale(new Vector3(1 / screenSize.x, 1 / screenSize.y, 1 / screenSize.z));
            pickRay = eye.ScreenPointToRay(vrMousePosition);
        }

        return pickRay;
    }

    // Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!clicking)
            {
                Ray pickRay = GetMousePickRay();
                GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                Vector3 target1 = pickRay.origin + pickRay.direction * 5.0f;
                Vector3 target2 = pickRay.origin + pickRay.direction * 10.0f;

                cyl.transform.position = target1;
                cyl.transform.LookAt(target2);
                cyl.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
                cyl.transform.localScale = new Vector3(0.1f, 0.2f, 0.1f);
            }
            clicking = true;
        }
        else
            clicking = false;	
	}
}
