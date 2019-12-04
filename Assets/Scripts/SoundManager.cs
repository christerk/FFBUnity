using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

using Fumbbl;
using Fumbbl.Ffb.Dto;



public class SoundManager : MonoBehaviour
{

    private Dictionary<string, AudioClip> SoundEffectClips;
    public AudioSource SoundEffectSource;

    void Start()
    {
        FFB.Instance.Sound = this;
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
        Debug.Log("Play sound: " + sound);
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

    void OnDisable()
    {
        FFB.Instance.Sound = null;
    }
}
