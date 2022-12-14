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
    public int score = 0;
    public int combo = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Gainscore(Parfait);
            Debug.Log("Parfait");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Gainscore(Bien);
            Debug.Log("Bien");
        }
       
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
        Score.text = "Score:" + score;

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
        Combo.text = "Combo:" + combo;


    }

    
}
