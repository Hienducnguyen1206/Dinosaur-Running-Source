using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region Singleton
    public  static  AudioController Instance;
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
    #endregion


    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClipList = new List<AudioClip>();

    public enum SoundEffect
    {
        JUMP,DIE,LAND,BUTTON
    }


  
        public void PlayOnce(SoundEffect soundEffect)
        {
            switch (soundEffect)
            {
                case SoundEffect.JUMP:
                    audioSource.PlayOneShot(audioClipList[0]);
                    break;

                case SoundEffect.DIE:
                    audioSource.PlayOneShot(audioClipList[1]);
                    break;

                case SoundEffect.LAND:
                    audioSource.PlayOneShot(audioClipList[2]);
                    break;

                case SoundEffect.BUTTON:
                    audioSource.PlayOneShot(audioClipList[3]);
                    break;
                       
                default:
                    Debug.LogWarning("Sound effect not recognized: " + soundEffect);
                    break;
            }
        }




    
}
