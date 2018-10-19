using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLoseButton : MonoBehaviour
{
    public GameObject loseCanvas, escape, fadeInGame;
    public AudioSource theme, telepor, collisionEnm1, planetExplo1, planetExplo2, player, star, exploPulsar1, exploPulsar2;
    public bool pauseActive = false;

    GameObject ButtonMenuManager;

    void Awake()
    {
        ButtonMenuManager = GameObject.Find("ButtonMenuManager");
        loseCanvas.SetActive(false);
        escape.SetActive(false);      
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            theme.mute = false;
        }
        else if (PlayerPrefs.GetInt("Mute") == 1)
        {
            theme.mute = true;
        }
        if (PlayerPrefs.GetInt("MuteEffects") == 0)
        {
            telepor.mute = false;
            collisionEnm1.mute = false;
            planetExplo1.mute = false;
            planetExplo2.mute = false;
            player.mute = false;
            star.mute = false;
            exploPulsar1.mute = false;
            exploPulsar2.mute = false;
        }
        else if (PlayerPrefs.GetInt("MuteEffects") == 1)
        {
            telepor.mute = true;
            collisionEnm1.mute = true;
            planetExplo1.mute = true;
            planetExplo2.mute = true;
            player.mute = true;
            star.mute = true;
            exploPulsar1.mute = true;
            exploPulsar2.mute = true;
        }

        if (Input.GetKeyDown("escape") && pauseActive == true)
        {
            Invoke("ResumeGame", 0f);
        }

        if (Input.GetKeyDown("escape") && pauseActive == false)
        {
            escape.SetActive(true);
            Time.timeScale = 0;
            pauseActive = true;
        }

        
        
    }

    public void LoadOn()
    {
        fadeInGame.SetActive(true);
        ButtonMenuManager.GetComponent<Animator>().enabled = true;
    }

    public void ResumeButton()
    {
        Invoke("ResumeGame", 0f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ButtonMenuManager.GetComponent<Animator>().enabled = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        fadeInGame.SetActive(true);
        ButtonMenuManager.GetComponent<Animator>().enabled = true;
    }

    void ResumeGame()
    {
        escape.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }
}
