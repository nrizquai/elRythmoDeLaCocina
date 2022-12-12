using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _bloc;

    [SerializeField] int _delay;
    [SerializeField] float _bpm;
    
    float _beat;
    float _timeElapsed;

public GameObject _prefab;
    private void Awake()
    {
        _beat = 60f / _bpm;    
    }
    void Start()
    {
    }

    void Update()
    {
        
        _timeElapsed += Time.deltaTime;
        if(_timeElapsed > _beat)
        {
            int i = Random.Range(0, _bloc.Count);
            _timeElapsed = _timeElapsed % _beat;
            Instantiate(_prefab, _bloc[i].transform.position + Vector3.forward*5 , Quaternion.identity);
        }

    }
}
