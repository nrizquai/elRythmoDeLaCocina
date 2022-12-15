
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class PauseMenu : MonoBehaviour
{

    [SerializeField] PlayerInputs _playerInputs = null;

    public GameObject pauseUI;

    public HittingNotes A, B, C, D, E, F;

    public bool inPause;

    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.UIController.Pause.performed += validate;
    }
   

    private void OnEnable()
    {
        _playerInputs.UIController.Pause.Enable();
        _playerInputs.UIController.validate.Enable();

        
    }

    private void OnDisable()
    {
        _playerInputs.UIController.Pause.Disable();
        _playerInputs.UIController.validate.Disable();
    }

    
    void validate(CallbackContext ctx)
    {
        
        inPause = !inPause;
        if(inPause == true)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseUI.SetActive(true);
            
        }
        if(inPause == false) 
        {

            Time.timeScale = 1;
            AudioListener.pause = false;
            pauseUI.SetActive(false);
            A.enabled = true;
            B.enabled = true;
            C.enabled = true;
            D.enabled = true;
            E.enabled = true;
            F.enabled = true;
        }
        

    }

  

    public void Valid()
    {
        
    }
    public void Options()
    {

    }

    public void Quitter()
    {

    }
}
