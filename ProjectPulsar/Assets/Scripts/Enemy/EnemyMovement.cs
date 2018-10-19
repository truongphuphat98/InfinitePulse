using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    //SkillTreeManager skillManager;   
    WaveLevelTimer scoreENM;
    Player currentHp;

    float posPulsarX, posPulsarY, maxSpeed = 1.5f, screenX = 17.6f, screenY = 10f;
    public int targetTrigger = 0;
    bool maxSpeedTrigger = false, pwupTrue = false, colorAlphaTrue = false, comboTrue = false, damageTrue = false;
    int healPwupChance = 0, shieldPwupChance = 0;

    public GameObject teleportationEffectBefore, teleportationEffectAfter, asteroideCollisionEffect;
    public GameObject pwp1, pwp2, pwupEffect;
    

    Rigidbody2D rb;
    AudioSource enm1Sound;
    public AudioClip teleport;

    Color alphaColor;

    // Use this for initialization
    void Start()
    {
        alphaColor = GetComponent<SpriteRenderer>().color;
        enm1Sound = GetComponent<AudioSource>();
        

        currentHp = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            targetTrigger = 0;
        if (PlayerPrefs.GetInt("TutoFini") == 0)
            maxSpeed = 1.5f;
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            maxSpeed = 1f;
        rb = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            scoreENM = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorAlphaTrue == true)
        {
            alphaColor.a -= 0.04f;
            GetComponent<SpriteRenderer>().color = alphaColor;
        }

        posPulsarX = GameObject.FindGameObjectWithTag("Pulsar").transform.position.x;
        posPulsarY = GameObject.FindGameObjectWithTag("Pulsar").transform.position.y;

        if (gameObject.layer == 8 && targetTrigger == 0)
            rb.AddRelativeForce(Vector2.up);

        if (gameObject.layer == 8 && targetTrigger == 1)
            rb.AddForce(new Vector2(posPulsarX - transform.position.x, posPulsarY - transform.position.y));

        if (rb.velocity.magnitude >= maxSpeed)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if (transform.position.x <= -8.8f)
        {
            Instantiate(teleportationEffectBefore, transform.position, Quaternion.Euler(180, -90, -90));
            transform.position = new Vector2(transform.position.x + screenX, transform.position.y);
            Instantiate(teleportationEffectAfter, transform.position, Quaternion.Euler(0, -90, -90));
            enm1Sound.PlayOneShot(teleport, 0.3f);
            targetTrigger = 1;
        }
        if (transform.position.x >= 8.8f)
        {
            Instantiate(teleportationEffectBefore, transform.position, Quaternion.Euler(0, -90, -90));
            transform.position = new Vector2(transform.position.x - screenX, transform.position.y);
            Instantiate(teleportationEffectAfter, transform.position, Quaternion.Euler(180, -90, -90));
            enm1Sound.PlayOneShot(teleport, 0.3f);
            targetTrigger = 1;
        }
        if (transform.position.y <= -5f)
        {
            Instantiate(teleportationEffectBefore, transform.position, Quaternion.Euler(90, -90, -90));
            transform.position = new Vector2(transform.position.x, transform.position.y + screenY);
            Instantiate(teleportationEffectAfter, transform.position, Quaternion.Euler(270, -90, -90));
            enm1Sound.PlayOneShot(teleport, 0.3f);
            targetTrigger = 1;
        }
        if (transform.position.y >= 5f)
        {
            Instantiate(teleportationEffectBefore, transform.position, Quaternion.Euler(270, -90, -90));
            transform.position = new Vector2(transform.position.x, transform.position.y - screenY);
            Instantiate(teleportationEffectAfter, transform.position, Quaternion.Euler(90, -90, -90));
            enm1Sound.PlayOneShot(teleport, 0.3f);
            targetTrigger = 1;
        }

    }

    public float GetCollisionAngle(Transform hitobjectTransform, CircleCollider2D collider, Vector2 contactPoint)
    {
        Vector2 collidertWorldPosition = new Vector2(hitobjectTransform.position.x, hitobjectTransform.position.y);
        Vector3 pointB = contactPoint - collidertWorldPosition;

        float theta = Mathf.Atan2(pointB.x, pointB.y);
        float angle = (360 - ((theta * 180) / Mathf.PI)) % 360;
        return angle;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (ContactPoint2D contact in other.contacts)
        {
            Vector2 point = contact.point;
            Instantiate(asteroideCollisionEffect, transform.position, Quaternion.Euler(-180, -180, GetCollisionAngle(other.gameObject.transform, gameObject.GetComponent<CircleCollider2D>(), point)));
        }
        Destroy(gameObject.GetComponent<CircleCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 12)
        {
            if (other.gameObject.tag == "Push")
            {
                if (maxSpeedTrigger == false)
                {
                    maxSpeed *= 2f;
                    maxSpeedTrigger = true;
                }
                gameObject.layer = 9;
            }
            if (other.gameObject.tag == "Attract")
                gameObject.layer = 9;

        }

        

        if (other.gameObject.tag == "FirePlanet")
        {
            PwupPop();
            if (damageTrue == false)
            {
                scoreENM.nombreENM1 -= 1;
                scoreENM.score += 25;
                
                other.gameObject.GetComponent<Enemy2Mouvement>().hpPlanet -= 1;
                if (other.gameObject.GetComponent<Enemy2Mouvement>().hpPlanet <= 0)
                    scoreENM.score += 75;
                damageTrue = true;
            }

            Destroy(gameObject, 0.4f);

        }

        if (other.gameObject.tag == "IcePlanet")
        {
            PwupPop();
            if (damageTrue == false)
            {
                scoreENM.nombreENM1 -= 1;
                scoreENM.score += 25;
                other.gameObject.GetComponent<Enemy2Mouvement>().hpPlanet -= 1;
                if (other.gameObject.GetComponent<Enemy2Mouvement>().hpPlanet <= 0)
                    scoreENM.score += 75;
                damageTrue = true;
            }
            Destroy(gameObject, 0.4f);
        }

        if (other.gameObject.tag == "Enemy" && (gameObject.layer == 8 || gameObject.layer == 9))
        {
            PwupPop();


            if ((gameObject.layer == 8 || gameObject.layer == 9) && PlayerPrefs.GetInt("TutoFini") == 1)
            {
                if (damageTrue == false)
                {
                    scoreENM.score += 25;
                    
                    damageTrue = true;
                }

                scoreENM.textSize.characterSize += 0.0025f;
                if (comboTrue == false)
                {
                    scoreENM.nombreENM1 -= 1;
                    scoreENM.scoreComboTimer -= 1f;
                    comboTrue = true;
                }
            }

            if (PlayerPrefs.GetInt("TutoFini") == 0)
            {
                GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>().secondENM = true;
                GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM = 6;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().zoneBleueTrue = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().attireBleu = 1;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().clicDroitTrue = 0;
            }
            colorAlphaTrue = true;
            
            Destroy(gameObject, 0.4f);
        }
    }

    void PwupPop()
    {
        if (pwupTrue == false && PlayerPrefs.GetInt("TutoFini") == 1)
        {

            if (currentHp.hp > 6)
                healPwupChance = Random.Range(0, 30);
            if (currentHp.hp <= 6)
                healPwupChance = Random.Range(0, 15);
            if (healPwupChance == 1)
            {
                Instantiate(pwp2, transform.position, transform.rotation);
                Instantiate(pwupEffect, transform.position, transform.rotation);
                pwupTrue = true;
            }

            if (scoreENM.nombreENM1 <= 6 && scoreENM.nombreENM2 == 0)
                shieldPwupChance = Random.Range(0, 70);
            if ((scoreENM.nombreENM1 > 6 && scoreENM.nombreENM1 <= 9) || scoreENM.nombreENM2 == 1)
                shieldPwupChance = Random.Range(0, 50);
            if (scoreENM.nombreENM1 >= 10 || scoreENM.nombreENM2 == 2)
                shieldPwupChance = Random.Range(0, 30);
            if (scoreENM.nombreENM1 >= 14 || scoreENM.nombreENM2 == 3)
                shieldPwupChance = Random.Range(0, 15);
            if (shieldPwupChance == 1)
            {
                Instantiate(pwp1, new Vector3(transform.position.x, transform.position.y, 40f), transform.rotation);
                Instantiate(pwupEffect, transform.position, transform.rotation);
                pwupTrue = true;
            }

            pwupTrue = true;
        }
    }
}