using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour {
    public GameObject originObj;
    public GameObject targetObj;
    public GameObject laserBall;
    public Vector3 offset = new Vector3(0.5f, 0.75f, 0.0f);
    public AudioSource shootingSound;
    public AudioSource explosionSoundSource;
    public bool clicking = false;

	// Use this for initialization
	void Start () {
	
	}

    Ray GetMousePickRay()
    {
        if (originObj != null && targetObj != null)
        {
            Vector3 shootingDir = targetObj.transform.position - originObj.transform.position;
            return new Ray(originObj.transform.position + offset, shootingDir.normalized);
        }

        return new Ray(Vector3.zero, Vector3.up);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!clicking)
            {
                Ray pickRay = GetMousePickRay();
                Object lbInstance = Instantiate(laserBall, pickRay.origin, Quaternion.LookRotation(pickRay.direction));
                //GameObject lb = (GameObject)lbInstance;
                //lb.
                shootingSound.Play();
            }
            clicking = true;
        }
        else
            clicking = false;
    }
}
