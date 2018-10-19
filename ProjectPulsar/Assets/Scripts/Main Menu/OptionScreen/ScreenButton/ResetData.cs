using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetData : MonoBehaviour
{
    EnergyPointsSaved resetText, score2, score3, score4, score5, score6, score7, score8, score9, score10;

    void Start()
    {
        resetText = GameObject.Find("EnergyPoints").GetComponent<EnergyPointsSaved>();
        score2 = GameObject.Find("Score2").GetComponent<EnergyPointsSaved>();
        score3 = GameObject.Find("Score3").GetComponent<EnergyPointsSaved>();
        score4 = GameObject.Find("Score4").GetComponent<EnergyPointsSaved>();
        score5 = GameObject.Find("Score5").GetComponent<EnergyPointsSaved>();
        score6 = GameObject.Find("Score6").GetComponent<EnergyPointsSaved>();
        score7 = GameObject.Find("Score7").GetComponent<EnergyPointsSaved>();
        score8 = GameObject.Find("Score8").GetComponent<EnergyPointsSaved>();
        score9 = GameObject.Find("Score9").GetComponent<EnergyPointsSaved>();
        score10 = GameObject.Find("Score10").GetComponent<EnergyPointsSaved>();
    }

    public void ResetDataButton()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.SetInt("Score2", 0);
        PlayerPrefs.SetInt("Score3", 0);
        PlayerPrefs.SetInt("Score4", 0);
        PlayerPrefs.SetInt("Score5", 0);
        PlayerPrefs.SetInt("Score6", 0);
        PlayerPrefs.SetInt("Score7", 0);
        PlayerPrefs.SetInt("Score8", 0);
        PlayerPrefs.SetInt("Score9", 0);
        PlayerPrefs.SetInt("Score10", 0);
        resetText.GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore").ToString();
        GameObject.Find("Score2").GetComponent<Text>().text = PlayerPrefs.GetInt("Score2").ToString();
        GameObject.Find("Score3").GetComponent<Text>().text = PlayerPrefs.GetInt("Score3").ToString();
        GameObject.Find("Score4").GetComponent<Text>().text = PlayerPrefs.GetInt("Score4").ToString();
        GameObject.Find("Score5").GetComponent<Text>().text = PlayerPrefs.GetInt("Score5").ToString();
        GameObject.Find("Score6").GetComponent<Text>().text = PlayerPrefs.GetInt("Score6").ToString();
        GameObject.Find("Score7").GetComponent<Text>().text = PlayerPrefs.GetInt("Score7").ToString();
        GameObject.Find("Score8").GetComponent<Text>().text = PlayerPrefs.GetInt("Score8").ToString();
        GameObject.Find("Score9").GetComponent<Text>().text = PlayerPrefs.GetInt("Score9").ToString();
        GameObject.Find("Score10").GetComponent<Text>().text = PlayerPrefs.GetInt("Score10").ToString();



        PlayerPrefs.SetInt("TutoFini", 0);
    }
}
