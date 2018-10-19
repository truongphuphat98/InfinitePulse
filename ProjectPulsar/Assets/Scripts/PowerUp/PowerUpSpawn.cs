using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject pwp1, pwp2, pwupEffect;
    float posXPwp1, posYPwp1;
    float posXPwp2, posYPwp2;

    float powerUpReload = 35f;
    int pwupChoice = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        powerUpReload += Time.deltaTime;
        if (powerUpReload >= 7f)
        {
            posXPwp1 = Random.Range(-8.5f, 8.5f);
            posYPwp1 = Random.Range(-4.9f, 4.9f);
            posXPwp2 = Random.Range(-8.5f, 8.5f);
            posYPwp2 = Random.Range(-4.9f, 4.9f);
            pwupChoice = Random.Range(0, 2);
            if (pwupChoice == 0)
            {
                Instantiate(pwp1, new Vector2(posXPwp1, posYPwp1), transform.rotation);
                Instantiate(pwupEffect, new Vector2(posXPwp1, posYPwp1), transform.rotation);
            }
            if (pwupChoice == 1)
            {
                Instantiate(pwp2, new Vector2(posXPwp2, posYPwp2), transform.rotation);
                Instantiate(pwupEffect, new Vector2(posXPwp2, posYPwp2), transform.rotation);
            }

            powerUpReload = 0;

        }

    }
}
