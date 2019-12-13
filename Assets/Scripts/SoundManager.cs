using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

using Fumbbl;


public class SoundManager : MonoBehaviour
{

    private Dictionary<string, AudioClip> SoundEffectClips;
    public AudioSource SoundEffectSource;

    void Start()
    {
        FFB.Instance.OnSound += Play;
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
        if(clip != null && !FFB.Instance.Settings.Sound.Mute)
        {
            SoundEffectSource.PlayOneShot(clip, FFB.Instance.Settings.Sound.GlobalVolume);
        }
    }

    void OnDisable()
    {
        FFB.Instance.OnSound -= Play;
    }
}
