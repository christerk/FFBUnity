using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private Dictionary<string, AudioClip> SoundEffectClips;
    public AudioSource SoundEffectSource;

    void Start()
    {
        Object[] AudioFiles;
        AudioFiles = Resources.LoadAll("Audio", typeof(AudioClip));

        SoundEffectClips = new Dictionary<string, AudioClip>();

        foreach(AudioClip file in AudioFiles)
        {
            SoundEffectClips.Add(file.name, file);
        }
    }

    public void Play(string sound)
    {
        AudioClip clip = SoundEffectClips[sound];
        if(clip != null)
        {
            SoundEffectSource.PlayOneShot(clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
           Play("whistle");
       }
    }
}
