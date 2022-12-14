using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    [System.Serializable]
    public struct MusicNote
    {
        public float Pos;
        public int Bloc;
    }

    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> _bloc;
    [SerializeField] List<MusicNote> partition;
    [SerializeField] float bpm;

    public List<Transform> notes;
    public float speed;
    public float timeRatio;

    //[SerializeField] Camera cam;

    float ellapsed;
    float ellapsedMusic;
    float beatDuration;


    void Start()
    {
        beatDuration = 60f / bpm;
        timeRatio = bpm / 60f;

        notes = new List<Transform>();
        for (int i = 0; i < partition.Count; i++)
        {
            MusicNote note = partition[i];
            int j = note.Bloc;
            GameObject go = Instantiate(prefab);
            go.transform.position = _bloc[j].transform.position + Vector3.forward * timeRatio * note.Pos * speed;
            //go.GetComponent<MeshRenderer>().material.color = (partition[i] % 1 == 0 ? Color.yellow : Color.blue);

            notes.Add(go.transform);
        }
    }

    void Update()
    {
        float frameTime = Time.deltaTime;

        ellapsed += frameTime;

        if (ellapsed > beatDuration)
        {
            frameTime = frameTime - (ellapsed % beatDuration);
            ellapsed = ellapsed % beatDuration;
            Debug.Log("Beat");
        }

        ellapsedMusic += ellapsed;

        for (int i = 0; i < notes.Count; i++)
        {
            notes[i].transform.position += Vector3.back * timeRatio * Time.deltaTime * speed;
        }
    }
}
