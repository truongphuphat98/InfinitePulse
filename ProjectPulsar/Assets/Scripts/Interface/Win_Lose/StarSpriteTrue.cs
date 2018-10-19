using UnityEngine;
using System.Collections;

public class StarSpriteTrue : MonoBehaviour
{
    WaveLevelTimer score;

    public Sprite[] etoileSprite;
    SpriteRenderer spriteEtoile;
    public GameObject starFX;
    public int state = 0;
    public bool triggerTrue = false;

    void Start()
    {
        spriteEtoile = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        score = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
    }


    void Update()
    {
        if (triggerTrue == true && state == 0)
            spriteEtoile.sprite = etoileSprite[0];
        if (triggerTrue == true && state == 1)
            spriteEtoile.sprite = etoileSprite[1];
        if (triggerTrue == true && state == 2)
            spriteEtoile.sprite = etoileSprite[2];
    }

    /*0, 100, 220, 220, 220, 1, "Star1");
            palierColor(0.075f, 100, 250, 169, 0, 220, 2, "Star1");
            palierColor(0.080f, 250, 500, 0, 55, 255, 1, "Star2");
            palierColor(0.085f, 500, 1000, 0, 220, 209, 2, "Star2");
            palierColor(0.090f, 1000, 2500, 0, 165, 82, 1, "Star3");
            palierColor(0.095f, 2500, 5000, 110, 220, 0, 2, "Star3");
            palierColor(0.100f, 5000, 10000, 220, 202, 0, 1, "Star4");
            palierColor(0.105f, 10000, 25000, 255, 128, 0, 2, "Star4");
            palierColor(0.110f, 25000, 50000, 255, */

    void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.name == "Star1")
        {
            if (score.score < 100)
                state = 1;
            if (score.score >= 100)
                state = 2;
            if (other.gameObject.tag == "pos1")
            {
                Instantiate(starFX, transform.position, transform.rotation);
                triggerTrue = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject);
            }
        }
        if (gameObject.name == "Star2")
        {
            if (score.score >= 250 && score.score < 500)
                state = 1;
            if (score.score >= 500)
                state = 2;
            if (other.gameObject.tag == "pos2")
            {
                Instantiate(starFX, transform.position, transform.rotation);
                triggerTrue = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject);
            }
        }
        if (gameObject.name == "Star3")
        {
            if (score.score >= 1000 && score.score < 2500)
                state = 1;
            if (score.score >= 2500)
                state = 2;
            if (other.gameObject.tag == "pos3")
            {
                Instantiate(starFX, transform.position, transform.rotation);
                triggerTrue = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject);
            }
        }
        if (gameObject.name == "Star4")
        {
            if (score.score >= 5000 && score.score < 10000)
                state = 1;
            if (score.score >= 10000)
                state = 2;
            if (other.gameObject.tag == "pos4")
            {
                Instantiate(starFX, transform.position, transform.rotation);
                triggerTrue = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject);
            }
        }
        if (gameObject.name == "Star5")
        {
            if (score.score >= 25000 && score.score < 50000)
                state = 1;
            if (score.score >= 50000)
                state = 2;
            if (other.gameObject.tag == "pos5")
            {
                Instantiate(starFX, transform.position, transform.rotation);
                triggerTrue = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject);
            }
        }
    }
}
