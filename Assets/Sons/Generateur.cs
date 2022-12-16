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
    public float dist;

    [SerializeField]Collider box;
    [SerializeField]Renderer boxnote;

    float ellapsed;
    float ellapsedMusic;
    float beatDuration;
    float onetwobeat;
    float onefourbeat;



    public int selec;

    void Start()
    {
        beatDuration = 60f / bpm;
        timeRatio = bpm / 60f;
        onetwobeat = beatDuration * 2;
        onefourbeat = beatDuration * 4;

        notes = new List<Transform>();
        for (int i = 0; i < partition.Count-1; i++)
        {
            MusicNote note = partition[i];
            selec = note.Bloc;
            GameObject go = Instantiate(prefab);

            box = _bloc[selec].GetComponent<Collider>();
            boxnote = go.GetComponent<Renderer>();

            if (selec == 0 || selec == 1)
                go.transform.position = Vector3.up * (box.bounds.max.y*2 + boxnote.bounds.max.y) + _bloc[selec].transform.position + Vector3.left * timeRatio * note.Pos * speed;

            if (selec == 2 || selec == 3)
                go.transform.position = Vector3.up * (box.bounds.max.y*2 + boxnote.bounds.max.y) +_bloc[selec].transform.position + Vector3.forward * timeRatio * note.Pos * speed;

            if (selec == 4 || selec == 5)
                go.transform.position = Vector3.up * (box.bounds.max.y*2 + boxnote.bounds.max.y) + _bloc[selec].transform.position + Vector3.right * timeRatio * note.Pos * speed;

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
                if(partition[i].Bloc == 0 || partition[i].Bloc == 1)
                    notes[i].transform.position += Vector3.right * timeRatio * Time.deltaTime * speed;

                if(partition[i].Bloc == 2 || partition[i].Bloc == 3)
                    notes[i].transform.position += Vector3.back * timeRatio * Time.deltaTime * speed;

                if(partition[i].Bloc == 4 || partition[i].Bloc == 5)
                    notes[i].transform.position += Vector3.left * timeRatio * Time.deltaTime * speed;
            }
        }

        
    }
}
