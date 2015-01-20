using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour {

    public GameObject myLight;

	// Use this for initialization
	void Start () {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Rigidbody>();
                cube.tag = "ENEMY";
                cube.transform.position = new Vector3(x, y, 0);
            }
        }

        myLight = new GameObject("My Light");
        myLight.AddComponent<Light>();
        myLight.light.color = Color.green;
        myLight.transform.position = new Vector3(1, 1, -6);
	}
	
	// Update is called once per frame
	void Update () {
        System.Converter<float, Vector3> posy = (newy) => new Vector3(myLight.transform.position.x, newy, myLight.transform.position.z);
        myLight.transform.position = posy(Mathf.Sin(Time.time * 2) * 2 + 5.0f);
        myLight.light.intensity = (0.5f + ((Mathf.Sin(Time.time * 2.0f)*0.5f+0.5f) * 0.2f));// +3.0f;
	}
}
