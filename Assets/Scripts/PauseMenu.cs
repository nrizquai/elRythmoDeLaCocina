using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PauseMenu : MonoBehaviour
{

    [SerializeField] PlayerInputs _playerInputs = null;
    [SerializeField] InputActionReference input;

    [SerializeField] private GameObject pauseUI;
    //[SerializeField] private bool isPaused;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }


    private void OnEnable()
    {
        input.action.Enable();
        input.action.performed += isPausing;

        
    }

    private void OnDisable()
    {
        input.action.Disable();
        input.action.performed -= isPausing;
    }

    public void isPausing(CallbackContext ctx)
    {
        if (!ctx.performed)
            return;

        if (ctx.ReadValueAsButton())
        {
            ActivateMenu();
        }

        else 
        {
            DeactivateMenu();
        }
        
       



    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
        
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        

    }
}
