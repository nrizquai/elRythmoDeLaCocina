using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoring : MonoBehaviour
{
    public Text Score;
    public Text Highscore;
    public Text Combo;
    public int Parfait = 100;
    public int Bien = 50;
    public int rate = -10;
    public int score = 0;
    public int combo = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString("0000000");
        }
        Combo.text = "";
        Score.text = "0000000";
    }

    public void SaveScore(int score)
    {
        int highscore = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

    }

    public void Gainscore(int gagner)
    {
        score += gagner;
        Score.text = score.ToString("0000000");

        if (gagner > 0)
        {
            Gaincombo(1);
        }

        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
       
    }

    public void Gaincombo(int gain)
    {
        combo += gain;
        Combo.text = "x" + combo;
        if(Combo.transform.localScale.x < 2f && Combo.transform.localScale.y < 2f && Combo.transform.localScale.z < 2f)
            Combo.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);

    }

    private void Update()
    {
        if(Combo.transform.localScale.x >= 1f && Combo.transform.localScale.y >= 1f && Combo.transform.localScale.z >= 1f)
        Combo.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
        
    }


}
