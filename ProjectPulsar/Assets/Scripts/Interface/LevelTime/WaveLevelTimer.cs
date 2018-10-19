using UnityEngine;
using System.Collections;

public class WaveLevelTimer : MonoBehaviour
{
    Instanciate enemyMaxNumber;

    public int score = 0, scoreClone = 0;
    public float waveTimer = 0, scoreComboTimer = 0, timerBetweenWave = 0f;
    float scoreAmount, scoreSize = 0.06f;
    float hueChange;
    bool starCheckTrue = false;
    public bool endWave = false;

    public TextMesh textSize, textColor;
    GameObject[] starBorder;
    public Sprite starBorderSprite;

    public int nombreENM1, nombreENM2;
    public int nombreMaxENM1 = 0, nombreMaxENM2 = 0;

    // Use this for initialization
    void Start()
    {
        textSize = GetComponent<TextMesh>();
        textColor = GetComponent<TextMesh>();
        enemyMaxNumber = GameObject.Find("SpawnPoint").GetComponent<Instanciate>();
        starBorder = GameObject.FindGameObjectsWithTag("StarBorder");
        for (int i = 0; i < starBorder.Length; i++)
        {
            Color alpha = starBorder[i].GetComponent<SpriteRenderer>().color;
            alpha.a = 0;
            starBorder[i].GetComponent<SpriteRenderer>().color = alpha;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 50000)
        {
            if (hueChange >= 1f)
                hueChange = 0;
            hueChange += 0.02f;
            Color hueColor = Color.HSVToRGB(hueChange, 1f, 1f);
            textColor.color = hueColor;
            if (endWave == true)
                if (score >= 50000)
                {
                    for (int i = 0; i < starBorder.Length; i++)
                    {
                        Color alpha = starBorder[i].GetComponent<SpriteRenderer>().color;
                        alpha.a = 1;
                        starBorder[i].GetComponent<SpriteRenderer>().color = alpha;
                        starBorder[i].GetComponent<SpriteRenderer>().color = hueColor;
                    }
                }
        }

        palierColor(0.070f, 0, 100, 220, 220, 220, 1, "Star1");
        palierColor(0.075f, 100, 250, 169, 0, 220, 2, "Star1");
        palierColor(0.080f, 250, 500, 0, 55, 255, 1, "Star2");
        palierColor(0.085f, 500, 1000, 0, 220, 209, 2, "Star2");
        palierColor(0.090f, 1000, 2500, 0, 165, 82, 1, "Star3");
        palierColor(0.095f, 2500, 5000, 110, 220, 0, 2, "Star3");
        palierColor(0.100f, 5000, 10000, 220, 202, 0, 1, "Star4");
        palierColor(0.105f, 10000, 25000, 255, 128, 0, 2, "Star4");
        palierColor(0.110f, 25000, 50000, 255, 0, 0, 1, "Star5");

        if (endWave == false)
        {
            waveTimer += Time.deltaTime;
            timerBetweenWave += Time.deltaTime;
            GetComponent<TextMesh>().text = score.ToString("f0");

            if (timerBetweenWave >= 5f)
                timerBetweenWave = 0;

            if (scoreClone != score)
            {
                scoreComboTimer += Time.deltaTime;
            }

            if (scoreComboTimer >= 1f)
            {
                scoreClone = score;
                scoreComboTimer = 0f;
                textSize.characterSize = scoreSize;
            }


            EnemyWaveNumber(0f, 5f, 0, 0);
            EnemyWaveNumber(5f, 10f, 1, 0);
            EnemyWaveNumber(10f, 30f, 3, 0);
            EnemyWaveNumber(30f, 45f, 6, 0);
            EnemyWaveNumber(45f, 55f, 4, 0);
            EnemyWaveNumber(55f, 75f, 5, 0);
            EnemyWaveNumber(75f, 85f, 5, 1);
            EnemyWaveNumber(85f, 105f, 7, 0);
            EnemyWaveNumber(105f, 115f, 5, 1);
            EnemyWaveNumber(115f, 125f, 7, 1);
            EnemyWaveNumber(125f, 145f, 8, 0);
            EnemyWaveNumber(145f, 165f, 6, 1);
            EnemyWaveNumber(165f, 180f, 9, 1);
            EnemyWaveNumber(180f, 200f, 11, 0);
            EnemyWaveNumber(200f, 220f, 8, 2);
            EnemyWaveNumber(220f, 240f, 16, 0);
            EnemyWaveNumber(240f, 260f, 11, 1);
            EnemyWaveNumber(260f, 280f, 11, 2);
            EnemyWaveNumber(280f, 300f, 11, 3);
            EnemyWaveNumber(300f, 350f, 14, 2);
            EnemyWaveNumber(350f, 400f, 18, 2);
            EnemyWaveNumber(400f, 20000f, 18, 4);

        }

        if (endWave == true)
            textColor.text = "Score " + score.ToString();
    }

    void palierColor(float size, int lowScore, int highScore, byte red, byte green, byte blue, int starFull, string starName)
    {
        if (score >= lowScore && score < highScore)
        {
            textColor.color = new Color32(red, green, blue, 255);

            if (endWave == true && score < 50000)
                for (int i = 0; i < starBorder.Length; i++)
                {
                    Color alpha = starBorder[i].GetComponent<SpriteRenderer>().color;
                    alpha.a = 1;
                    starBorder[i].GetComponent<SpriteRenderer>().color = alpha;
                    starBorder[i].GetComponent<SpriteRenderer>().color = new Color32(red, green, blue, 255);
                }

            scoreSize = size;
        }

        if (scoreClone != score && textSize.characterSize >= size)
        {
            textSize.characterSize -= Time.deltaTime * 0.0015f;
        }

        if (starCheckTrue == false)
        {
            GameObject.Find(starName).GetComponent<StarSpriteTrue>().state = starFull;
            starCheckTrue = true;
        }
    }

    void EnemyWaveNumber(float lowTime, float highTime, int maxEnm1, int maxEnm2)
    {
        if (waveTimer >= lowTime && waveTimer <= highTime && timerBetweenWave == 0)
        {
            nombreMaxENM1 = maxEnm1;
            nombreMaxENM2 = maxEnm2;
        }
    }
}
