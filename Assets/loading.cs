using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    #region variables
    public int valueMinSlider = 0;
    public int valueMaxSlider = 100;


    [SerializeField] private Slider Slider;

    #endregion

    // Use this for initialization
    void Start()
    {
        Slider.value = valueMaxSlider;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = Mathf.Lerp(0.85f, 1.15f, 0 / 5);

        if (Slider.value <= valueMinSlider)
        {
            SceneManager.LoadScene(1);
        }
    }
}
