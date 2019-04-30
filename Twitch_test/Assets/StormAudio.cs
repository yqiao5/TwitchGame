using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance StormB;
    // Start is called before the first frame update
    void Start()
    {
        StormB = FMODUnity.RuntimeManager.CreateInstance("event:/StormB");
        StormB.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
