using UnityEngine;
using System.Collections;

public class ZoneBleueToucher : MonoBehaviour
{
    public GameObject instruct, Pulsar2;
 

    bool zoneRadius = false;

    void Start()
    {
        gameObject.SetActive(false);
        Pulsar2 = GameObject.Find("Pulsar2");
    }

    void Update()
    {
        if (zoneRadius == true && transform.localScale != (new Vector3(0, 0, 0)))
            gameObject.GetComponent<Transform>().localScale += (new Vector3(-0.1f, -0.1f, 0));

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TextPop>().attireBleu = 2;
            zoneRadius = true;
            instruct.SetActive(true);
            Pulsar2.SetActive(false);
            Destroy(gameObject, 1f);
            Destroy(other.gameObject, 1);
        }
    }
}
