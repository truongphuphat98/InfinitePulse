using UnityEngine;
using System.Collections;

public class PulsarRotation : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
	if (gameObject.name == "1")
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 10);
        }
        if (gameObject.name == "2")
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 20);
        }
        if (gameObject.name == "3")
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 30);
        }
        if (gameObject.name == "4")
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 40);
        }
    }
}
