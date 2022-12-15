
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;


public class PauseMenu : MonoBehaviour
{

    [SerializeField] PlayerInputs _playerInputs;

    public GameObject pauseUI;

    public HittingNotes A, B, C, D, E, F;

    public bool inPause;

    public float timeResume;
    public bool EndTimer = true;
    public Text timeText;

    

    
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


    //SceneManager.LoadScene(0);

    public void test()
    {
            
    }
    public void Options()
    {
        
    }

    
}
