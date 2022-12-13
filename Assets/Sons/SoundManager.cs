using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _bloc;

    [SerializeField] int _delay;
    [SerializeField] float _bpm;
    [SerializeField] Slider volumeSlider;

    
    float _beat;
    float _timeElapsed;

public GameObject _prefab;
    private void Awake()
    {
        _beat = 60f / _bpm;    
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
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

    // Pour augmenter ou baisser le volume du jeu grâce au slider dans le menu pause
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
