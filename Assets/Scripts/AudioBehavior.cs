using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehavior : MonoBehaviour
{
    public static AudioBehavior Instance;

    [SerializeField] public AudioClip ScoreHit;
    [SerializeField] public AudioClip HealHit;
    [SerializeField] public AudioClip ScaleHit;
    [SerializeField] public AudioClip JumpHit;
    [SerializeField] public AudioClip DeathHit;
    [SerializeField] public AudioSource Soundtrack;



    private AudioSource Source;

    private void Awake()
    {
        Soundtrack.loop = true;
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
