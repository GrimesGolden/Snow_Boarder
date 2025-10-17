using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// The sound manager for most simple sounds in the game. 

public enum SoundType
{
    // Represents the different triggers for sounds.
    // Must be in order. 
    CRASH,
    SLIDE,

    AIR,
    FINISH,
    PAUSE,
    APPLE,
    COFFEE,
    ERROR
}

// The audio sources will be renamed in edit mode. 
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList; // An array of structs, work around for a 2D array. 
    private static SoundManager instance; // There is only one instance of the sound manager in game. 
    private AudioSource audioSource; 
    private void Awake()
    {   
        // On initialization create the only instance. 
        instance = this;
    }

    private void Start()
    {  
        audioSource = GetComponent<AudioSource>(); 
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        // This is the main functionc called by other scripts.
        // Given a SoundType enum and the volume...
        // Return the entire sub-array of AudioClips from this instances soundList.
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        // Now randomly play a clip from within that list. 
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        // Utilize the attached audio source to play the clip. 
        instance.audioSource.PlayOneShot(randomClip, volume);
    }
    
    public static void StopSound()
    {   
        // Stop the current audio clip (whatever that may be)
        instance.audioSource.Stop(); 
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        // When the unity editor is opened.
        // Rename all SoundList elements in accordance with the SoundType enum. 
        // This just saves typing and looks clean in the editor. 

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
        // Representing a sub-array of audioclips. 
        // This struct essentially allows for 2D array-like behavior. 
        [SerializeField] public string name;
        [SerializeField] private AudioClip[] sounds; 
        
        // GET this array of audio clips (sounds)
        public AudioClip[] Sounds { get => sounds; }
    }
}
