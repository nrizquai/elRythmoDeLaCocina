using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public Slider Slider;
    public play charge;
     void Start()
    {
        Slider.value = 0f;
    }

    void Update()
    {
        Slider.value += Time.deltaTime;
        if(Slider.value >= 10f )
        {
            charge.Play();
        }
    }
}
