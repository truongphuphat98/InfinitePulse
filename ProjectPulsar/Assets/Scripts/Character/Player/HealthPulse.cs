using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPulse : MonoBehaviour
{
    Player player;
    PlayerTuto playerTuto;

    Light halo;
    Color haloColor;
    float size;
    void Start()
    {
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            player = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
        if (PlayerPrefs.GetInt("TutoFini") == 0)
            playerTuto = GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>();
        halo = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("TutoFini") == 1)
        {
            if (player.shieldTrigger == false)
            {
                if (player.hp > 9)
                {
                    haloColor = new Color(0, 255, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp > 6 && player.hp <= 9)
                {
                    haloColor = new Color(234, 255, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 6)
                {
                    haloColor = new Color(255, 38, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 5)
                {
                    haloColor = new Color(255, 30, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 4)
                {
                    haloColor = new Color(255, 25, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 3)
                {
                    haloColor = new Color(255, 21, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 2)
                {
                    haloColor = new Color(255, 13, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 1)
                {
                    haloColor = new Color(255, 0, 0, 255);
                    halo.color = haloColor;
                }
                if (player.hp == 0)
                {
                    size = 1f;
                    halo.range = size;
                }
            }
            if (player.shieldTrigger == true)
            {
                haloColor = new Color(0, 255, 255, 255);
                halo.color = haloColor;
            }
        }
        if (PlayerPrefs.GetInt("TutoFini") == 0)
        {
            if (playerTuto.hp > 9)
            {
                haloColor = new Color(0, 255, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp > 6 && playerTuto.hp <= 9)
            {
                haloColor = new Color(234, 255, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 6)
            {
                haloColor = new Color(255, 38, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 5)
            {
                haloColor = new Color(255, 30, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 4)
            {
                haloColor = new Color(255, 25, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 3)
            {
                haloColor = new Color(255, 21, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 2)
            {
                haloColor = new Color(255, 13, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 1)
            {
                haloColor = new Color(255, 0, 0, 255);
                halo.color = haloColor;
            }
            if (playerTuto.hp == 0)
            {
                size = 1f;
                halo.range = size;
            }
            
        }
        


        if ( PlayerPrefs.GetInt("TutoFini") == 1)
        {
            size = 1.5f + (player.hp * 0.1f);
            halo.range = size;
        }
        if ( PlayerPrefs.GetInt("TutoFini") == 0)
        {
            size = 1.5f + (playerTuto.hp * 0.1f);
            halo.range = size;
        }
    }
}