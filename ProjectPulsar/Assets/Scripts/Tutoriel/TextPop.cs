using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextPop : MonoBehaviour
{
    PlayerTuto player;

    public static int tutoFini;
    public Canvas protectSource;
    public Canvas clicGauche;
    public Canvas tryAgain;
    public Canvas clicDroit;
    public Canvas attireBleuText;
    public Canvas finTuto;
    public Canvas degats;
    public GameObject instructions, launch;
    GameObject ButtonManager;



    float protectSourceTimer = 0, cliGaucheTimer = 0, tryAgainTimer = 0, clicDroitTimer = 0, degatsTimer = 0;

    public bool zoneBleueTrue = false;
    public int clicGaucheTrue = 0, attireBleu = 0, clicDroitTrue = 0;

    GameObject zoneRouge, zoneBlue, zoneClic1, zoneClic2;

    void Awake()
    {
        player = GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>();
        zoneClic1 = GameObject.Find("ZoneClic");
        zoneClic2 = GameObject.Find("ZoneClic2");
        degats.enabled = false;
        finTuto.enabled = false;
        attireBleuText.enabled = false;
        clicDroit.enabled = false;
        protectSource.enabled = false;
        clicGauche.enabled = false;
        tryAgain.enabled = false;
        instructions.SetActive(false);
        zoneRouge = GameObject.Find("ZoneRouge");
        zoneBlue = GameObject.Find("ZoneBlue");
    }

    void Start()
    {
        zoneClic1.SetActive(false);
        zoneClic2.SetActive(false);
        ButtonManager = GameObject.Find("ButtonManager");
    }

    void Update()
    {
        protectSourceTimer += Time.deltaTime;
        cliGaucheTimer += Time.deltaTime;

        if (player.hp < 12 && degatsTimer <= 3f)
        {
            degats.enabled = true;
            degatsTimer += Time.deltaTime;
        }
        if (degatsTimer >= 3f)
            degats.enabled = false;

        if (protectSourceTimer >= 10.5f)
            protectSource.enabled = true;
        if (protectSourceTimer >= 13f)
            protectSource.enabled = false;

        if (cliGaucheTimer >= 13.5f && clicGaucheTrue == 0)
        {
            clicGauche.enabled = true;
            zoneRouge.SetActive(true);
            zoneClic1.SetActive(true);
        }
        if (clicGaucheTrue == 1)
        {
            clicGauche.enabled = true;
            zoneRouge.SetActive(true);
            zoneClic1.SetActive(false);
        }
        if (clicGaucheTrue == 2)
            clicGauche.enabled = false;
        if (tryAgain.enabled == true)
            tryAgainTimer += Time.deltaTime;
        if (tryAgainTimer >= 2f)
        {
            tryAgain.enabled = false;
            tryAgainTimer = 0;
        }
        if (clicDroitTrue == 1)
        {
            clicDroit.enabled = true;
            clicDroitTimer += Time.deltaTime;
            zoneClic2.SetActive(true);
        }
        if (clicDroitTrue == 2)
        {
            clicDroit.enabled = true;
            clicDroitTimer += Time.deltaTime;
            zoneClic2.SetActive(false);
        }
        if (clicDroitTrue == 0)
            clicDroit.enabled = false;
        if (zoneBleueTrue == true)
        {
            zoneBlue.SetActive(true);
            zoneBleueTrue = false;
        }
        if (attireBleu == 1)
            attireBleuText.enabled = true;
        if (attireBleu == 2)
            attireBleuText.enabled = false;
    }

    public void OnLoad()
    {
        launch.SetActive(true);
        ButtonManager.GetComponent<Animator>().enabled = true;
        //PlayerPrefs.SetInt("TutoFini", 1);

    }
}
