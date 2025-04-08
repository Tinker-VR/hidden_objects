using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tinker
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        [SerializeField] private AudioSource m_bgmAudioSource;
        [SerializeField] private AudioSource m_sfxAudioSource;
        
        [Header("----AUDIO DATAS----"),Space(10)]
        [SerializeField] private AudioData[] m_bgmAudioDatas;
        [SerializeField] private AudioData[] m_sfxAudioDatas;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
        }

        private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
        {
            PlayBGM(arg0.name);
        }


        public void PlayBGM(string _id)
        {
            foreach (var _clip in m_bgmAudioDatas)
            {
                if (_clip._id == _id)
                {
                    _clip.PlayAudio(m_bgmAudioSource);
                }
            }
        }

        public void PlaySFX(string _id)
        {
            foreach (var _clip in m_sfxAudioDatas)
            {
                if (_clip._id == _id)
                {
                    _clip.PlayAudio(m_sfxAudioSource);
                }
            }
        }
    }
}
