using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    private FMOD.Studio.EventInstance song;
    
    [SerializeField] GameObject needleUp;
    [SerializeField] GameObject needleDown;

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
        // not safe rn, good enough for class demo
        needleUp.SetActive(false);
        needleDown.SetActive(true);
    }

    public void Muffle(int setting)
    {
        song.setParameterByName("muffled", setting);
    }
}
