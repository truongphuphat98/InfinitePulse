using UnityEngine;
using System.Collections;

public class PlayerTuto : MonoBehaviour
{

    public bool tuto1Fini = false, degat1 = false, attractRaterTrue = false, secondENM = false, degat2 = false, tuto2Fini = false, clicDroit = false, zoneClicGauche = false, zoneClicDroit = false, mouseOverZone = false;

    public int hp = 12, hpMax = 12;
    public float pushReload = -12f, pushTime = 2f, attractReload = 0f, attractTime = 3f, attractRaterTimer = 0, healthRegen = 0;
    Vector2 posPushPower;

    public GameObject push, attract, asteroideExplosion, healthHeal;
    GameObject zoneClic1, zoneClic2;
    GameObject[] asteroides;
    // Use this for initialization
    void Awake()
    {
        zoneClic1 = GameObject.Find("ZoneClic");
        zoneClic2 = GameObject.Find("ZoneClic2");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Pulsar")
            transform.Rotate(new Vector3(0, 0, 1) * 0.7f);

        posPushPower = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posPushPower = Camera.main.ScreenToWorldPoint(posPushPower);

        if (hp < 12)
            healthRegen += Time.deltaTime;

        if (healthRegen >= 4f)
        {
            hp += 1;
            healthRegen = 0;
            Instantiate(healthHeal, transform.position, transform.rotation);
        }

        if (tuto1Fini == false)
        {
            pushReload += Time.deltaTime;
        }

        if (tuto1Fini == true)
        {
            attractReload += Time.deltaTime;
            pushReload = 0;
        }
        if (attractRaterTrue == true)
            attractRaterTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && pushReload >= pushTime && Time.timeScale == 1 && tuto1Fini == false && (zoneClicGauche == true || mouseOverZone == true))
        {
            Instantiate(push, posPushPower, transform.rotation);
            pushReload = 0;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().clicGaucheTrue = 1;
            zoneClic1.SetActive(false);
            zoneClicGauche = true;
        }

        if (Input.GetMouseButtonDown(1) && attractReload >= attractTime && Time.timeScale == 1 && tuto1Fini == true && (zoneClicDroit == true || mouseOverZone == true))
        {
            Instantiate(attract, posPushPower, transform.rotation);
            attractReload = 0;
            attractRaterTrue = true;
            if (clicDroit == false)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().clicDroitTrue = 2;
                clicDroit = true;
            }
            zoneClic2.SetActive(false);
            zoneClicDroit = true;
        }

        if (attractRaterTimer >= 2.5f && secondENM == false)
        {

            asteroides = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < asteroides.Length; i++)
            {
                Destroy(asteroides[i]);
            }
            GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM = 5;


            attractRaterTimer = 0;
            attractRaterTrue = false;
        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (degat1 == false)
            {
                Instantiate(asteroideExplosion, transform.position, transform.rotation);
                if (GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM == 2)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().tryAgain.enabled = true;
                    GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM = 1;
                    GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().freezePos = 8f;
                }
            }

            if (degat2 == false && GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM == 7)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().tryAgain.enabled = true;
                GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().firstENM = 6;
            }
            hp = 11;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Destroy(other.gameObject, 0.1f);
    }
}
