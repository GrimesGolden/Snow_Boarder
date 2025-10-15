using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This needs comments. 

public enum SoundType
{
    CRASH,
    SLIDE,

    AIR,
    FINISH
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList; // An array of structs, work around for a 2D array. 
    private static SoundManager instance;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }
    
    public static void StopSound()
    {
        instance.audioSource.Stop(); 
    }

#if UNITY_EDITOR
    private void OnEnable()
    {

        String[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length); 

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i]; 
        }

    }
#endif

    [Serializable]
    public struct SoundList
    {
        [SerializeField] public string name;
        [SerializeField] private AudioClip[] sounds; 
        
        // Return the entire sub-array of audio clips (sounds)
        public AudioClip[] Sounds { get => sounds; }
    }
}
