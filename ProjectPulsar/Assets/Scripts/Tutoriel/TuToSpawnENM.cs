using UnityEngine;
using System.Collections;

public class TuToSpawnENM : MonoBehaviour
{

    public float FirstENMTimer = 0, freezePos = 0, deuxiemeAsteTimer = 0;
    public int firstENM = 0;
    public int deuxiemeAste = 0;
    bool deuxiemeAsteTrigger = false;

    public GameObject enm1;
    GameObject enm;
    GameObject[] asteroides;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        FirstENMTimer += Time.deltaTime;
        freezePos += Time.deltaTime;

        if (deuxiemeAsteTrigger == true)
            deuxiemeAsteTimer += Time.deltaTime;

        enm = GameObject.FindGameObjectWithTag("Enemy");

        if (FirstENMTimer >= 1.9f && firstENM == 0)
        {
            //enm1.GetComponent<EnemyMovement>().targetTrigger = 1;
            Instantiate(enm1, transform.position, transform.rotation);
            firstENM = 1;
            FirstENMTimer = 0;
        }



        if (FirstENMTimer >= 6f && firstENM == 1)
        {
            enm1.GetComponent<EnemyMovement>().targetTrigger = 1;
            Instantiate(enm1, transform.position, transform.rotation);

            firstENM = 2;
        }

        if (freezePos >= 10f && freezePos <= 10.5f)
        {
            enm.GetComponent<EnemyMovement>().targetTrigger = 2;
            enm.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (firstENM == 3)
        {
            enm1.GetComponent<EnemyMovement>().targetTrigger = 1;
            Instantiate(enm1, new Vector3(-8.5f, 4.8f), transform.rotation);

            firstENM = 4;
        }
        if (firstENM == 5)
        {
            Instantiate(enm1, new Vector3(-8.5f, 4.8f), transform.rotation);
            Instantiate(enm1, new Vector3(-8f, 3.8f), transform.rotation);
            firstENM = 6;
            deuxiemeAsteTrigger = true;
        }
        if (deuxiemeAste == 1)
        {
            Instantiate(enm1, new Vector3(-8.5f, 4.8f), transform.rotation);
            deuxiemeAsteTrigger = true;
            deuxiemeAste = 2;
        }
        if (deuxiemeAsteTimer >= 2.4f && deuxiemeAsteTimer < 2.5f)
        {
            asteroides = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < asteroides.Length; i++)
            {
                asteroides[i].GetComponent<EnemyMovement>().targetTrigger = 2;
                asteroides[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            }
        }
            if (deuxiemeAsteTimer >= 2.5f)
        {
            asteroides = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < asteroides.Length; i++)
            {
                
                asteroides[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            deuxiemeAsteTrigger = false;
            deuxiemeAsteTimer = 0;
        }
        /*if (deuxiemeAsteTimer > 0 && deuxiemeAsteTimer <= 0.1f)
        {
            asteroides = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < asteroides.Length; i++)
            {
                asteroides[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }*/

        if (GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>().secondENM == true && firstENM == 6)
        {
            
            Instantiate(enm1, new Vector3(-8.5f, 4.8f), transform.rotation);
            deuxiemeAsteTrigger = true;
            firstENM = 7;
        }
    }
}
