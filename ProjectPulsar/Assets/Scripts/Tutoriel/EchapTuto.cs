using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EchapTuto : MonoBehaviour
{

    public GameObject escape, launch;
    public AudioSource theme;
    int musicSelected;
    public bool pauseActive = false;
    GameObject ButtonManager;

    void Awake()
    {
        escape.SetActive(false);
        if (musicSelected == 0)
            theme = GameObject.Find("GameMusic1").GetComponent<AudioSource>();
        theme.Play();
        ButtonManager = GameObject.Find("ButtonManager");
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
        launch.SetActive(true);
    }

    public void ResumeButton()
    {
        Invoke("ResumeGame", 0f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        launch.SetActive(true);
        ButtonManager.GetComponent<Animator>().enabled = true;
    }

    void ResumeGame()
    {
        escape.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }
}
