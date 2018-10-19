using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    Player hpPlayer;

    public Canvas mainCanvas;
    public Canvas optionsCanvas;
    public Canvas historique;
    public Switch son;
    public Switch effects;
    public AudioSource theme;
    int musicSelected;
    public GameObject fadeInMainMenu, fadeTuto, MainMenuManager;

    void Awake()
    {
        optionsCanvas.enabled = false;
        historique.enabled = false;
        musicSelected = Random.Range(0, 2);
        MainMenuManager = GameObject.Find("MainMenuManager");
        if (musicSelected == 1)
            theme = GameObject.Find("MainMenuMusic1").GetComponent<AudioSource>();
        if (musicSelected == 0)
            theme = GameObject.Find("MainMenuMusic2").GetComponent<AudioSource>();

        theme.Play();

        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            theme.mute = false;
        }
        else if (PlayerPrefs.GetInt("Mute") == 1)
        {
            theme.mute = true;
        }
        hpPlayer = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
    }

    void Update ()
    {
        hpPlayer.hp = 12;
        hpPlayer.shieldTrigger = true;

        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            son.isOn = false;
        }
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            son.isOn = true;
        }
        if (PlayerPrefs.GetInt("MuteEffects") == 1)
        {
            effects.isOn = false;
        }
        if (PlayerPrefs.GetInt("MuteEffects") == 0)
        {
            effects.isOn = true;
        }

    }

    public void OptionsOn()
    {
        optionsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }
    
    public void HistoriqueOn()
    {
        mainCanvas.enabled = false;
        historique.enabled = true;
        optionsCanvas.enabled = false;
    }

    public void ReturnOn()
    {
        optionsCanvas.enabled = false;
        mainCanvas.enabled = true;
        historique.enabled = false;
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("TutoFini", 1);
        fadeInMainMenu.SetActive(true);
        MainMenuManager.GetComponent<Animator>().enabled = true;
    }

    public void LoadTutoriel()
    {
        PlayerPrefs.SetInt("TutoFini", 0);
        fadeTuto.SetActive(true);
        MainMenuManager.GetComponent<Animator>().enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SonActivation()
    {
        if (son.isOn)
        {
            theme.mute = false;
            PlayerPrefs.SetInt("Mute", 0);
        }
        else
        {
            theme.mute = true;
            PlayerPrefs.SetInt("Mute", 1);
        }
    }

    public void EffectsActivation()
    {
        if (effects.isOn)
        {
            
            PlayerPrefs.SetInt("MuteEffects", 0);
        }
        else
        {
            
            PlayerPrefs.SetInt("MuteEffects", 1);
        }
    }

}

    

   

