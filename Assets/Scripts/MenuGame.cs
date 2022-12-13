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
    public int actual;

    public Navigation nav = null;

    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.UIController.joystickL.started += Navigate;
        inputs.UIController.validate.performed += nav.valid;
        inputs.UIController.@return.started += nav.Back;
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
    
}
