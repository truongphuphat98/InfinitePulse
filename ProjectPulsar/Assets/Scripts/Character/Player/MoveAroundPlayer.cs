using UnityEngine;
using System.Collections;

public class MoveAroundPlayer : MonoBehaviour {

    Player hpPlayer;

    Rigidbody2D rb;
    public GameObject player, startGameText;
    public GameObject explosion, endExplosion;
    bool instanceTrue = false, collideTrue = false, impactTrue = false, timerTrue = false;
    float dragRotation = 0;
    int speed, rotation;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        hpPlayer = GameObject.Find("Pulsar").GetComponent<Player>();
        //player = GameObject.Find("Pulsar2");
        speed = hpPlayer.speedOrb;
        rotation = hpPlayer.rotationOrb;
    }
	
	// Update is called once per frame
	void Update () {

        if (hpPlayer.hp > 0)
        {
            rb.AddForce(new Vector2(0 - transform.position.x, 0 - transform.position.y) * Time.deltaTime * speed);

            if (impactTrue == false)
            {
                transform.RotateAround(new Vector2(0, 0), new Vector3(0, 0, 1), Time.deltaTime * rotation);
               
            }

        }
        if (hpPlayer.hp <= 0)
        {
            Invoke("DestructOrb", 3f);
            rb.AddForce(new Vector2(0 + transform.position.x, 0 + transform.position.y) * Time.deltaTime * 500);
            if (collideTrue == false)
            {
                rb.velocity += new Vector2(transform.position.x * 100, transform.position.y * 25);
                Instantiate(endExplosion, transform.position, transform.rotation);
                collideTrue = true;
            }

        }
        if (timerTrue)
            dragRotation += Time.deltaTime;
        if (dragRotation >= 5f)
        {
            rb.drag = 0;
        }
        
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "PulsarOrb")
        {
            if (instanceTrue == false)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                player.SetActive(true);
                startGameText.SetActive(true);
                instanceTrue = true;
                impactTrue = true;
                rb.drag = 0.5f;
            }
            //Destroy(gameObject, 1f);
            
            timerTrue = true;
        }


    }

    void DestructOrb()
    {
        Destroy(gameObject);
    }
}
