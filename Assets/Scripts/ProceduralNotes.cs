using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNotes : MonoBehaviour
{

    #region à_lire
    // !!!! NOMENCLATURES PRIVÉE = _maVariable
    //                    PUBLIC = MaVariable
    //                    FONCTION = MaFonction()
    // pas de chiffres dans les fonctions ni dans les variables.
    // s'il y a deux variables pareilles nommé VarA, VarB par exemple.
    // /!\ ATTENTION : bien regarder le cycle de vis sur discord.
    #endregion à_lire
    [SerializeField] float _speed = 10f;
    public Rigidbody _rb;

    void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.MovePosition(transform.position - transform.forward * _speed * Time.deltaTime);
    }
}
