using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        //creates audio source for each sound effect saved in the array
        foreach(Sound s in sounds)
        {
            s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    //when called it will olay the selected sound based on the name of the file
    public void Play(string name)
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            return;
        }

        s.source.Play();
    }







    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
