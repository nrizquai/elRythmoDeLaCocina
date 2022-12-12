using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    [SerializeField] List<GameObject> _bloc;

    [SerializeField] int _delay;
    [SerializeField] float _bpm;
    
    float _beat;
    public float _distance;
    public float _timeRatio;
    float _timeEllapsed;
    public ProceduralNotes Pn;

    public GameObject _prefab;
    private void Awake()
    {
        _beat = 60f / _bpm;
        _timeRatio = _bpm / 60f;
    }
    void Start()
    {
    }

    void Update()
    {
        
        _timeEllapsed += Time.deltaTime;
        if(_timeEllapsed > _beat)
        {
            int i = Random.Range(0, _bloc.Count);
            _distance = Vector3.Distance(_bloc[i].transform.position, Pn.transform.position);
            _timeEllapsed = _timeEllapsed % _beat;
            Instantiate(_prefab, _bloc[i].transform.position + Vector3.forward * 10, Quaternion.identity);
        }

    }
}
