using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseText : MonoBehaviour
{
    WaveLevelTimer score;
    Text loseText;

    void Start()
    {
        loseText = GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<WaveLevelTimer>();
    }

    void Update()
    {
        loseText.text = "Score  " + score.score.ToString();
    }
}
