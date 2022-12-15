using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNotes : MonoBehaviour
{

    #region �_lire
    // !!!! NOMENCLATURES PRIV�E = _maVariable
    //                    PUBLIC = MaVariable
    //                    FONCTION = MaFonction()
    // pas de chiffres dans les fonctions ni dans les variables.
    // s'il y a deux variables pareilles nomm� VarA, VarB par exemple.
    // /!\ ATTENTION : bien regarder le cycle de vis sur discord.
    #endregion �_lire
    public float _dist;
    public Generateur bloc;

    private void Start()
    {
        bloc = FindObjectOfType<Generateur>();
    }
    void Update()
    {
        _dist = Vector3.Distance(bloc._bloc[bloc.selec].transform.position, transform.position);
    }

}
