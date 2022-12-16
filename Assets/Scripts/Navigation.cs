using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Navigation : MonoBehaviour
{
    [SerializeField] private Canvas LoadingCanvas;
    [SerializeField] private Canvas MainCanvas;
    public Animator animator;
    public play button;

    public GameObject options;
    public GameObject credits;
    public GameObject quit;
    public GameObject play;
    public GameObject back;

    #region inputs
    PlayerInputs inputs = null;
    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.UIController.validate.performed += valid;
    }
    private void OnEnable()
    {
        inputs.UIController.Enable();
    }
    private void OnDisable()
    {
        inputs.UIController.Disable();
    }
#endregion inputs

    public void valid(CallbackContext ctx)
    {
        if (EventSystem.current.currentSelectedGameObject == play)
        {
            animator.SetBool("isOpening",true);
        }

        if (EventSystem.current.currentSelectedGameObject == options)
        {
            button.Options();
        }

        if (EventSystem.current.currentSelectedGameObject == credits)
        {
            button.Credits();
        }

        if (EventSystem.current.currentSelectedGameObject == quit)
        {
            button.OnQuit();
        }
        if (EventSystem.current.currentSelectedGameObject == back)
        {
            button.Back();
        }
    }
    
}
