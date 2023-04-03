using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioBehavior : MonoBehaviour
{
    public static StartAudioBehavior Instance;

    [SerializeField] public AudioClip SelectHit;
    


    private AudioSource Source;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        Source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        Source.PlayOneShot(clip, volume);
    }
}
