using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour {

    AudioSource theme;
    public AudioClip m1, m2, m3, m4, m5, m6, m7, m8;
    public float musicTime = 0, musicTimer = 0;
    int musicSelected;
    AudioClip mSlected;

    // Use this for initialization
    void Start () {
        theme = GetComponent<AudioSource>();
        musicSelected = Random.Range(0, 8);
        
    }
	
	// Update is called once per frame
	void Update () {
        if(!theme.isPlaying)
            theme.PlayOneShot(theme.clip);

        musicTimer += Time.deltaTime;

        if (musicTimer >= 0)
        {
            
            musicTime = PlayMusic(musicSelected);
            theme.clip = mSlected;

            musicTimer -= musicTime;
        }
        
    }
    float PlayMusic(int selected)
    {
        musicSelected += 1;
        if (musicSelected > 7)
            musicSelected = 0;
        if (selected == 0)
        {
            mSlected = m1;
            musicTime = m1.length;
        }
        if (selected == 1)
        {
            mSlected = m2;
            musicTime = m2.length;
        }
        if (selected == 2)
        {
            mSlected = m3;
            musicTime = m3.length;
        }
        if (selected == 3)
        {
            mSlected = m4;
            musicTime = m4.length;
        }
        if (selected == 4)
        {
            mSlected = m5;
            musicTime = m5.length;
        }
        if (selected == 5)
        {
            mSlected = m6;
            musicTime = m6.length;
        }
        if (selected == 6)
        {
            mSlected = m7;
            musicTime = m7.length;
        }
        if (selected == 7)
        {
            mSlected = m8;
            musicTime = m8.length;
        }
        
        return musicTime;
    }
}
