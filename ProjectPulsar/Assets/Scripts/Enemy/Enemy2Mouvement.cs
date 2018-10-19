using UnityEngine;
using System.Collections;

public class Enemy2Mouvement : MonoBehaviour
{
    WaveLevelTimer nombreENM;

    float posPulsarX, posPulsarY, maxSpeed = 0.5f;
    public int hpPlanet = 3, healthPwup = 0, shieldPwup = 0;
    bool decrementation, pwupTrue = false;

    public Sprite[] hpSprites;
    public GameObject fireExplosion, iceExplosion;
    public GameObject pwp1, pwp2, pwupEffect;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posPulsarX = GameObject.FindGameObjectWithTag("Pulsar").transform.position.x;
        posPulsarY = GameObject.FindGameObjectWithTag("Pulsar").transform.position.y;
        nombreENM = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(posPulsarX - transform.position.x, posPulsarY - transform.position.y));

        if (rb.velocity.magnitude >= maxSpeed)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        if (gameObject.tag == "FirePlanet" && hpPlanet == 3)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[0];
        if (gameObject.tag == "FirePlanet" && hpPlanet == 2)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[1];
        if (gameObject.tag == "FirePlanet" && hpPlanet == 1)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[2];
        if (gameObject.tag == "IcePlanet" && hpPlanet == 3)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[3];
        if (gameObject.tag == "IcePlanet" && hpPlanet == 2)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[4];
        if (gameObject.tag == "IcePlanet" && hpPlanet == 1)
            gameObject.GetComponent<SpriteRenderer>().sprite = hpSprites[5];

        if (hpPlanet <= 0)
        {
            if (decrementation == false)
            {
                if (gameObject.tag == "FirePlanet")
                    Instantiate(fireExplosion, transform.position, transform.rotation);
                if (gameObject.tag == "IcePlanet")
                    Instantiate(iceExplosion, transform.position, transform.rotation);
                nombreENM.nombreENM2 -= 1;
                decrementation = true;
            }

            if (transform.localScale.x > 0 && transform.localScale.y > 0)
                transform.localScale -= new Vector3(0.005f, 0.005f);

            Destroy(gameObject, 0.5f);

            if (pwupTrue == false)
            {              
                    shieldPwup = Random.Range(0, 25);
                
                if (shieldPwup == 1)
                {
                    Instantiate(pwp1, transform.position, transform.rotation);
                    Instantiate(pwupEffect, transform.position, transform.rotation);
                    pwupTrue = true;
                }
             
                    healthPwup = Random.Range(0, 25);

                if (healthPwup == 1)
                {
                    Instantiate(pwp2, transform.position, transform.rotation);
                    Instantiate(pwupEffect, transform.position, transform.rotation);
                    pwupTrue = true;
                }
                pwupTrue = true;
            }
        }
    }
}
