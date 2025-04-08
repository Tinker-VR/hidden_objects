using System;
using UnityEngine;

namespace Tinker
{
    [Serializable]
    public class AudioData
    {
        public string _id;
        public AudioClip _audioClip;

        public void PlayAudio(AudioSource audioSource)
        {
            audioSource.clip = _audioClip;
            audioSource.Play();
        }
    }
}
