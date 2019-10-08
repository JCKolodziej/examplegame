using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30;
    public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;
        if(Time.time > timeLimit)
        {
            CameraController.timeOut = true;
        }
    }
}
