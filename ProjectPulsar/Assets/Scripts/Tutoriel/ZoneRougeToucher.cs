using UnityEngine;
using System.Collections;

public class ZoneRougeToucher : MonoBehaviour
{
    PlayerTuto mouseCheck;

    public bool stopTimeTrue = false, zoneRadius = false, incrementationTrue = false;
    public float stopTime = 0;

    void Start()
    {
        gameObject.SetActive(false);
        mouseCheck = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<PlayerTuto>();
    }

    void Update()
    {
        if (stopTimeTrue == true)
            stopTime += Time.deltaTime;
        if (zoneRadius == true && transform.localScale != (new Vector3(0, 0, 0)))
            gameObject.GetComponent<Transform>().localScale += (new Vector3(-0.1f, -0.1f, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().clicGaucheTrue = 2;
            if (zoneRadius == false)
                other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            stopTimeTrue = true;
            if (incrementationTrue == false)
            {
                GameObject.Find("TutoSpawENM").GetComponent<TuToSpawnENM>().deuxiemeAste += 1;
                incrementationTrue = true;
                mouseCheck.mouseOverZone = false;
            }
            GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>().degat1 = true;
            GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>().tuto1Fini = true;
            zoneRadius = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().clicDroitTrue = 1;
            Destroy(gameObject, 0.5f);
            if (transform.localScale.x < 0.6f)
                other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
}
