using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    private FMOD.Studio.EventInstance song;

    void Start() 
    { 
        song = FMODUnity.RuntimeManager.CreateInstance("event:/dying while golfing (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            PlayRecord();
    }

    void PlayRecord()
    {
        song.start();
    }
}
