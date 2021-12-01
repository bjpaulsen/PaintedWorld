using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    private FMOD.Studio.EventInstance song;

    void Start() 
    { 
        song = FMODUnity.RuntimeManager.CreateInstance("event:/LetterSong");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            PlayRecord();
        
        if (Input.GetKeyDown("left shift"))
            song.setParameterByName("muffled", 1);
    }

    void PlayRecord()
    {
        song.start();
    }
}
