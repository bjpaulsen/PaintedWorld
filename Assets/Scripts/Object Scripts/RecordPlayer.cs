using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    private FMOD.Studio.EventInstance song;

    void Awake() 
    {
        song = FMODUnity.RuntimeManager.CreateInstance("event:/LetterSong");
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Record Player");
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
            PlayRecord();
    }

    private void PlayRecord()
    {
        song.start();
    }

    public void Muffle(int setting)
    {
        song.setParameterByName("muffled", setting);
    }
}
