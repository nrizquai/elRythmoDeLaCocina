using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    [System.Serializable]
    public class MusicNote
    {
        public float Pos;
        public int Bloc;
    }

    [SerializeField] GameObject prefab;
    public List<GameObject> _bloc;
    [SerializeField] List<MusicNote> partition;
    [SerializeField] float bpm;

    public List<Transform> notes;
    public float speed;
    public float timeRatio;

    //[SerializeField] Camera cam;
    [SerializeField]Renderer box;
    [SerializeField]Renderer boxnote;

    float ellapsed;
    float ellapsedMusic;
    float beatDuration;
    float onetwobeat;
    float onefourbeat;

    public int selec;

    void Start()
    {
        
        //partition[0].Pos = 0.8f;
        beatDuration = 60f / bpm;
        timeRatio = bpm / 60f;
        onetwobeat = beatDuration * 2;
        onefourbeat = beatDuration * 4;

        notes = new List<Transform>();
        for (int i = 0; i < partition.Count; i++)
        {
            MusicNote note = partition[i];
            selec = note.Bloc;
            GameObject go = Instantiate(prefab);

            box = _bloc[selec].GetComponent<Renderer>();
            boxnote = go.GetComponent<Renderer>();

            go.transform.position = Vector3.up * (box.bounds.max.y + boxnote.bounds.max.y) +_bloc[selec].transform.position + Vector3.forward * timeRatio * note.Pos * speed;
            //go.GetComponent<MeshRenderer>().material.color = (partition[i] % 1 == 0 ? Color.yellow : Color.blue);

            notes.Add(go.transform);

            partition[i].Pos += onefourbeat;
            partition[i+1].Pos = partition[i].Pos;
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
            if (notes[i] != null)
            {
                notes[i].transform.position += Vector3.back * timeRatio * Time.deltaTime * speed;
            }
        }
        
    }
}
