using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public MenuGame nav;
    [SerializeField] private Canvas LoadingCanvas;
    [SerializeField] private Canvas MainCanvas;
    //[SerializeField] private Canvas QuitCanvas;
     public Animator animator;
    public void valid(CallbackContext ctx)
    {
        if (nav.actual == 0 && nav.affichage.Count == 4)
        {
            animator.SetBool("isOpening",true);
           
            
        }

        if (nav.actual == 1 && nav.affichage.Count == 4)
        {
            Options();
        }

        if (nav.actual == 2 && nav.affichage.Count == 4)
        {
            Credits();
        }

        if (nav.actual == 3 && nav.affichage.Count == 4)
        {
            OnQuit();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(4);
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
