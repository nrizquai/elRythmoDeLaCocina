using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    [SerializeField] private Image uiFill;

    public AudioClip clip;
    public int Duration;
    private int remainingDuration;

    void Start()
    {
        Duration = (int)clip.length;
        Being(Duration);
    }

    private void Being (int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        
        while (remainingDuration >= 0)
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
            
        }
    }
}
