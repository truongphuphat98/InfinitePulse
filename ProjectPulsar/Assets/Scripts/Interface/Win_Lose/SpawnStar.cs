using UnityEngine;
using System.Collections;

public class SpawnStar : MonoBehaviour
{
    Player endGame;
    float xPos, yPos;
    int signeY;
    public int starTarget = 1;
    bool invokeTrue = false;

    public GameObject star;

    void Start()
    {
       endGame = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
    }

    void Update()
    {
        if (endGame.end == true && invokeTrue == false)
        {
            Invoke("SpawnRate", 0f);
            Invoke("SpawnRate", 1f);
            Invoke("SpawnRate", 2f);
            Invoke("SpawnRate", 3f);
            Invoke("SpawnRate", 4f);
            invokeTrue = true;
        }
    }

    void SpawnRate()
    {
        signeY = Random.Range(0, 2);
        if (signeY == 0)
            signeY = -1;

        xPos = Random.Range(-9.5f, 9.5f);
        if (xPos < -8.9f || xPos > 8.9f)
            yPos = Random.Range(-5.5f, 5.5f);
        if (xPos > -8.9f && xPos < 8.9f)
        {
            yPos = Random.Range(5f, 5.5f);
            yPos = yPos * signeY;
        }

            GameObject starClone = Instantiate(star, new Vector3(xPos, yPos, -0.5f), transform.rotation) as GameObject;
            starClone.tag = "pos" + starTarget.ToString();
            starClone.GetComponent<StarMove>().starTarget = starTarget;
            starTarget += 1;
        
    }
}
