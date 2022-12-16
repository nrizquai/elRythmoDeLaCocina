
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
    public AudioClip furnace, slurp, pizzaPunch, bouillir;
    public List<AudioClip> decoupe, lave;

    public List<GameObject> vfx;
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
    [SerializeField]float tmp;

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
        {
            transform.localScale = new Vector3(_maxBlocScale, _maxBlocScale, _maxBlocScale);
            Debug.Log(tmp);
        }


        else
            transform.localScale = new Vector3(_minBlocScale, _minBlocScale, _minBlocScale);
        context = ctx;

    }


    private void OnTriggerStay(Collider other)
    {
        dist = Vector3.Distance(transform.position, other.gameObject.transform.position);
        //Debug.Log(dist);
        if (context.ReadValueAsButton() == true)
        {
            if (dist <= 0.8f)
            {
                score.Gainscore(score.Parfait);
                Destroy(other.gameObject);
                //Debug.Log("parfait");
            }
            if (dist > 0.8f && dist < 1.2f)
            {
                score.Gainscore(score.Bien);
                Destroy(other.gameObject);
                //Debug.Log("bien");
            }

            int selec = note._bloc.IndexOf(gameObject);
            if (selec == 0)
            {
                source.PlayOneShot(bouillir,1f);
            }
            if (selec == 1)
            {
                source.PlayOneShot(furnace,1f);
            }
            if (selec == 2)
            {
                source.PlayOneShot(pizzaPunch, 1f);
            }
            if (selec == 3)
            {
                source.PlayOneShot(slurp, 1f);
            }
            if (selec == 4)
            {
                int i = Random.Range(0, 2);
                source.PlayOneShot(lave[i], 1f);
            }
            if (selec == 5)
            {
                int i = Random.Range(0, 2);
                source.PlayOneShot(decoupe[i], 1f);

            }

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
        tmp += Time.deltaTime;

        if (stop.inPause == true)
        {
            this.enabled = false; 
        }
    }
}
