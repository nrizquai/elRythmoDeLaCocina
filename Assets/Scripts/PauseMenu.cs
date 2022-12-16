
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] PlayerInputs _playerInputs;

    public GameObject pauseUI;
    public GameObject quit;

    public HittingNotes A, B, C, D, E, F;

    public bool inPause;

    
    

    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.UIController.Pause.performed += validate;
        _playerInputs.UIController.validate.performed += southbutton;
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

    private void Start()
    {
        
    }
    private void Update()
    {
        
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

    public void southbutton(CallbackContext ctx)
    {
        if(EventSystem.current.currentSelectedGameObject == quit)
        {
            SceneManager.LoadScene(0);
        }
    }

    
    
        
        
           
        
       
        
    
}
