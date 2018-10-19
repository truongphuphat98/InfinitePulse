using UnityEngine;
using System.Collections;

public class MouseOverZone : MonoBehaviour {

    PlayerTuto zoneCheck;

    void Start()
    {
        zoneCheck = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<PlayerTuto>();        
    }

    void OnMouseEnter()
    {
        zoneCheck.mouseOverZone = true;
    }
	
    void OnMouseExit()
    {
        zoneCheck.mouseOverZone = false;
    }
}
