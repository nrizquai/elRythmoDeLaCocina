using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class MenuGame : MonoBehaviour
{

    PlayerInputs inputs = null;

    Text dataTextF;
    Text dataTextB;

    public List<Text> affichage;
    [SerializeField]int actual;

    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.UIController.joystickL.started += Navigate;
        inputs.UIController.validate.performed += valid;
        inputs.UIController.@return.started += Back;

        
    }
    private void Start()
    {
        //actual = 0;

    }
    private void Update()
    {
        
    }
    private void OnEnable()
    {
        inputs.UIController.Enable();
    }
    private void OnDisable()
    {
        inputs.UIController.Disable();
    }

    void Navigate(CallbackContext ctx)
    {
        float i = inputs.UIController.joystickL.ReadValue<float>();

        if(i > 0)
        {
            if (actual >= affichage.Count - 1)
            {
                actual = 0;

            }
            else
            {
                actual++;
            }
        }
        if(i < 0)
        {
            if(actual <= 0)
            {
                actual = affichage.Count-1;
            }
            else
                actual--;
        }
        //debug
        affichage[actual].text += "*";
    }
    void valid(CallbackContext ctx)
    {
        if (actual == 0 && affichage.Count == 4)
        {
            Play();
        }

        if (actual == 1 && affichage.Count == 4)
        {
            Options();
        }

        if (actual == 2 && affichage.Count == 4)
        {
            Credits();
        }

        if (actual == 3 && affichage.Count == 4)
        {
            OnQuit();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(2);
    }
    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
    public void Back(CallbackContext ctx)
    {
        SceneManager.LoadScene(0);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
