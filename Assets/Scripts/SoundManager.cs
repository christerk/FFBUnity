using Fumbbl;
using System.Collections.Generic;
using UnityEngine;

namespace Fumbbl
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource SoundEffectSource;

        private Dictionary<string, AudioClip> SoundEffectClips;

        #region MonoBehaviour Methods

        private void Start()
        {
            FFB.Instance.OnSound += Play;
            Object[] AudioFiles;
            AudioFiles = Resources.LoadAll("Audio", typeof(AudioClip));

            SoundEffectClips = new Dictionary<string, AudioClip>();

            foreach (AudioClip file in AudioFiles)
            {
                SoundEffectClips.Add(file.name, file);
            }
        }

        private void OnDisable()
        {
            FFB.Instance.OnSound -= Play;
        }

        #endregion

        public void Play(string sound)
        {
            AudioClip clip = SoundEffectClips[sound];
            if (clip != null && !FFB.Instance.Settings.Sound.Mute)
            {
                SoundEffectSource.PlayOneShot(clip, FFB.Instance.Settings.Sound.GlobalVolume);
            }
        }
    }
}
