using UnityEngine;
using System.Collections;

public class PowerUpSelfDestruct : MonoBehaviour
{
    ParticulesAttractor newParticules;
    Light pushSprite;
    public GameObject explosionPwup;
    Rigidbody2D rb;

    bool attractTrue = false;
    float attractTime = 0;

    void Start()
    {
        pushSprite = GetComponent<Light>();
        newParticules = GetComponent<ParticulesAttractor>();
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.name == "PowerUpOne")
        {
            transform.Find("ExploPwupOne").gameObject.GetComponent<ParticleSystem>().startColor = new Color(0,255,234,255);
        }
        if (gameObject.name == "PowerUpTwo")
        {
            transform.Find("ExploPwupOne").gameObject.GetComponent<ParticleSystem>().startColor = new Color(0, 255, 0, 255);
        }
        Invoke("DestructPwup", 7.0f);
    }

    void Update()
    {

       

        if (attractTrue == true)
        {
            rb.AddForce(new Vector3(0 - transform.position.x, 0 - transform.position.y) * Time.deltaTime * 10f);
            attractTime += Time.deltaTime;
            if (attractTime >= 0.3f)
            {
                newParticules.p = explosionPwup.GetComponent<ParticleSystem>();
                attractTime = 0;
                //attractTrue = false;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Push")
        {
            gameObject.layer = 10;
            if (gameObject.tag == "PowerUp1")
            {
                pushSprite.enabled = false;
                transform.Find("Shockwave").gameObject.SetActive(false);

            }
            if (gameObject.tag == "PowerUp2")
            {
                transform.Find("HealthPulse").gameObject.SetActive(false);

            }
            //Instantiate(explosionPwup, transform.position, transform.rotation);
            transform.Find("ExploPwupOne").gameObject.SetActive(true);
            attractTrue = true;
            CancelInvoke("DestructPwup");
        }


    }

    void DestructPwup()
    {
        Destroy(gameObject);
    }
}
