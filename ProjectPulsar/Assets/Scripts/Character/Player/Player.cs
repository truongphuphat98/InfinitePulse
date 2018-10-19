using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    WaveLevelTimer victoryScore;

    public bool shieldTrigger = false, setScore = false, damageTrue = false, end = false;
    public float pushReload = 0f, pushTime = 1.8f, attractReload = 0f, attractTime = 4.5f, shieldTime = 0, hpRegeneration = 0, victoryTime = 0;
    public int hp = 12, hpMax = 12;
    public GameObject push, attract;
    public GameObject damageHealth, healHealth, icePlanetExplosion, firePlanetExplosion;
    GameObject[] asteroides, fireplanets, icePlanets;
    Vector2 posPushPower;

    public GameObject loseCanvas, pulsarImage;
    AudioSource playerSound;
    public AudioClip health, damage, pushSound, attractSound;
    public int speedOrb, rotationOrb;

    void Awake()
    {

        speedOrb = Random.Range(300, 800);
        rotationOrb = Random.Range(30, 100);
    }

    void Start()
    {
        victoryScore = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
        playerSound = GetComponent<AudioSource>();
        
    }

    void Update()
    {        
        victoryTime += Time.deltaTime;

        hpRegeneration += Time.deltaTime;

        if (hp >= hpMax)
            hp = hpMax;

        if (hpRegeneration >= 20f && end == false)
        {
            hp += 1;
            Instantiate(healHealth, transform.position, transform.rotation);
            playerSound.PlayOneShot(health);
            hpRegeneration = 0;
        }

        if (shieldTrigger == true)
            shieldTime += Time.deltaTime;

        if (shieldTime >= 7f)
        {
            shieldTime = 0;
            shieldTrigger = false;
        }

        if (gameObject.tag == "Pulsar")
            transform.Rotate(new Vector3(0, 0, 1) * 0.7f);

        if (hp <= 0 && setScore == false)
        {
            pulsarImage.SetActive(false);
            if (PlayerPrefs.GetInt("BestScore") <= victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", PlayerPrefs.GetInt("Score5"));
                PlayerPrefs.SetInt("Score5", PlayerPrefs.GetInt("Score4"));
                PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
                PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
                PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("BestScore"));
                PlayerPrefs.SetInt("BestScore", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score2") <= victoryScore.score && PlayerPrefs.GetInt("BestScore") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", PlayerPrefs.GetInt("Score5"));
                PlayerPrefs.SetInt("Score5", PlayerPrefs.GetInt("Score4"));
                PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
                PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
                PlayerPrefs.SetInt("Score2", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score3") <= victoryScore.score && PlayerPrefs.GetInt("Score2") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", PlayerPrefs.GetInt("Score5"));
                PlayerPrefs.SetInt("Score5", PlayerPrefs.GetInt("Score4"));
                PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
                PlayerPrefs.SetInt("Score3", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score4") <= victoryScore.score && PlayerPrefs.GetInt("Score3") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", PlayerPrefs.GetInt("Score5"));
                PlayerPrefs.SetInt("Score5", PlayerPrefs.GetInt("Score4"));
                PlayerPrefs.SetInt("Score4", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score5") <= victoryScore.score && PlayerPrefs.GetInt("Score4") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", PlayerPrefs.GetInt("Score5"));
                PlayerPrefs.SetInt("Score5", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score6") <= victoryScore.score && PlayerPrefs.GetInt("Score5") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", PlayerPrefs.GetInt("Score6"));
                PlayerPrefs.SetInt("Score6", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score7") <= victoryScore.score && PlayerPrefs.GetInt("Score6") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", PlayerPrefs.GetInt("Score7"));
                PlayerPrefs.SetInt("Score7", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score8") <= victoryScore.score && PlayerPrefs.GetInt("Score7") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", PlayerPrefs.GetInt("Score8"));
                PlayerPrefs.SetInt("Score8", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score9") <= victoryScore.score && PlayerPrefs.GetInt("Score8") > victoryScore.score)
            {
                PlayerPrefs.SetInt("Score10", PlayerPrefs.GetInt("Score9"));
                PlayerPrefs.SetInt("Score9", victoryScore.score);
            }
            else if (PlayerPrefs.GetInt("Score10") <= victoryScore.score && PlayerPrefs.GetInt("Score9") > victoryScore.score)
                PlayerPrefs.SetInt("Score10", victoryScore.score);

            victoryScore.endWave = true;
            victoryScore.nombreENM1 = 0;
            victoryScore.nombreENM2 = 0;
            victoryScore.nombreMaxENM1 = 0;
            victoryScore.nombreMaxENM2 = 0;
            
            asteroides = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < asteroides.Length; i++)
                Destroy(asteroides[i]);

            fireplanets = GameObject.FindGameObjectsWithTag("FirePlanet");
            for (int i = 0; i < fireplanets.Length; i++)
                Destroy(fireplanets[i]);

            icePlanets = GameObject.FindGameObjectsWithTag("IcePlanet");
            for (int i = 0; i < icePlanets.Length; i++)
                Destroy(icePlanets[i]);

            loseCanvas.SetActive(true);
            end = true;
            setScore = true;
        }

        posPushPower = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posPushPower = Camera.main.ScreenToWorldPoint(posPushPower);

        pushReload += Time.deltaTime;
        attractReload += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && pushReload >= pushTime && Time.timeScale == 1)
        {
            Instantiate(push, posPushPower, transform.rotation);
            playerSound.PlayOneShot(pushSound);
            pushReload = 0;
        }

        if (Input.GetMouseButtonDown(1) && attractReload >= attractTime && Time.timeScale == 1)
        {
            Instantiate(attract, posPushPower, transform.rotation);
            playerSound.PlayOneShot(attractSound);
            attractReload = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (shieldTrigger == false)
                    hp -= 1;
                    
            Instantiate(damageHealth, transform.position, transform.rotation);
            playerSound.PlayOneShot(damage);
            Destroy(other.gameObject, 0.1f);
            victoryScore.nombreENM1 -= 1;

        }
        if (other.gameObject.tag == "FirePlanet" || other.gameObject.tag == "IcePlanet")
        {
            if (shieldTrigger == false)
                hp -= 4;
            playerSound.PlayOneShot(damage);
            if (other.gameObject.tag == "FirePlanet")
            {
                foreach (ContactPoint2D contact in other.contacts)
                {
                    Vector2 point = contact.point;

                    Instantiate(firePlanetExplosion, transform.position, Quaternion.Euler(GetCollisionAngle(other.gameObject.transform, gameObject.GetComponent<CircleCollider2D>(), point) - 90, -90, 90));
                }
            }
            if (other.gameObject.tag == "IcePlanet")
            {
                foreach (ContactPoint2D contact in other.contacts)
                {
                    Vector2 point = contact.point;

                    Instantiate(icePlanetExplosion, transform.position, Quaternion.Euler(GetCollisionAngle(other.gameObject.transform, gameObject.GetComponent<CircleCollider2D>(), point) - 90, -90, 90));
                }
            }
            other.gameObject.GetComponent<Enemy2Mouvement>().hpPlanet -= 4;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PowerUp1" || other.gameObject.tag == "PowerUp2")
        {
            if (other.gameObject.tag == "PowerUp1")
                shieldTrigger = true;

            if (other.gameObject.tag == "PowerUp2")
            {
                playerSound.PlayOneShot(health);
                hp += 1;
                Instantiate(healHealth, transform.position, transform.rotation);
            }
            Destroy(other.gameObject);
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
}
