using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    float speed;
    float credit;
    public play button;
    private void Start()
    {
        speed = 75f;
    }
    void Update()
    {
        credit += Time.deltaTime;
        if (credit <= 20f)
            transform.localPosition += Vector3.up* Time.deltaTime *speed;
        if(credit> 23f)
            button.Back();
    }
}
