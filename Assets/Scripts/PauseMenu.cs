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

    public bool Bool;
    //[SerializeField] private bool isPaused;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.UIController.Pause.performed += DeactivateMenu;
    }


    private void OnEnable()
    {
        _playerInputs.UIController.Pause.Enable();

        
    }

    private void OnDisable()
    {
        _playerInputs.UIController.Pause.Disable();
    }

    
    void DeactivateMenu(CallbackContext ctx)
    {
        Bool = !Bool;
        if(Bool == true)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseUI.SetActive(true);
        }
        if(Bool == false)
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
}
