using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneVictoireDefaite : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public Chrono timer;
    public play play;
    public HittingNotes slid;
    public HighScoring point;
    public Text score;
    public Text combo;
   

    AudioSource Test;

    

    private void Update()
    {
        if(slid.slider.value <= 0f)
        {
            conditionD();
        }
        if(timer.Duration <= 0f)
        {
            conditionV();
        }
    }

    public void conditionD()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        lose.SetActive(true);
        score.text = point.score.ToString("0000000");
        combo.text = point.combo.ToString();
        Invoke("reback", 5f);
    }
    public void conditionV()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        lose.SetActive(true);
        score.text = point.score.ToString("0000000");
        combo.text = point.combo.ToString();
        Invoke("reback", 5f);
    }

    public void reback()
    {
        play.Back();
    }




}
