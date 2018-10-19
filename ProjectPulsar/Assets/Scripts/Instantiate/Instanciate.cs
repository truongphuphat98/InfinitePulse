using UnityEngine;
using System.Collections;

public class Instanciate : MonoBehaviour
{
    WaveLevelTimer nombreENM;

    public Sprite[] asteroideSprites;
    public Sprite[] planetSprites;
    public GameObject enemy, planet;
    public GameObject asteroideSprite, creationEffects, planetCreationEffect;

    float upLeft, up, upRight, right, downRight, down, downLeft, left;
    float spawnRate = 2f, spawnPlanetRate = 30f;
    int spawnNumber, asteroideSpriteNumber, spawnPlanetNumber, planetSpriteNumber;

    void Start()
    {
        spawnNumber = Random.Range(1, 8);
        asteroideSpriteNumber = Random.Range(1, 4);

        spawnPlanetNumber = Random.Range(1, 4);
        planetSpriteNumber = Random.Range(1, 3);
        asteroideSprite = enemy.gameObject;

        nombreENM = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
    }

    void Update()
    {
        upLeft = Random.Range(-100, -150);
        up = Random.Range(-120, -270);
        upRight = Random.Range(-210, -260);
        right = Random.Range(30, 150);
        downRight = Random.Range(30, 80);
        down = Random.Range(60, -60);
        downLeft = Random.Range(-30, -80);
        left = Random.Range(-30, -150);

        
        

        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0)
        {
            spawnRate = 0.5f;
            spawnNumber += 1;
        }

        if (spawnNumber > 8)
            spawnNumber = 1;

        if (asteroideSpriteNumber > 3)
            asteroideSpriteNumber = 1;

        if (nombreENM.nombreENM1 < nombreENM.nombreMaxENM1)
        {
            InstantiateEnm1("ULspawn", 1, upLeft, asteroideSpriteNumber);
            InstantiateEnm1("Uspawn", 2, up, asteroideSpriteNumber);
            InstantiateEnm1("URspawn", 3, upRight, asteroideSpriteNumber);
            InstantiateEnm1("Rspawn", 4, right, asteroideSpriteNumber);
            InstantiateEnm1("DRspawn", 5, downRight, asteroideSpriteNumber);
            InstantiateEnm1("Dspawn", 6, down, asteroideSpriteNumber);
            InstantiateEnm1("DLspawn", 7, downLeft, asteroideSpriteNumber);
            InstantiateEnm1("Lspawn", 8, left, asteroideSpriteNumber);
        }


        spawnPlanetRate -= Time.deltaTime;

        if (spawnPlanetRate <= 0)
        {
            spawnPlanetRate = 8f;
            spawnPlanetNumber += 1;
        }

        if (spawnPlanetNumber > 4)
            spawnPlanetNumber = 1;
        if (planetSpriteNumber > 2)
            planetSpriteNumber = 1;

        if (spawnPlanetRate <= 0.1f)
        {
            InstantiateEnm2("ULspawn", 1, spawnPlanetNumber);
            InstantiateEnm2("URspawn", 2, spawnPlanetNumber);
            InstantiateEnm2("DRspawn", 3, spawnPlanetNumber);
            InstantiateEnm2("DLspawn", 4, spawnPlanetNumber);
        }
    }

    void InstantiateEnm1(string spawnPosition, int spawnOrder, float spawnAngle, int spriteNumber)
    {
        if (asteroideSpriteNumber == 1)
            asteroideSprite.GetComponent<SpriteRenderer>().sprite = asteroideSprites[0];
        if (asteroideSpriteNumber == 2)
            asteroideSprite.GetComponent<SpriteRenderer>().sprite = asteroideSprites[1];
        if (asteroideSpriteNumber == 3)
            asteroideSprite.GetComponent<SpriteRenderer>().sprite = asteroideSprites[2];

        if (gameObject.tag == spawnPosition && spawnNumber == spawnOrder)
        {
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, spawnAngle));
            Instantiate(creationEffects, transform.position, transform.rotation);
            spawnRate = 0.5f;
            spawnNumber += 1;
            asteroideSpriteNumber += 1;
            nombreENM.nombreENM1 += 1;
        }
    }

    void InstantiateEnm2(string spawnPosition, int spawnOrder, int spriteNumber)
    {
        if (planetSpriteNumber == 1)
        {
            planet.GetComponent<SpriteRenderer>().sprite = planetSprites[0];
            planet.tag = "FirePlanet";
        }
        if (planetSpriteNumber == 2)
        {
            planet.GetComponent<SpriteRenderer>().sprite = planetSprites[1];
            planet.tag = "IcePlanet";
        }
        if (gameObject.tag == spawnPosition && spawnPlanetNumber == spawnOrder && nombreENM.nombreENM2 < nombreENM.nombreMaxENM2)
        {
            Instantiate(planet, transform.position, transform.rotation);
            Instantiate(planetCreationEffect, transform.position, Quaternion.Euler(0, 0, upLeft + 90));
            spawnPlanetRate = 8f;
            spawnPlanetNumber += 1;
            planetSpriteNumber += 1;
            nombreENM.nombreENM2 += 1;
        }
    }
}

