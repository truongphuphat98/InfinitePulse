using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeMessage : MonoBehaviour {

    float time = 0;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.activeInHierarchy == true)
            time += Time.deltaTime;

        if (time >= 5f )
        {
            gameObject.SetActive(false);
            time = 0;
        }
	}
}
