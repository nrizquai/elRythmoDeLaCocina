using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    [SerializeField] List<GameObject> _bloc;

    [SerializeField] GameObject _prefab;

    [SerializeField] float _bpm;
    [SerializeField] float _dist = 10f;
    public float _speed;

    float _ellapsedMusic;
    float _timeRatio;
    float _beatDuration;
    float _ellapsed;

    private void Awake()
    {
        _beatDuration = 60f / _bpm;
        _timeRatio = _bpm / 60f;
    }
    void Start()
    {

    }

    void Update()
    {
        //float frameTime = Time.deltaTime;
        _ellapsed += Time.deltaTime;

        int i = Random.Range(0, _bloc.Count);
        _speed = _dist / _timeRatio;

        if(_ellapsed > _beatDuration)
        {
            //frameTime = frameTime - (_ellapsed % _beatDuration);
            //_distance = Vector3.Distance(_bloc[i].transform.position, Pn.transform.position);
            _ellapsed = _ellapsed % _beatDuration;
            Instantiate(_prefab, _bloc[i].transform.position + Vector3.forward * 10f, Quaternion.identity);
        }

        _ellapsedMusic += _ellapsed;

    }
}
