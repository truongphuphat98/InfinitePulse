using UnityEngine;
using System.Collections;

public class explosionPwup : MonoBehaviour {

    ParticleSystem pwup;
    CircleCollider2D player;

	// Use this for initialization
	void Start () {
        pwup = GetComponent<ParticleSystem>();
        
        player = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<CircleCollider2D>();
        pwup.trigger.SetCollider(0, player);      
	}
	
	// Update is called once per frame
	void Update () {

	}
}
