using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
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
    [SerializeField] PlayerInputs _playerInputs = null;

    [SerializeField] float _maxBlocScale = 1.1f;
    [SerializeField] float _minBlocScale = 1.0f;

    [SerializeField] InputActionReference input;


    private void Awake()
    {
        //_playerInputs = new PlayerInputs();

        //_playerInputs.Controller.UoR.started+= IsHitting;
        //_playerInputs.Controller.UoR.canceled+= IsHitting;

            
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
    }

}
