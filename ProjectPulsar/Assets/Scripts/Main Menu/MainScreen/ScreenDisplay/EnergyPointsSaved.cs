using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyPointsSaved : MonoBehaviour
{

    Text energyPoints;

    // Use this for initialization
    void Start()
    {
        energyPoints = gameObject.GetComponent<Text>();
        if (gameObject.name == "BestScore" || gameObject.name == "EnergyPoints")
            energyPoints.text = PlayerPrefs.GetInt("BestScore").ToString();
        if (gameObject.name == "Score2")
            energyPoints.text = "Score-2     " + PlayerPrefs.GetInt("Score2").ToString();
        if (gameObject.name == "Score3")
            energyPoints.text = "Score-3     " + PlayerPrefs.GetInt("Score3").ToString();
        if (gameObject.name == "Score4")
            energyPoints.text = "Score-4     " + PlayerPrefs.GetInt("Score4").ToString();
        if (gameObject.name == "Score5")
            energyPoints.text = "Score-5     " + PlayerPrefs.GetInt("Score5").ToString();
        if (gameObject.name == "Score6")
            energyPoints.text = "Score-6     " + PlayerPrefs.GetInt("Score6").ToString();
        if (gameObject.name == "Score7")
            energyPoints.text = "Score-7     " + PlayerPrefs.GetInt("Score7").ToString();
        if (gameObject.name == "Score8")
            energyPoints.text = "Score-8     " + PlayerPrefs.GetInt("Score8").ToString();
        if (gameObject.name == "Score9")
            energyPoints.text = "Score-9     " + PlayerPrefs.GetInt("Score9").ToString();
        if (gameObject.name == "Score10")
            energyPoints.text = "Score-10    " + PlayerPrefs.GetInt("Score10").ToString();
    }
}
