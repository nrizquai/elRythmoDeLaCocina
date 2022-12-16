
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class HittingNotes : MonoBehaviour
{

    #region à_lire
    // !!!! NOMENCLATURES PRIVÉE = _maVariable
    //                    PUBLIC = MaVariable
    //                    FONCTION = MaFonction()
    // pas de chiffres dans les fonctions ni dans les variables.
    // s'il y a deux variables pareilles nommé VarA, VarB par exemple.
    // /!\ ATTENTION : bien regarder le cycle de vis sur discord.
    #endregion à_lire
    public AudioClip clip;
    public AudioSource source;
    [SerializeField] PlayerInputs _playerInputs = null;

    [SerializeField] float _maxBlocScale = 1.1f;
    [SerializeField] float _minBlocScale = 1.0f;

    [SerializeField] InputActionReference input;

    public PauseMenu stop;
    public HighScoring score;
    public Generateur note;
    public Slider slider;

    public float life = 100;

    [SerializeField]float dist;

    public CallbackContext context;
    private void Start()
    {
        slider.value = 100;
    }

    #region init controller
    private void OnEnable()
    {
        input.action.Enable();
        input.action.performed += IsHitting;
    }

    private void OnDisable()
    {
        input.action.Disable();
        input.action.performed -= IsHitting;

    }
    #endregion init controller

    public void IsHitting(CallbackContext ctx)
    {
        if (!ctx.performed)
            return;

        
        if (ctx.ReadValueAsButton())
            transform.localScale = new Vector3(_maxBlocScale, _maxBlocScale, _maxBlocScale);
        else
            transform.localScale = new Vector3(_minBlocScale, _minBlocScale, _minBlocScale);
        context = ctx;
    }


    private void OnTriggerStay(Collider other)
    {
        dist = Vector3.Distance(note._bloc[note.selec].transform.position, other.gameObject.transform.position);
        if (context.ReadValueAsButton() == true)
        {
            if (dist <= 0.8f)
            {
                score.Gainscore(score.Parfait);
                Destroy(other.gameObject);
                Debug.Log("parfait");
            }
            if (dist > 0.8f && dist < 1.2f)
            {
                score.Gainscore(score.Bien);
                Destroy(other.gameObject);
                Debug.Log("bien");
            }


            if (note.selec == 0)
            {
                source.PlayOneShot(clip);
            }
            /*if (note.selec == 1)
            {

            }
            if (note.selec == 2)
            {

            }
            if (note.selec == 3)
            {

            }
            if (note.selec == 4)
            {

            }
            if (note.selec == 5)
            {

            }*/

        }
    }
    private void OnTriggerExit(Collider other)
    {
        score.combo = 0;
        if(score.combo == 0 )
            score.Combo.text= "";
        slider.value += score.rate;
        Destroy(other.gameObject);
    }
    private void Update()
    {
        

        if (stop.inPause == true)
        {
            this.enabled = false; 
        }
    }
}
