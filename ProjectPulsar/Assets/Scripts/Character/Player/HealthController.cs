using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour
{
    Player player;
    PlayerTuto playerTuto;

    Image healthBar;

    float hpAmount;
    int hpMax, hp;

    void Start()
    {
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            player = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
        if (PlayerPrefs.GetInt("TutoFini") == 0)
            playerTuto = GameObject.Find("PulsarTuto").GetComponent<PlayerTuto>();

        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        if (gameObject.name == "HealthBar" && PlayerPrefs.GetInt("TutoFini") == 1)
        {
            hpMax = player.hpMax;
            hp = player.hp;
            hpAmount = (float)hp / hpMax;
            healthBar.fillAmount = hpAmount;
        }
        if (gameObject.name == "HealthBar" && PlayerPrefs.GetInt("TutoFini") == 0)
        {
            hpMax = playerTuto.hpMax;
            hp = playerTuto.hp;
            hpAmount = (float)hp / hpMax;
            healthBar.fillAmount = hpAmount;
        }
    }
}
